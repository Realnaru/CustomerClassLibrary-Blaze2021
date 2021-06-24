<%@ Page Title="CustomerList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerClassLibrary.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <tr><th>Customer list</th></tr>
        <tr><th>First name</th><th>Last name</th><th>Phone Number</th><th>Email</th><th>Total purchase amount</th</tr>
        <% foreach (var customer in Customers)
            { %>
            <tr>
                <td><%= customer.FirstName %></td>
                <td><%= customer.LastName %></td>
                <td><%= customer.PhoneNumber %></td>
                <td><%= customer.Email %></td>
                <td><%= customer.TotalPurshasesAmount %></td>
                <td><a class="btn btn-primary" href="CustomerEdit?customerId=<%= customer.CustomerId %>">Edit</a></td>
                <td><a class="btn btn-primary" href="CustomerDelete?customerId=<%= customer.CustomerId %>">Delete</a></td>
            </tr> 
        <%} %>
    </table>
    <a class="btn btn-lg btn-primary" href ="AddCustomer">Add new customer</a>
</asp:Content>
