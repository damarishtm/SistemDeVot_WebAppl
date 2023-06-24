<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Candidati.aspx.cs" Inherits="SistemDeVot_WebAppl.Candidati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 1177px;
        height: 393px;
    }
    .auto-style6 {
        height: 26px;
        width: 265px;
    }
    .auto-style7 {
        height: 26px;
        width: 266px;
    }
    .auto-style9 {
            height: 26px;
            width: 429px;
        }
    .auto-style10 {
            height: 26px;
            text-align: right;
            width: 429px;
        }
    .auto-style11 {
            height: 28px;
            width: 429px;
        }
    .auto-style12 {
        height: 28px;
        width: 265px;
    }
    .auto-style13 {
        height: 28px;
        width: 266px;
    }
    .auto-style17 {
        height: 26px;
        text-align: left;
            width: 429px;
        }
        .auto-style18 {
            height: 28px;
            width: 639px;
            text-align: right;
        }
        .auto-style19 {
        height: 26px;
        width: 102px;
    }
        .auto-style20 {
        height: 28px;
        width: 102px;
    }
        .auto-style21 {
        height: 26px;
        width: 639px;
    }
        .auto-style22 {
            height: 28px;
            width: 639px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" align="center">
    <tr>
        <td class="auto-style9"></td>
        <td class="auto-style19"></td>
        <td class="auto-style21">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Black" Text="&nbsp;&nbsp;Alege candidatul dorit și votează!"></asp:Label>
        </td>
        <td class="auto-style6"></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style17">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="148px" Width="366px" BorderColor="#006699">
            </asp:RadioButtonList>
        </td>
        <td class="auto-style19">&nbsp;</td>
        <td class="auto-style21">
            &nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Trimite votul" Width="191px" BackColor="#006699" />
        </td>
        <td class="auto-style19">
            </td>
        <td class="auto-style21"></td>
        <td class="auto-style6"></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style10">&nbsp;</td>
        <td class="auto-style19">&nbsp;</td>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:Label ID="Label" runat="server"></asp:Label>
        </td>
        <td class="auto-style20">
            &nbsp;</td>
        <td class="auto-style22"></td>
        <td class="auto-style12"></td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style9"></td>
        <td class="auto-style19"></td>
        <td class="auto-style21"></td>
        <td class="auto-style6"></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style11"></td>
        <td class="auto-style20">&nbsp;</td>
        <td class="auto-style18">
            <asp:Button ID="ButtonRezultate" runat="server" OnClick="ButtonRezultate_Click" Text="Vezi Rezultate" />
        </td>
        <td class="auto-style12">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Log out" Width="170px" BackColor="White" BorderColor="#CC0000" />
        </td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style19">&nbsp;</td>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
</table>
</asp:Content>
