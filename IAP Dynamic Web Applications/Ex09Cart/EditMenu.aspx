<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Edit Menu" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditMenu.aspx.cs" Inherits="EditMenu" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent"  ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />


    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }   
    </style>


</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

        <asp:GridView ID="GridView1"  class="table table-hover table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Users" Width="508px">
            <Columns>
                

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                

                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />           
                <asp:BoundField DataField="cost" HeaderText="Cost" SortExpression="cost" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="image" HeaderText="Image" SortExpression="image" />
                <asp:BoundField DataField="ShortDescription" HeaderText="ShortDescription" SortExpression="ShortDescription" />
                <asp:BoundField DataField="LongDescription" HeaderText="LongDescription" SortExpression="LongDescription" />
                <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Users" runat="server" ConnectionString="<%$ ConnectionStrings:MyRestaurant %>" 
            SelectCommand="SELECT * FROM [Product]" DeleteCommand="DELETE FROM [Product] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Product] ([name], [cost], [Category], [image], [ShortDescription], [LongDescription], [Calories]) VALUES (@name, @cost, @Category, @image, @ShortDescription, @LongDescription, @Calories)" UpdateCommand="UPDATE [Product] SET [name] = @name, [cost] = @cost, [Category] = @Category, [image] = @image, [ShortDescription] = @ShortDescription, [LongDescription] = @LongDescription, [Calories] = @Calories WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="cost" Type="Decimal" />
                <asp:Parameter Name="Category" Type="Int32" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="ShortDescription" Type="String" />
                <asp:Parameter Name="LongDescription" Type="String" />
                <asp:Parameter Name="Calories" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="cost" Type="Decimal" />
                <asp:Parameter Name="Category" Type="Int32" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="ShortDescription" Type="String" />
                <asp:Parameter Name="LongDescription" Type="String" />
                <asp:Parameter Name="Calories" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div class="container">
            <div class="text-center mt-4">
               <asp:Button ID="btnNewItem" class="btn btn-primary btn-md" runat="server" Text="Add New Menu Item" onclick="btnNewItem_Click" />
          </div>
        </div>
                            
                            <br />
    <asp:Panel ID="newItem" runat="server">
         <div class="container">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">

            <table id="tblNewItem" class="table table-hover table-striped" runat="server">

            <tr>
                <td>
                   Name:
                </td>
                <td>
                    <asp:TextBox ID="txtName" placeholder="Item Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cost:
                </td>
                <td>
                    <asp:TextBox ID="txtCost" placeholder="Item Cost" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                    Short Description:
                </td>
                <td>
                    <asp:TextBox ID="txtShortDescription" placeholder="Short Product Description" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                    Long Description:
                </td>
                <td>
                    <asp:TextBox ID="txtLongDescription" placeholder="Longer Product Description" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                    Calories:
                </td>
                <td>
                    <asp:TextBox ID="txtCalories" placeholder="Product Calories" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                    Category:
                </td>
                <td>
                    <asp:TextBox ID="txtCategory" placeholder="Category Number" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   Image:
                </td>
                <%-- Add check that image string is input correctly --%>
                <td>
                    <asp:TextBox ID="txtImage" placeholder="Image.jpg" runat="server"></asp:TextBox>
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
        <div class="container">
                        <div class="text-center mt-4">
                             <asp:Button ID="btnAddItem" class="btn btn-primary btn-md" runat="server" Text="Add To Menu" onclick="btnAddItem_Click" />
                        </div>
                    </div>
                
        </asp:Panel>
    </asp:Content>



