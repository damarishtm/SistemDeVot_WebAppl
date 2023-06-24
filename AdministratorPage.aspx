<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="SistemDeVot_WebAppl.EditeazaListaCandidati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1180px;
            height: 469px;
        }
        .auto-style6 {
            height: 26px;
            width: 321px;
        }
        .auto-style7 {
            height: 26px;
            width: 322px;
        }
        .auto-style8 {
            height: 26px;
            width: 321px;
            text-align: right;
            color: #660033;
            font-size: x-large;
        }
        .auto-style9 {
            height: 27px;
            width: 321px;
        }
        .auto-style10 {
            height: 27px;
            width: 322px;
        }
    .auto-style11 {
        height: 24px;
        width: 321px;
    }
    .auto-style12 {
        height: 24px;
        width: 322px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" align="center">
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="Pagina administrator"></asp:Label>
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="Button1" runat="server" Text="Seteaza perioada alegeri" Width="350px" BackColor="#006699" Height="60px" OnClick="Button1_Click" />
            </td>
            <td class="auto-style6">
                <asp:Calendar ID="CalendarStart" runat="server" Visible="False"></asp:Calendar>
            </td>
            <td class="auto-style6">
                <asp:Calendar ID="CalendarEnd" runat="server" Visible="False"></asp:Calendar>
            </td>
            <td class="auto-style7">
                <asp:Label ID="LabelCurrentPeriod" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Button ID="ButtonAddPeriod" runat="server" OnClick="ButtonAddPeriod_Click" Text="Adauga" Width="92px" BorderColor="#0000CC" Visible="False" />
                <asp:Button ID="ButtonRemoveActivePeriod" runat="server" OnClick="ButtonRemoveActivePeriod_Click" Text="Dezactiveaza" Width="92px" BorderColor="#0000CC" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Editeaza lista candidati" Width="350px" BackColor="#006699" Height="60px" />
            </td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style9">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="Button3" runat="server" Text="Rezultate vot" Width="350px" OnClick="Button3_Click" BackColor="#006699" Height="60px" />
            </td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style11"></td>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Log out" Width="148px" BorderColor="#CC0000" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
