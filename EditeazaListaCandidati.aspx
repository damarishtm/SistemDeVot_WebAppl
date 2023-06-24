<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditeazaListaCandidati.aspx.cs" Inherits="SistemDeVot_WebAppl.AdministratorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1172px;
            height: 578px;
        }
        .auto-style6 {
            height: 26px;
            width: 226px;
        }
        .auto-style7 {
            height: 26px;
            width: 227px;
        }
        .auto-style8 {
            height: 32px;
            width: 226px;
        }
        .auto-style9 {
            height: 32px;
            width: 227px;
        }
        .auto-style10 {
            margin-left: 0px;
            margin-top: 0px;
        }
        .auto-style11 {
            height: 26px;
            width: 139px;
        }
        .auto-style12 {
            height: 32px;
            width: 139px;
        }
        .auto-style13 {
            height: 26px;
            width: 260px;
        }
        .auto-style14 {
            height: 32px;
            width: 260px;
            text-align: center;
        }
        .auto-style15 {
            height: 22px;
            width: 226px;
        }
        .auto-style16 {
            height: 22px;
            width: 139px;
        }
        .auto-style17 {
            height: 22px;
            width: 260px;
        }
        .auto-style18 {
            height: 22px;
            width: 227px;
        }
        .auto-style19 {
            height: 26px;
            width: 260px;
            text-align: right;
        }
        .auto-style20 {
            height: 26px;
            width: 260px;
            text-align: center;
        }
        .auto-style21 {
            height: 26px;
            width: 260px;
            text-align: right;
            font-size: x-large;
            color: #660033;
        }
    .auto-style22 {
        height: 27px;
        width: 226px;
    }
    .auto-style23 {
        height: 27px;
        width: 139px;
    }
    .auto-style24 {
        height: 27px;
        width: 260px;
    }
    .auto-style25 {
        height: 27px;
        width: 227px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" align="center">
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style21">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="Listă candidați"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Inapoi" Width="92px" BorderColor="#CC0000" style="height: 26px" />
            </td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style23"></td>
            <td class="auto-style24">
                <asp:Label ID="LabelPerioada" runat="server" Text="Perioada:"></asp:Label>
            </td>
            <td class="auto-style25"></td>
            <td class="auto-style25"></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style20">
                <asp:DropDownList ID="DropDownPeriodList" runat="server" Height="16px" Width="260px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style11"></td>
            <td class="auto-style13">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="182px" Width="390px" BorderColor="#006699">
                </asp:RadioButtonList>
            </td>
            <td class="auto-style7"></td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style11"></td>
            <td class="auto-style13"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style12"></td>
            <td class="auto-style14">
                <asp:Button ID="Button4" runat="server" CssClass="auto-style10" OnClick="Button4_Click" Text="Sterge" Width="126px" Height="30px" BackColor="#006699" Visible="False" />
                <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="Adauga" Width="103px" BackColor="#006699" Visible="False" />
            </td>
            <td class="auto-style9"></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style15"></td>
            <td class="auto-style16"></td>
            <td class="auto-style17"></td>
            <td class="auto-style18"></td>
            <td class="auto-style18">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style11"></td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style11"></td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style7"></td>
            <td class="auto-style7">
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Log out" Width="89px" BorderColor="#CC0000" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style11"></td>
            <td class="auto-style13"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
