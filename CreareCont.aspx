<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreareCont.aspx.cs" Inherits="SistemDeVot_WebAppl.CreareCont" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 1175px;
        height: 393px;
    }
    .auto-style8 {
        width: 238px;
        height: 26px;
    }
    .auto-style9 {
        width: 239px;
        height: 26px;
    }
    .auto-style10 {
        width: 238px;
        height: 26px;
        text-align: right;
    }
        .auto-style12 {
            width: 238px;
            height: 27px;
            text-align: center;
            font-size: x-large;
        }
        .auto-style13 {
            width: 238px;
            height: 27px;
        }
        .auto-style14 {
            width: 239px;
            height: 27px;
        }
        .auto-style15 {
            width: 238px;
            height: 26px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" align="center">
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13"></td>
        <td class="auto-style13"></td>
        <td class="auto-style12"><strong>Creare cont</strong></td>
        <td class="auto-style14"></td>
        <td class="auto-style14"></td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label3" runat="server" Text="Adresa e-mail" Font-Bold="True" ForeColor="#006699"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="TextBox1" runat="server" Width="300px" Height="30px" TextMode="Email" BorderColor="#006699"></asp:TextBox>
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label5" runat="server" Text="Nume" Font-Bold="True" ForeColor="#006699"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="TextBoxNume" runat="server" Width="300px" Height="30px" BorderColor="#006699"></asp:TextBox>
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style10">
            &nbsp;</td>
        <td class="auto-style8">
            <asp:CheckBox ID="CheckBox18Ani" runat="server" Text="Confirm ca am peste 18 ani" />
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8"></td>
        <td class="auto-style8"></td>
        <td class="auto-style15">
            &nbsp;</td>
        <td class="auto-style9"></td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label4" runat="server" Text="Parola" Font-Bold="True" ForeColor="#006699"></asp:Label>
        </td>
        <td class="auto-style15">
            <asp:TextBox ID="TextBox2" runat="server" Width="300px" Height="30px" TextMode="Password" BorderColor="#006699"></asp:TextBox>
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style10">
            <asp:Label ID="Label2" runat="server" Text="Confirmare parola" Font-Bold="True" ForeColor="#006699"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="TextBox3" runat="server" Width="300px" Height="30px" TextMode="Password" BorderColor="#006699"></asp:TextBox>
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Creaza cont" Height="33px" Width="197px" BackColor="#006699" />
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
</table>
</asp:Content>
