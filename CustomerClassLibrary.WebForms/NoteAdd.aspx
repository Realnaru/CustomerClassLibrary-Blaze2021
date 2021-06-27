<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteAdd.aspx.cs" Inherits="CustomerClassLibrary.WebForms.NoteAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add customer note</h1>

<div class="form-group">
    <asp:Label runat="server" Text="Note"></asp:Label>
    <asp:TextBox ID="noteText" CssClass="form-control" runat="server"></asp:TextBox>
</div>  

<asp:Button runat="server" CssClass="btn btn-primary btn-lg" 
    OnClick="OnAddClick" 
    Text="Add" />

</asp:Content>
