<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressGroupEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddressGroupEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit all addresses</h1>

    <asp:Repeater ID="addressRepeater" runat="server">
        <ItemTemplate>

            <asp:Table runat="server">

                <asp:TableRow>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:HiddenField ID="addressId" Value='<%# Eval("AddressId") %>' runat="server"></asp:HiddenField>
                        </div>  
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address line"></asp:Label>
                            <asp:TextBox ID="addressLine" Text='<%# Eval("AdressLine") %>' CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div>  
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address line2"></asp:Label>
                            <asp:TextBox ID="addressLine2" Text='<%# Eval("AdressLine2") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address type"></asp:Label>
                            <asp:TextBox ID="addressType" Text='<%# Eval("AddressType") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="city" Text='<%# Eval("City") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Postal code"></asp:Label>
                            <asp:TextBox ID="postalCode" Text='<%# Eval("PostalCode") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="State"></asp:Label>
                            <asp:TextBox ID="state" Text='<%# Eval("State") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Country"></asp:Label>
                            <asp:TextBox ID="country" Text='<%# Eval("Country") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    
                </asp:TableRow>
            </asp:Table>

             </ItemTemplate>
    </asp:Repeater>
            <asp:Button runat="server" CssClass="btn btn-primary btn-lg" 
            OnClick="OnSaveClick"
            Text="Save" />
</asp:Content>
