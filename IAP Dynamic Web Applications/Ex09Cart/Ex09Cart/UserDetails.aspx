<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails " %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />


 <%--   <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>--%>


</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

        <asp:GridView ID="GridView1" CssClass="table table-hover table-striped"   runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Users" Width="508px">
            <Columns>

                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="username" HeaderText="Your Username" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="Your Password" SortExpression="password" />
                
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Users" runat="server" ConnectionString="<%$ ConnectionStrings:MyRestaurant %>" 

            SelectCommand="SELECT [username], [password], [Id] FROM [User] WHERE (([username] = @username) AND ([Id] = @Id))" 
            
           
            UpdateCommand="UPDATE [User] SET [username] = @username, [password] = @password WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="Username" Type="String" />
                <asp:SessionParameter Name="Id" SessionField="Id" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

  

 
    </asp:Content>



