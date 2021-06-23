<%@ Page Title="CustomerList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerClassLibrary.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <tr><th>Customer table</th></tr>
        <tr><th>Id</th><th>First name</th><th>Last name</th><th>Phone Number</th><th>Email</th></tr>
        <% foreach (var customer in Customers)
            { %>

            <tr><td><a href="CountryEdit?countryCode=<%= customer.CustomerId %>"><%= customer.CustomerId %></a></td><td><%= customer.FirstName %></td>
                <td><%= customer.LastName %></td><td><%= customer.PhoneNumber %></td><td><%= customer.Email %></td>
            </tr> 
        <%} %>
    </table>
</asp:Content>
