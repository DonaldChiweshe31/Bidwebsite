<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Secure.aspx.cs" Inherits="BidWebsite.Secure1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 19px;
            width: 71px;
        }
        .auto-style4 {
            width: 71px;
        }
        .auto-style7 {
            height: 19px;
            width: 229px;
        }
        .auto-style8 {
            width: 229px;
        }
        .auto-style9 {
            height: 19px;
            width: 283px;
        }
        .auto-style10 {
            width: 283px;
        }
        .auto-style11 {
            height: 23px;
            width: 71px;
            text-align: left;
        }
        .auto-style12 {
            height: 23px;
            width: 283px;
        }
        .auto-style13 {
            height: 23px;
            width: 229px;
        }
        .auto-style17 {
            height: 21px;
            width: 71px;
            text-align: left;
        }
        .auto-style18 {
            height: 21px;
            width: 283px;
        }
        .auto-style19 {
            height: 21px;
            width: 229px;
        }
        .auto-style20 {
            height: 19px;
        }
        .auto-style23 {
            height: 19px;
            width: 426px;
        }
        .auto-style24 {
            width: 426px;
            height: 26px;
        }
        .auto-style25 {
            height: 19px;
            width: 404px;
        }
        .auto-style26 {
            width: 404px;
            height: 26px;
        }
        .auto-style27 {
            height: 19px;
            width: 229px;
            text-align: center;
        }
        .auto-style28 {
            height: 19px;
            width: 71px;
            text-align: left;
        }
        .auto-style29 {
            margin-left: 0px;
        }
        .auto-style30 {
            height: 19px;
            width: 241px;
        }
        .auto-style31 {
            width: 241px;
            height: 26px;
        }
        .auto-style32 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style28">&nbsp;
                    <asp:Label ID="lblMail" runat="server" Text="User Mail:*"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="188px" TextMode="Email"></asp:TextBox>
                    &nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style9">&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="18px" Text="Get  Security Question" OnClick="Button1_Click" />
                    &nbsp;</td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;<asp:Label ID="lblQuestion" runat="server" Text="Question:*"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </td>
                <td class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style17">
                    <br />
                    <asp:Label ID="lblAnswer" runat="server" Text="Answer: *"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtAns" runat="server" CssClass="auto-style29" Width="190px" TextMode="Number"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="vldNoAns" runat="server" ControlToValidate="txtAns" ErrorMessage="No Answer"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
        </table>
        &nbsp;<table class="auto-style1">
            <tr>
                <td class="auto-style30">
                    <asp:Label ID="lblNewPass" runat="server" Text="New Password : *"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style23">
                    <asp:TextBox ID="txtNPass" runat="server" TextMode="Password" Width="187px"></asp:TextBox>
                </td>
                <td class="auto-style25">
                    <asp:RequiredFieldValidator ID="vldNoNPass" runat="server" ControlToValidate="txtNPass" ErrorMessage="No New Password"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style30"></td>
                <td class="auto-style23"></td>
                <td class="auto-style25"></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style31">
                    <asp:Label ID="lblPass2" runat="server" Text="Re-Enter Password : *"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:TextBox ID="txtRPass" runat="server" Width="199px" OnTextChanged="txtRPass_TextChanged" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style26">
                    <asp:RequiredFieldValidator ID="vldNoRPass" runat="server" ControlToValidate="txtRPass" ErrorMessage="No Password"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style32"></td>
            </tr>
            <tr>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style23">
                    <asp:Button ID="btnOk" runat="server" Text="Change Password" OnClick="btnOk_Click" />
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style20"></td>
            </tr>
        </table>
   
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
