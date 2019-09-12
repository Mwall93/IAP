<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Edit Users" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="EditUsers" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />


   <%-- <style type="text/css">
        .auto-style2 {
            height: 25px;
        }
    </style>--%>


</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

        <asp:GridView ID="GridView1" class="table table-hover table-striped"  runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Users" Width="508px">
            <Columns>
                <asp:CommandField ShowEditButton="True" EditText="Update" SelectText="Edit" DeleteText="Delete User" ShowDeleteButton="True" />
                <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                <asp:CheckBoxField DataField="admin" HeaderText="Admin" SortExpression="admin" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Users" runat="server" ConnectionString="<%$ 
            ConnectionStrings:MyRestaurant %>" 
            SelectCommand="SELECT * FROM [User]" 
            DeleteCommand="DELETE FROM [User] WHERE [Id] = @Id" 
            InsertCommand="INSERT INTO [User] ([username], [password], [admin]) VALUES (@username, @password, @admin)"
            UpdateCommand="UPDATE [User] SET [username] = @username, [password] = @password, [admin] = @admin WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="admin" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="admin" Type="Boolean" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
                    <div class="container">
                        <div class="text-center mt-4">
                             <asp:Button ID="btnAddUser" class="btn btn-primary btn-md" runat="server" Text="Add New User" onclick="btnAddUser_Click" />
                        </div>
                    </div>
       

        <asp:Panel ID="CreateUser" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                
            <table id="tblNewUser"  class="table table-hover table-striped" runat="server">

            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" Type="password" placeholder="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Confirm Password:
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" Type="password" placeholder="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Admin:
                </td>
                <td class="auto-style2">
                    <asp:CheckBox ID="checkBoxAdmin" runat="server" />
                </td>                
            </tr>
            <tr>
                <td>
                  
                       
       
                 
                </td>
                <td>
                    
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
                        </div><div class="col-md-2"></div></div></div>

             <div class="text-center mt-4">
                            <asp:Button ID="btnCreateUser" runat="server" class="btn btn-primary btn-md"  Text="Create User" onclick="btnCreateUser_Click" />
                    </div>
           

        </asp:Panel>
        
    </asp:Content>



