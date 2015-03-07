<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Login.ascx.cs" Inherits="Neemo.UserControls.UC_Login" %>
<%@ Register src="/UserControls/ProcessingInProgressPanel.ascx" tagname="ProcessingInProgressPanel" tagprefix="uc1" %>

<script language=javascript>
    function AnyInput_KeyDown(e, target) {
        if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
            __doPostBack(target, '');
            return false;
        }
        return true;
    }
</script>
                <table width="94%" border="0" align="center" cellpadding="5" cellspacing="0">
                    <tr>
                        <td align="left" valign="top" class="body_text">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="body_text">
                        <asp:Panel id="panel1" runat="server" DefaultButton="btn_Login" >
                            <table border="0" align="center" cellpadding="6" cellspacing="0" 
                                style="width: 447px">
                                <tr>
                                    <td width="115" height="15" align="left">
                                        Email Address
                                    </td>
                                    <td height="15" align="center" style="width: 12px">
                                        :
                                    </td>
                                    <td height="15" width="150">
                                        <asp:TextBox ID="txt_Email" runat="server" CssClass="form_style_1" 
                                            Width="200px" ValidationGroup="ValidateLogin"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txt_Email" ErrorMessage="Please type your email address" 
                                            ForeColor="Red" ValidationGroup="ValidateLogin">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txt_Email" ErrorMessage="Please Enter a valid Email address" 
                                            ForeColor="#990000" SetFocusOnError="True" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            ValidationGroup="ValidateLogin">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15" align="left">
                                        Password
                                    </td>
                                    <td height="15" align="center" style="width: 12px">
                                        :
                                    </td>
                                    <td height="15" width="150">
                                        <asp:TextBox ID="txt_Password" runat="server" CssClass="form_style_1" 
                                            Width="200px" TextMode="Password" ValidationGroup="ValidateLogin"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txt_Password" ErrorMessage="Please enter your Password" 
                                            ForeColor="Red" ValidationGroup="ValidateLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                </table>
                                <table border="0" align="center" cellpadding="6" cellspacing="0" 
                    style="width: 447px">
                                <tr>
                                    <td height="15" align="center" valign="top">
                                        <table border="0" cellspacing="0" cellpadding="2">
                                            <tr>
                                                <td colspan="5" style="text-align: left">
                                                    <asp:Label ID="lbl_Warning" runat="server" ForeColor="#CC3300"></asp:Label>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValidateLogin" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan=5 style="text-align: left">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                        <ProgressTemplate>
                                                            <uc1:processinginprogresspanel id="ProcessingInProgressPanel1" runat="server" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                            <asp:Button ID="btn_Login" runat="server" 
                                                        CssClass="form_button_xpStyle" OnClick="btn_Login_Click" onkeydown="AnyInput_KeyDown(event,'btnSearch');"
                                                                Text="Login" ValidationGroup="ValidateLogin" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_Reset" runat="server" CssClass="form_button_xpStyle" 
                                                                Text="Reset" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btn_Login" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <span class="arrow_Orange">» </span><a href="ForgotPassword.aspx" class="body_text_Blue">Forgot Password?</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <span class="arrow_Orange">» </span><a href="Registration.aspx" class="body_text_Blue">
                                                        New customer</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                        </td>
                        
                    </tr>
                </table>
                            
            