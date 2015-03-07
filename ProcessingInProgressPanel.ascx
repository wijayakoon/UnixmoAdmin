<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProcessingInProgressPanel.ascx.cs" Inherits="NeemoAdmin.ProcessingInProgressPanel" %>

                           
                                <table style="border: 1px solid #333333; font-weight: bold; font-size: 10pt; width: 202px;
                                    font-family: arial; position: relative; height: 30px; background-color: #CCCCCC;
                                    left: 1px; top: 0px;">
                                    <tr>
                                        <td style="width: 24px; height: 1px">
                                        </td>
                                        <td style="width: 58px; height: 1px">
                                        </td>
                                        <td class="style1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 24px; height: 32px">
                                        </td>
                                        <td style="width: 58px; height: 32px">
                                            <img src="/images/loading.gif" />
                                        </td>
                                        <td class="style2">
                                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Please wait....." Width="125px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                </table>
   