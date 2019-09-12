<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>--%>
<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>
<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="Styles/Master.css" rel="stylesheet" />
        
   
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="formPlaceHolder">

  
        
    
    <asp:GridView ID="GridView1"  class="table table-hover table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="544px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="View Order Details" />
            <asp:BoundField DataField="Id" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
         
            <asp:BoundField DataField="totalCost" HeaderText="Total Cost" SortExpression="totalCost" />
            <asp:BoundField DataField="date" HeaderText="Date Ordered" SortExpression="date" DataFormatString="{0:d}" />
        </Columns>
    </asp:GridView>

    <asp:Table ID = "tblOrderItems" class="table table-hover table-striped" runat = "server" Width = "100%" >
     
        <asp:TableRow >
      
            <asp:TableCell > Item </asp:TableCell >
           
            <asp:TableCell > Quantity </asp:TableCell >
                
            <asp:TableCell > Cost (each)</asp:TableCell >
            
            
         </asp:TableRow >
    </asp:Table>
    <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
        

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyRestaurant %>" SelectCommand="SELECT * FROM [Order] WHERE ([userId] = @userId)">
        <SelectParameters>
            <asp:SessionParameter Name="userId" SessionField="Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>



