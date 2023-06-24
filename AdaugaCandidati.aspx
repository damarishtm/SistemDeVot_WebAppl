<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdaugaCandidati.aspx.cs" Inherits="SistemDeVot_WebAppl.AdaugaCandidati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1180px;
            height: 437px;
        }
        .auto-style5 {
            height: 26px;
            width: 257px;
        }
        .auto-style19 {
            height: 26px;
            width: 260px;
            text-align: right;
        }
        .auto-style21 {
            height: 26px;
            width: 257px;
            text-align: center;
        }
        .auto-style22 {
            height: 26px;
            width: 257px;
            text-align: right;
        }
    .auto-style23 {
        font-size: x-large;
    }
        .auto-style24 {
            height: 26px;
            width: 150px;
        }
        .auto-style25 {
            width: 150px;
        }
        .buton-style{
            backColor:#006699;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="auto-style1" align="center">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style21"><strong>
                <asp:Label ID="Label4" runat="server" Text="Adaugă candidat" CssClass="auto-style23" ForeColor="Black"></asp:Label>
                </strong></td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style19">
                <asp:Label ID="Label1" runat="server" Text="Nume" Font-Bold="True" Font-Size="Medium" ForeColor="#006699"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="#006699" BorderStyle="Outset" Height="25px" Width="181px"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style19">
                </td>
            <td class="auto-style19">
                <asp:Label ID="Label2" runat="server" Text="Varsta" CssClass="auto-style21" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" BorderColor="#006699" BorderStyle="Outset" Height="25px" MaxLength="2" Width="181px"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
            <td class="auto-style24"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style22">
                &nbsp;</td>
            <td class="auto-style19">
                <asp:Label ID="Label3" runat="server" Text="Partid" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" BorderColor="#006699" BorderStyle="Outset" Height="25px" Width="181px"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style25">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style21">
                <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="Adauga" Width="143px" BackColor="#006699" />
            </td>
            <td class="auto-style5">
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td class="auto-style24"></td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
            <td class="auto-style21">
            </td>
            <td class="auto-style5">
            </td>
            <td class="auto-style24"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style22">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
