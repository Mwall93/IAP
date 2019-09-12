<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">  
    <%-- <meta charset="utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1"/>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
  
</asp:Content>

<asp:Content ContentPlaceHolderID="formPlaceHolder" Runat="Server">
    <asp:Label ID="lblWelcome" runat="server"></asp:Label>
    <%--<label>
    <br />
    Please select a product&nbsp;</label>
    <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource" DataTextField="Name" DataValueField="id">
    </asp:DropDownList>--%>
    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString='<%$ ConnectionStrings:MyRestaurant %>' SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>

    <div>
         <asp:Panel Id="panelMenuContainer" class="container" runat="server">
         <%--Menu Itmes Displayed Here--%>
        </asp:Panel>
    </div>

</asp:Content>

