<%@ Page Title="Your Shopping Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>
<%--<%@ MasterType VirtualPath="~/Site.master" %>--%>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Cart.css" rel="stylesheet" />
     <link href="Styles/Master.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="formContent" ContentPlaceHolderID="formPlaceHolder" Runat="Server">
    
   <%-- <div class="container">
        <div class="row">
        <div class="col-sm-5"></div>
            <div class="col-sm-2">
               
            </div>
            <div class="col-sm-5"></div>
        </div>--%>
        
        <div class="row">
        <div class="col-sm-5"></div>
            <div class="col-sm-2">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label><br />
            </div>
            <div class="col-sm-5"></div>
        </div>
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <asp:ListBox ID="lstCart" CssClass="form-control" runat="server"></asp:ListBox>
            </div>
            <div class="col-sm-3">
                <asp:Label ID="lblTotal" runat="server" Text="Total Cost: "></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-3">
                <asp:Button ID="btnRemove" runat="server" class="btn btn-primary btn-md" Text="Remove Item" OnClick="btnRemove_Click" />
            </div>
         
            <div class="col-sm-3">
                 <asp:Button ID="btnEmpty" runat="server" class="btn btn-primary btn-md" Text="Empty Cart" OnClick="btnEmpty_Click" />      
            </div>
            <div class="col-sm-3"></div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-3">
                <asp:Button ID="btnContinue" runat="server" class="btn btn-primary btn-md"  PostBackUrl="~/Order.aspx" Text="Continue Shopping" />
            </div>
           
            <div class="col-sm-3">
               <asp:Button ID="btnCheckOut" runat="server" class="btn btn-primary btn-md"  Text="Check Out" OnClick="btnCheckOut_Click" />
            </div>
            <div class="col-sm-3"></div>
        </div>
      
    </div>
            
       
   
    

</asp:Content>






