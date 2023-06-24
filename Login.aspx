<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemDeVot_WebAppl.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    #container {
      text-align: center;
      margin: 0 auto;
    }

    .auto-style1 {
        width: 1179px;
        height: 387px;
    }
    .auto-style11 {
        height: 29px;
        width: 240px;
    }
    .auto-style12 {
        height: 29px;
        width: 241px;
    }
    .auto-style13 {
        height: 31px;
        width: 241px;
        text-align: center;
    }
    .auto-style14 {
        height: 29px;
        width: 241px;
        text-align: right;
    }
    .auto-style16 {
        height: 30px;
        width: 240px;
    }
    .auto-style17 {
        height: 30px;
        width: 241px;
    }
    .auto-style18 {
        height: 30px;
        width: 241px;
        text-align: right;
    }
    .auto-style19 {
        font-size: x-large;
    }
    .auto-style20 {
        height: 31px;
        width: 240px;
    }
    .auto-style21 {
        height: 31px;
        width: 241px;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="auto-style1" align="center">
    <tr>
        <td class="auto-style11">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">
            </td>
        <td class="auto-style21"></td>
        <td class="auto-style13">
            <h3 class="auto-style19">
                <asp:Label ID="Label6" runat="server" Font-Italic="False" ForeColor="#006699" Text="Autentificare"></asp:Label>
            </h3>
        </td>
        <td class="auto-style21"></td>
        <td class="auto-style21"></td>
    </tr>
    <tr>
        <td class="auto-style11">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">&nbsp;</td>
        <td class="auto-style14">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#006699" Text="Utilizator"></asp:Label>
        </td>
        <td class="auto-style12">
            <asp:TextBox ID="TextBox2" runat="server" Width="230px" BorderColor="#006699" Font-Bold="False" TextMode="Email"></asp:TextBox>
        </td>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style12">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11"></td>
        <td class="auto-style14">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#006699" Text="Parola"></asp:Label>
        </td>
        <td class="auto-style12">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="230px" BorderColor="#006699"></asp:TextBox>
        </td>
        <td class="auto-style12"></td>
        <td class="auto-style12"></td>
    </tr>
    <tr>
        <td class="auto-style16">&nbsp;</td>
        <td class="auto-style18">
            &nbsp;</td>
        <td class="auto-style17">
            &nbsp;</td>
        <td class="auto-style17">&nbsp;</td>
        <td class="auto-style17">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style16">&nbsp;</td>
        <td class="auto-style17">&nbsp;</td>
        <td class="auto-style17">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Autentificare" Width="234px" BackColor="#006699" />
        </td>
        <td class="auto-style17">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
        <td class="auto-style17">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style16"></td>
        <td class="auto-style18">&nbsp;</td>
        <td class="auto-style17">&nbsp;</td>
        <td class="auto-style17"></td>
        <td class="auto-style17"></td>
    </tr>
    <tr>
        <td class="auto-style16">&nbsp;</td>
        <td class="auto-style18">
            <asp:Label ID="Label5" runat="server" ForeColor="#CC3300" Text="Nu aveți cont?"></asp:Label>
        </td>
        <td class="auto-style17">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Creați un cont" BackColor="#006699" />
        </td>
        <td class="auto-style17">&nbsp;</td>
        <td class="auto-style17">&nbsp;</td>
    </tr>
</table>


</asp:Content>
