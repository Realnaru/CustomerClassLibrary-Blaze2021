<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="CustomerClassLibrary.WebForms.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customer service page</h1>
    <a class="btn btn-lg btn-primary" href ="CustomerList">Load customers</a>
    <a class="btn btn-lg btn-primary" href ="AddCustomer">Add new customer</a>
</asp:Content>
