<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsCustomers.Default" %>
<%@ MasterType VirtualPath="SiteMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="border floatleft">
        <asp:Repeater runat="server" ID="myRepeater">
            <HeaderTemplate>
                <table class="tblCustomers">
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>Email</th>
                        <th>&nbsp</th>

                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval(expression:"Name") %></td>
                    <td><%# Eval(expression:"Surname") %></td>
                    <td><%# Eval(expression:"Email") %></td>
                    <td>
                        <asp:LinkButton  runat="server" Id="btnPickCustomer" OnClick="btnPickCustomer_OnClick"  CommandArgument='<%#Eval(expression:"IdCustomer") %>' >Odaberi</asp:LinkButton>
                    </td>
                </tr>


            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>


</asp:Content>
