<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressGroupEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddressGroupEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater ID="addressRepeater" runat="server">
        <ItemTemplate>

            <asp:Table runat="server">

                <asp:TableRow>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address line"></asp:Label>
                            <asp:TextBox ID="addressLineRepeater" Text='<%# Eval("AdressLine") %>' CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div>  
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address line2"></asp:Label>
                            <asp:TextBox ID="addressLine2Repeater" Text='<%# Eval("AdressLine2") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Address type"></asp:Label>
                            <asp:TextBox ID="addressTypeRepeater" Text='<%# Eval("AdressLine2") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="cityRepeater" Text='<%# Eval("City") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Postal code"></asp:Label>
                            <asp:TextBox ID="postalcodeRepeater" Text='<%# Eval("PostalCode") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="State"></asp:Label>
                            <asp:TextBox ID="stateRepeater" Text='<%# Eval("State") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    <asp:TableCell>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Country"></asp:Label>
                            <asp:TextBox ID="countryRepeater" Text='<%# Eval("Country") %>'  CssClass="form-control" Width="95%" runat="server"></asp:TextBox>
                        </div> 
                    </asp:TableCell> 
                    
                </asp:TableRow>
            </asp:Table>
             </ItemTemplate>
    </asp:Repeater>

</asp:Content>
