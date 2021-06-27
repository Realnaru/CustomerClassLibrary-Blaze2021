<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.NoteEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit customer note</h1>

<div class="form-group">
    <asp:Label runat="server" Text="Note"></asp:Label>
    <asp:TextBox ID="noteText" CssClass="form-control" runat="server"></asp:TextBox>
</div>  

<asp:Button runat="server" CssClass="btn btn-primary btn-lg" 
    OnClick="OnSaveClick" 
    Text="Save" />

</asp:Content>
