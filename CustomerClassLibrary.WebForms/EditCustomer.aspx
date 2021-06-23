<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="CustomerClassLibrary.WebForms.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit customer</h1>

    <div class="row">
        <div class="col-lg-6">
             <div class="form-group">
    <asp:Label runat="server" Text="First name"></asp:Label>
    <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Last name"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Phone number"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Note"></asp:Label>
        <asp:TextBox ID="note" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

        </div>

        <div class="col-lg-6">

            <div class="form-group">
    <asp:Label runat="server" Text="Address line"></asp:Label>
    <asp:TextBox ID="addressLine" CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Address line 2"></asp:Label>
        <asp:TextBox ID="addressLine2" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Address type"></asp:Label>
        <asp:TextBox ID="addressType" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
     </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Postal code"></asp:Label>
        <asp:TextBox ID="postalcode" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

     <div class="form-group">
        <asp:Label runat="server" Text="State"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

     <div class="form-group">
        <asp:Label runat="server" Text="Country"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
     </div>
        </div>

    </div>
</asp:Content>
