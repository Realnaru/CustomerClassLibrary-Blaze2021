<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoteGroupEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.NoteGroupEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Repeater ID="AddressRepeater" runat="server">

        <ItemTemplate>
            <asp:Table runat="server">
                <asp:TableRow>

                    <asp:TableCell>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Note"></asp:Label>
                            <asp:TextBox ID="addressLineRepeater" Text='<%# Eval("Note") %>' CssClass="form-control" runat="server"></asp:TextBox>
                        </div>  

                    </asp:TableCell>

                </asp:TableRow>

            </asp:Table>

        </ItemTemplate>

    </asp:Repeater>


</asp:Content>
