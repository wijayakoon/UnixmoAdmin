<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Vehicle_New.aspx.cs" Inherits="NeemoAdmin.Vehicle_New" %>
<%@ Register src="~/ProcessingInProgressPanel.ascx" tagname="ProcessingInProgressPanel" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="left"  style="vertical-align:top; width: 828px;">
        <tr>
            <td align="center" bgcolor="#CCCCCC">
                &nbsp;</td>
            <td align="center" colspan="2" bgcolor="#CCCCCC">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" 
                    style="font-size: large" Text="ADD PART"></asp:Label>
            </td>
            <td align="center" bgcolor="#CCCCCC">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Make</td>
            <td bgcolor="#EFEFEF">
                <asp:DropDownList ID="drp_Make" runat="server" 
                    DataSourceID="SqlDataSource_Make" DataTextField="Make" 
                    DataValueField="MakeID">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Make" runat="server" 
                    ErrorMessage="Make Required" ControlToValidate="drp_Make" 
                    ToolTip="Please Select Make">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource_Make" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="Select 0 MakeID,' Please Select Make' Make, 1 Active Union SELECT [MakeID], [Make], Active FROM [Make] WHERE ([Active] = @Active) order by 2">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="btn_SearchMake" runat="server" Text="Filter" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Model</td>
            <td bgcolor="#EFEFEF">
                <asp:DropDownList ID="drp_Model" runat="server" 
                    DataSourceID="SqlDataSource_Model" DataTextField="Model" 
                    DataValueField="ModelID">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Model" runat="server" 
                    ErrorMessage="Model  Required" ControlToValidate="drp_Model" 
                    ToolTip="Please select Model">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource_Model" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="Select 0 ModelID,' Please Select Model' Model, 1 Active Union SELECT [ModelID], [Model], [Active] FROM [Model] WHERE ([Active] = @Active) order by 2">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Model" runat="server"></asp:TextBox>
                <asp:Button ID="btn_SearchModel" runat="server" Text="Filter" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Badge</td>
            <td bgcolor="#EFEFEF">
                <asp:DropDownList ID="drp_Badge" runat="server" 
                    DataSourceID="SqlDataSource_Badge" DataTextField="Badge" 
                    DataValueField="BadgeID">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Badge" runat="server" 
                    ErrorMessage="Badge  Required" ControlToValidate="drp_Badge" 
                    ToolTip="Please Select badge">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource_Badge" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="Select 0 BadgeID,' Please Select Badge' Badge, 1 Active Union SELECT [BadgeID], [Badge], [Image] FROM [Badge] WHERE ([Active] = @Active) order by 2">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
               
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Badge" runat="server"></asp:TextBox>
                <asp:Button ID="Button_SearchBadge" runat="server" Text="Filter" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Series</td>
            <td bgcolor="#EFEFEF">
                <asp:DropDownList ID="drp_Series" runat="server" 
                    DataSourceID="SqlDataSource_Series" DataTextField="Series" 
                    DataValueField="SeriesID">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Series" runat="server" 
                    ErrorMessage="Series  Required" ControlToValidate="drp_Series" 
                    ToolTip="Please Select Series ">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource_Series" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="Select 0 SeriesID,' Please Select Series' Series, 1 Active Union SELECT [SeriesID], [Series], [Active] FROM [Series] WHERE ([Active] = @Active) order by 2">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Series" runat="server"></asp:TextBox>
                <asp:Button ID="btn_SearchSeries" runat="server" Text="Filter" />
            </td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                Effective Date From</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_EffectiveDateFrom" runat="server"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
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
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel3" runat="server" />
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
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
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
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
