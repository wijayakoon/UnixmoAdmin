
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Neemo.Admin.Login" %>


<%@ Register src="../UserControls/ProcessingInProgressPanel.ascx" tagname="ProcessingInProgressPanel" tagprefix="uc1" %>
<%@ Register src="../UserControls/UC_Login.ascx" tagname="UC_Login" tagprefix="uc2" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="td_Table_footer" style="">
        <tr>
            <td height="500" valign="top" class="style1">
                <table width="95%" border="0" align="center" cellpadding="5" cellspacing="0">
                    <tr>
                        <td height="50" align="left" valign="bottom" class="title_text_Blue">
                            <span class="style1"><strong>Admin </strong></span> <span class="title_text_Orange">
                            <span class="style1"><strong>Login</strong></span></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_Dot_Hor">
                            <img src="../images/1x1.gif" width="1" height="1" />
                            <uc2:UC_Login ID="UC_Login1" runat="server" />
                        </td>
                    </tr>
                </table>
                <table width="94%" border="0" align="center" cellpadding="5" cellspacing="0">
                    <tr>
                        <td align="left" valign="top" class="body_text">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="body_text">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
