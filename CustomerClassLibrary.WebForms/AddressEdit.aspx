<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddressEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit address</h1>

    <div class="row">
        <div class="col-lg-12">

    <div class="form-group">
    </div>  
            
    <div class="form-group">
        <asp:Label runat="server" Text="Address line"></asp:Label>
        <asp:TextBox ID="addressLine" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="addressLineError" runat="server" Text=""></asp:Label>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Address line 2"></asp:Label>
        <asp:TextBox ID="line2" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="addressLine2error" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Address type"></asp:Label>
        <asp:TextBox ID="addressType" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="addressTypeError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="cityError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Postal code"></asp:Label>
        <asp:TextBox ID="postalCode" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="postalCodeError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="State"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="stateError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Country"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label CssClass="text-danger" ID="countryError" runat="server" Text=""></asp:Label>
     </div>

        </div>

    </div>

    <asp:Button runat="server" CssClass="btn btn-primary btn-lg" 
        OnClick="OnSaveClick" 
        Text="Save" />

</asp:Content>
