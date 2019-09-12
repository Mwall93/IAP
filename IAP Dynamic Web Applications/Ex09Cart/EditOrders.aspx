<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Edit Orders" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditOrders.aspx.cs" Inherits="EditOrders" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />    </asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

     
        <asp:Table id="tblOrders" class="table table-hover table-striped" runat="server">

              <asp:TableRow >
                  
      
                <asp:TableCell > Order ID </asp:TableCell >
           
                <asp:TableCell > Customer ID </asp:TableCell >
                
                <asp:TableCell > Cost </asp:TableCell >
                
                <asp:TableCell > Date </asp:TableCell >
                
                <asp:TableCell > Delete Order </asp:TableCell >
                  

         </asp:TableRow >

        </asp:Table>
   
    
        


</asp:Content>



