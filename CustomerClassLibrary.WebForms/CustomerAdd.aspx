<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerAdd.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add new customer</h1>

    <div class="row">
        <div class="col-lg-6">
             <div class="form-group">
    <asp:Label runat="server" Text="First name"></asp:Label>
    <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
    
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Last name"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lastNameError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Phone number"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="phoneNumberError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="emailError" runat="server" Text=""></asp:Label>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Total purchase amount"></asp:Label>
        <asp:TextBox ID="purchaseAmount" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Note"></asp:Label>
        <asp:TextBox ID="note" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="noteError" runat="server" Text=""></asp:Label>
     </div>

        </div>

        <div class="col-lg-6">

            <div class="form-group">
    <asp:Label runat="server" Text="Address line"></asp:Label>
    <asp:TextBox ID="addressLine" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="addressLineError" runat="server" Text=""></asp:Label>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Address line 2"></asp:Label>
        <asp:TextBox ID="addressLine2" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

     <div class="form-group">
        <asp:Label runat="server" Text="Address type"></asp:Label>
        <asp:TextBox ID="addressType" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="addressTypeError" runat="server" Text=""></asp:Label>   
     </div>

    <div class="form-group">
        <asp:Label runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="cityError" runat="server" Text=""></asp:Label>
     </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Postal code"></asp:Label>
        <asp:TextBox ID="postalcode" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="postalcodeError" runat="server" Text=""></asp:Label>
     </div>

     <div class="form-group">
        <asp:Label runat="server" Text="State"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label ID="stateError" runat="server" Text=""></asp:Label>
     </div>

     <div class="form-group">
        <asp:Label runat="server" Text="Country"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label ID="countryError" runat="server" Text=""></asp:Label>
     </div>
        </div>

    </div>

    <asp:Button runat="server" CssClass="btn btn-primary btn-lg" 
                OnClick="OnAddClick" 
                Text="Save" />
</asp:Content>
