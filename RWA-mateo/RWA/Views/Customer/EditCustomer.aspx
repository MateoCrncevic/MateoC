<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="RWA.WebForms.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    

    <title>Uredite odabranog kupca </title>
</head>
<body>
    <form id="form1" runat="server">

        <table class="table">
            <tr>
                <td>
                   <label>Ime:</label>
                </td>
                <td>
                    <input  runat="server" type="text" id="Ime"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="Molim unesite ime!" ControlToValidate="Ime" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <label>Prezime:</label>
                </td>
                <td>
                    <input runat="server" type="text" id="Prezime"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ErrorMessage="Molim unesite prezime!" ControlToValidate="Ime" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <label>Telefon:</label>
                </td>
                <td>
                     <input runat="server" type="text" id="Telefon"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ErrorMessage="Molim unesite broj telefona!" ControlToValidate="Ime" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <label>Email:</label>
                </td>
                <td>
                    <input runat="server" type="text" id="email" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"   runat="server" ErrorMessage="Molim unesite email adresu!" ControlToValidate="email" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Molim unesite ispravnu E-Mail adresu!" Display="None" ControlToValidate="email"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                   <label>Grad:</label>
                </td>
                <td>
                    <asp:DropDownList  ID="grad" DataValueField="" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Spremi" CssClass="btn-success"/>
                </td>
            </tr>
          
        </table>

        <div>
             <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>

