<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Wreck_New.aspx.cs" Inherits="Neemo.Admin.Wreck_New" EnableEventValidation="true" %>

<%@ Register Src="../UserControls/ProcessingInProgressPanel.ascx" TagName="ProcessingInProgressPanel"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="left" style="vertical-align: top; width: 828px;">
                <tr>
                    <td align="center" bgcolor="#CCCCCC">
                        &nbsp;
                    </td>
                    <td align="center" colspan="2" bgcolor="#CCCCCC">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" Style="font-size: large"
                            Text="ADD WRECKS"></asp:Label>
                    </td>
                    <td align="center" bgcolor="#CCCCCC">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Wreck No.
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_WreckNo" runat="server" Height="23px" MaxLength="50" Width="350px"></asp:TextBox>
                    </td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Key Word
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_KeyWord" runat="server" Height="23px" MaxLength="50" Width="350px"></asp:TextBox>
                    </td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Make
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_Make" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Make" runat="server" ErrorMessage="Make Required"
                            ControlToValidate="drp_Make" InitialValue="0" ToolTip="Please Select Make">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_Make" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchMake" runat="server" Text="Filter" OnClick="btn_SearchMake_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Model
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_Model" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Model" runat="server" ErrorMessage="Model  Required"
                            ControlToValidate="drp_Model" InitialValue="0" ToolTip="Please select Model">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_Model" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchModel" runat="server" Text="Filter" OnClick="btn_SearchModel_Click"
                            Style="height: 26px" ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Chasssis No
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_Chassis" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Chassis" runat="server" ErrorMessage="Chassis No Required"
                            ControlToValidate="drp_Chassis" InitialValue="0" ToolTip="Please Select Chasssis">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_ChassisNo" runat="server"></asp:TextBox>
                        <asp:Button ID="Button_SearchChassisNo" runat="server" Text="Filter" OnClick="Button_SearchChassisNo_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Engine No
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_EngineNo" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Series" runat="server" ErrorMessage="Engine No  Required"
                            ControlToValidate="drp_EngineNo" InitialValue="0" ToolTip="Please Select Engine No">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_EngineNo" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchEngineNo" runat="server" Text="Filter" OnClick="btn_SearchEngineNo_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        CC Rating
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_CCRating" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_CCRating" runat="server" ErrorMessage="CC Rating  Required"
                            ControlToValidate="drp_CCRating" InitialValue="0" ToolTip="Please Select CC Rating">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_CCRating" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchCCRating" runat="server" Text="Filter" OnClick="btn_SearchCCRating_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Engine Capacityy
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_EngineSize" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Engine Size  Required"
                            ControlToValidate="drp_EngineSize" InitialValue="0" ToolTip="Please Select Engine Size ">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_EngineSize" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_EngineSize" runat="server" Text="Filter" OnClick="btn_EngineSize_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Fuel Type
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_FuelType" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fuel Type  Required"
                            ControlToValidate="drp_FuelType" InitialValue="0" ToolTip="Please Select Fuel Type ">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_FuelType" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchFuelType" runat="server" Text="Filter" OnClick="btn_SearchFuelType_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Wheel Base
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_WheelBase" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="WheelBase  Required"
                            ControlToValidate="drp_WheelBase" InitialValue="0" ToolTip="Please Select WheelBase ">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_WheelBase" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchWheelBase" runat="server" Text="Filter" OnClick="btn_SearchWheelBase_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Body Type
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_BodyType" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="BodyType  Required"
                            ControlToValidate="drp_BodyType" InitialValue="0" ToolTip="Please Select BodyType ">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_BodyType" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchBodyType" runat="server" Text="Filter" OnClick="btn_SearchBodyType_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Year
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:DropDownList ID="drp_Year" runat="server" Width="350px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Year  Required"
                            ControlToValidate="drp_Year" InitialValue="0" ToolTip="Please Select Year ">*</asp:RequiredFieldValidator>
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="txt_Year" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchYear" runat="server" Text="Filter" OnClick="btn_SearchYear_Click"
                            ValidationGroup="Filter" />
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Effective Date From
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:TextBox ID="TextBox_EffectiveDateFrom" runat="server"></asp:TextBox>
                    </td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Image
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:FileUpload ID="FileUpload_Image" runat="server" />
                        <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click" Text="Upload"
                            ValidationGroup="Upload" />
                        <br />
                        <asp:Image ID="Image_Icon" runat="server" Height="30px" Width="30px" />
                    </td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                    <td class="style2" bgcolor="#EFEFEF">
                        Active
                    </td>
                    <td bgcolor="#EFEFEF">
                        <asp:CheckBox ID="chk_Active" runat="server" Checked="True" Enabled="False" />
                    </td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_SearchBodyType" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchCCRating" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchEngineNo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchFuelType" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchMake" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchWheelBase" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchYear" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_Upload" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel4" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
    <table align="left" style="vertical-align: top; width: 100%;">
        <tr>
            <td bgcolor="#EFEFEF" width="100%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel3" runat="server" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button_Save" runat="server" Text="Save" OnClick="Button_Save_Click" />
                        &nbsp;<asp:Button ID="Button_Reset" runat="server" OnClick="Button_Reset_Click" Text="Reset"
                            ValidationGroup="reset" />
                        &nbsp;<asp:Button ID="btn_Update" runat="server" OnClick="Button_Save_Click" Text="Update"
                            Enabled="False" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button_Save" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td bgcolor="#EFEFEF" width="100%">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
