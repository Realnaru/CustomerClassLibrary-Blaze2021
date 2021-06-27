<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit customer</h1>

    <div class="row">
        <div class="col-lg-3">

    <div class="form-group">
    </div>  
            
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
        <asp:Label runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="purchaseAmount" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <asp:TextBox ID="id" CssClass="form-control" type="hidden" runat="server"></asp:TextBox>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />

        </div>

    <div class="col-lg-9">

        <table class="table">
        <tr><th>Address line</th><th>Address line 2</th><th>Address type</th><th>City</th><th>Postal code</th>
            <th>State</th><th>Country</th><th class="text-center" colspan="2">Actions</th>
        </tr>
        <% foreach (var address in Addresses) %>
         <%   { %>
            <tr>
                <td><%= address.AdressLine %></td>
                <td><%= address.AdressLine2 %></td>
                <td><%= address.AddressType %></td>
                <td><%= address.City %></td>
                <td><%= address.PostalCode %></td>
                <td><%= address.State %></td>
                <td><%= address.Country %></td>
                <td><a  href="AddressEdit?addressId=<%= address.AddressId %>">Edit</a></td>
                <td><a  href="AddressDelete?addressId=<%= address.AddressId %>">Delete</a></td>
            </tr> 
        <%} %>
            <tr>
                <td class="text-right" colspan="9"><a class="btn btn-primary" href="AddressGroupEdit?customerId=<%= CustomerId %>">Edit all</a>
                                                   <a class="btn btn-primary" href="AddressAdd?customerId=<%= CustomerId %>">Add address</a>
            </td>
            </tr>
    </table>

        <div class="row">
            <div class =" col-lg-8">

                 <table class="table">
        <tr><th>Note</th><th class="text-center" colspan="2">Actions</th>
        </tr>
        <% foreach (var note in Notes) %>
          <%  { %>
            <tr>
                <td width="70%"><%= note.Note %></td>
                
                <td class="text-center" width="10%"><a  href="NoteEdit?noteId=<%= note.NoteId %>">Edit</a></td>
                <td class="text-center" width="10%"><a  href="NoteDelete?noteId=<%= note.NoteId %>">Delete</a></td>
            </tr> 
        <%} %>

            <tr>
                <td class="text-right" colspan="3"><a class="btn btn-primary" href="NoteGroupEdit?customerId=<%= CustomerId %>">Edit all</a>
                                                   <a class="btn btn-primary" href="NoteAdd?customerId=<%= CustomerId %>">Add note</a>
            </td>
            </tr>
            
    </table>
               
            </div>

        </div>
       
    </div>

    </div>

</asp:Content>
