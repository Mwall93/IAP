<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />


</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">
   

        <div class="container-fluid">
           <p class="h4 text-center mb-4">Register!</p>
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
                     <asp:textbox  runat="server" id="txtConfirmPassword" class="form-control"></asp:textbox>
                 </div>
                 <div class="col-xs-4"></div>
             </div>

            <br />

            <div class="row">
                 <div  class="text-center mt-4">
                    <asp:Button ID="btnRegister" class="btn btn-primary btn-md" runat="server"  Text="Register!" OnClick="btnRegister_Click" />
                 
                 </div>
            </div>  

            <div class="row">
                 <div class="col-xs-4"></div>
                 <div class="col-xs-4">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                 </div>
                 <div class="col-xs-4"></div>
            </div>
     </div>

</asp:Content>



