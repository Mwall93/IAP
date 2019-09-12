<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />


    </asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnEditUsers" runat="server" class="btn btn-primary btn-md" PostBackUrl="~/EditUsers.aspx" Text="Edit Users" />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnEditMenu" runat="server" class="btn btn-primary btn-md" PostBackUrl="~/EditMenu.aspx" Text="Edit Menu"  />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnEditOrders" runat="server" PostBackUrl="~/EditOrders.aspx" class="btn btn-primary btn-md" Text="Edit Orders"/>
            </div>
        </div>
    </div>


</asp:Content>



