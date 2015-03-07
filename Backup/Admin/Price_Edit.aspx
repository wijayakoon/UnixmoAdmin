<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Price_Edit.aspx.cs" Inherits="Neemo.Admin.Price_Edit" %>
<%@ Register src="../UserControls/ProcessingInProgressPanel.ascx" tagname="processinginprogresspanel" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="left"  style="vertical-align:top;border=0">
        <tr>
            <td align="center" bgcolor="#CCCCCC">
                &nbsp;</td>
            <td align="center" colspan="2" bgcolor="#CCCCCC">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" 
                    style="font-size: large" Text="UPDATE PRICE RATING"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Price Name<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_Name" 
                    ErrorMessage="Name Required" ForeColor="#CC0000" ValidationGroup="save">*</asp:RequiredFieldValidator>
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Name" runat="server" Width="400px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Effective Date From</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_EffectiveDateFrom" runat="server" Width="240px"></asp:TextBox>               
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Effective Date To</td>
            <td bgcolor="#EFEFEF">
               <asp:TextBox ID="TextBox_EffectiveDateTo" runat="server" Width="240px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Status</td>
            <td bgcolor="#EFEFEF">
                <asp:CheckBox ID="CheckBox_Active" runat="server" Text="Active" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Image</td>
            <td bgcolor="#EFEFEF">
                <asp:FileUpload ID="FileUpload_Image" runat="server" />
                <asp:Button ID="btn_Upload" runat="server" onclick="btn_Upload_Click" 
                    Text="Upload" />
                <br />
                <asp:Image ID="Image_Icon" runat="server" Height="30px" Width="30px" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            
                    SelectCommand="SELECT PriceID,Price,Active,Image,EffectiveDateFrom,EffectiveDateTo,CreatedDateTime,DeletedDateTime  FROM [Price] WHERE ([PriceID] = @PriceID)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="PriceID" QueryStringField="PriceID" 
                            DefaultValue="1" />
                    </SelectParameters>
                </asp:SqlDataSource></td>
            <td bgcolor="#EFEFEF">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                       <uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel2" runat="server" />
                                           
                                           </ProgressTemplate>
                </asp:UpdateProgress>
                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button_Save" runat="server" Text="Save" 
                            ValidationGroup="save" onclick="Button_Save_Click" />
                        &nbsp;<asp:Button ID="Button_Reset" runat="server" onclick="Button_Reset_Click" 
                            Text="Reset" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button_Save" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="save" />
               
            </td>
        </tr>
    </table>
</asp:Content>
