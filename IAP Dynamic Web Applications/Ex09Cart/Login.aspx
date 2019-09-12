<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<%--<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />

</asp:Content>--%>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">
  <p class="h4 text-center mb-4">Sign in</p>
    <%-- Change to offset at some point --%>
   <div class="row">
       <div class="col-xs-4"></div>
       
        <div class="col-xs-4">
    <label  class="grey-text">Your Username</label>
                </div>
       <div class="col-xs-4"></div>
        
    </div>
    <div class="row">
       <div class="col-xs-4"></div>
       
        <div class="col-xs-4">
    <asp:textbox type="text" runat="server" id="txtUsername" class="form-control"></asp:textbox>
        </div>
       <div class="col-xs-4"></div>
        
    </div>
    <br/>

    
     <div class="row">
       <div class="col-xs-4"></div>
       
        <div class="col-xs-4">
    <label class="grey-text">Your password</label>
             </div>
       <div class="col-xs-4"></div>
        
    </div>  

             <div class="row">
       <div class="col-xs-4"></div>
       
        <div class="col-xs-4">
    <asp:textbox type="password" runat="server" id="txtPassword" class="form-control"></asp:textbox>
             </div>
       <div class="col-xs-4"></div>
        
    </div>
    <br />
    <div class="text-center mt-4">
      
        <asp:linkbutton runat="server" class="btn btn-primary btn-md" type="submit" OnClick="btnLogin_Click">Login</asp:linkbutton>
    </div>
    <br />
     <div class="text-center mt-4">
       
         <p>Not a User?</p>
        
    </div>
    <div class="text-center mt-4">
       
        <asp:linkbutton runat="server" class="btn btn-primary btn-md" type="submit" PostBackUrl="~/Register.aspx">Register</asp:linkbutton>
    </div>

    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>



