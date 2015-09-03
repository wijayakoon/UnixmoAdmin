<%@ Register Src="UC_AddressAutocomplete.ascx" TagName="UC_AddressAutocomplete" TagPrefix="uc1" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Provider_New.aspx.cs" Inherits="NeemoAdmin.Provider_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1 {
            height: 21px;
        }

        .style2 {
            height: 26px;
        }

        .style3 {
        }

        .style4 {
            height: 26px;
            width: 848px;
        }

        .style6 {
            height: 26px;
        }

        .style7 {
            height: 26px;
            width: 846px;
        }

        .style8 {
            height: 26px;
            width: 843px;
        }

        .style9 {
            height: 26px;
            width: 806px;
        }

        .style10 {
            width: 806px;
        }

        .auto-style3 {
            width: 745px;
        }

        .auto-style4 {
            width: 1068px;
        }

        .auto-style5 {
            height: 26px;
            width: 1068px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Localize ID="Localize1" runat="server"></asp:Localize>
    <table align="left" style="vertical-align: top; width: 1000px;">
        <tr>
            <td align="center" bgcolor="#CCCCCC" class="style3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066"
                    Style="font-size: large" Text="ADD PROVIDERS"></asp:Label>
            </td>
        </tr>
    </table>
    <table align="left" style="vertical-align: top; width: 1000px;">

        <tr>
            <td class="auto-style5" bgcolor="#EFEFEF">Provider Name</td>
            <td bgcolor="#EFEFEF" class="style2" width="250px">

                <asp:TextBox ID="txt_ProviderName" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style9">Email</td>
            <td bgcolor="#EFEFEF" class="style2" width="250px">

                <asp:TextBox ID="txt_EmailAddress" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
        </tr>

        <tr>
            <td class="auto-style5" bgcolor="#EFEFEF">First name</td>
            <td bgcolor="#EFEFEF" class="style7">

                <asp:TextBox ID="txt_FirstName" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
            <td bgcolor="#EFEFEF" class="style9">Last name</td>
            <td bgcolor="#EFEFEF" class="style7">

                <asp:TextBox ID="txt_LastName" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
        </tr>

        <tr>
            <td class="auto-style5" bgcolor="#EFEFEF">Mobile</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_Mobile" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
            <td bgcolor="#EFEFEF" class="style10">Phone</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_Phone" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td class="auto-style5" bgcolor="#EFEFEF">Fax</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_Fax" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
            <td bgcolor="#EFEFEF" class="style10">URL</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_URL" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td class="auto-style5" bgcolor="#EFEFEF">Rating</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_Rating" runat="server" Width="350px" MaxLength="100">0</asp:TextBox>


            </td>
            <td bgcolor="#EFEFEF" class="style10">Contact Us Page</td>
            <td bgcolor="#EFEFEF">

                <asp:TextBox ID="txt_ContactUsURL" runat="server" Width="350px" MaxLength="100"></asp:TextBox>


            </td>
        </tr>

        <tr valign="top">
            <td class="auto-style4" bgcolor="#EFEFEF">Key words</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="txt_Keyword" runat="server" TextMode="MultiLine"
                    Height="200px" Width="350px" MaxLength="8000"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style10">Description</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine"
                    Height="200px" Width="350px" MaxLength="8000"></asp:TextBox>
            </td>
        </tr>

 

        <tr valign="top">
            <td class="auto-style5" bgcolor="#EFEFEF">Active</td>
            <td bgcolor="#EFEFEF" class="style2">
                <asp:CheckBox ID="chk_Active" runat="server" Checked="True" />
            </td>
            <td bgcolor="#EFEFEF" class="style9">
               
                Display on Home Page</td>
            <td bgcolor="#EFEFEF" class="style2">
                
                <asp:CheckBox ID="chk_DisplayOnHomePage" runat="server" Checked="True" />
                
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
    <table align="left" style="vertical-align: top; width: 1000px;">
        <tr>
            <td class="auto-style1" bgcolor="#EFEFEF">Image</td>
            <td bgcolor="#EFEFEF" class="auto-style1">
                <asp:FileUpload ID="FileUpload_Image" runat="server" Style="margin-left: 0px" />
                <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click"
                    Text="Upload" />
                <br />
                
                <asp:Image ID="Image_Icon" runat="server" Height="30px" Width="30px" />
            </td>
        </tr>

    </table>
                        </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID = "btn_Upload"  />
                    </Triggers>
        </asp:UpdatePanel>
    <table align="left" style="vertical-align: top; width: 1000px;">
        <tr>

            <td class="auto-style3">
                <uc1:UC_AddressAutocomplete ID="UC_AddressAutocomplete1" runat="server" />

                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <asp:HiddenField ID="HiddenField4" runat="server" />
                <asp:HiddenField ID="HiddenField5" runat="server" />
                <asp:HiddenField ID="HiddenField6" runat="server" />
                <asp:HiddenField ID="HiddenField7" runat="server" />
                <asp:HiddenField ID="HiddenField8" runat="server" />
                <asp:HiddenField ID="HiddenField9" runat="server" />
                <asp:HiddenField ID="HiddenField10" runat="server" />

            </td>

        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
    <br />

    <table align="left" style="vertical-align: top; width: 1000px;">

        <tr>
            <td class="auto-style3">
                <asp:Button ID="btn_ProviderTypeView" runat="server" Text="Provider Type" OnClick="btn_ProviderTypeView_Click" />
                <asp:Button ID="btn_ServiceTypeView" runat="server" Text="Service Type" OnClick="btn_ServiceTypeView_Click" />
                <asp:Button ID="btn_MakeView" runat="server" Text="Make" OnClick="btn_MakeView_Click" />
               
            </td>

            <td class="auto-style3">
                
                &nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style3">

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>

                        <table style="width: 100%;">
                            <tr>
                                <td class="style6">

                                    <h2>Provider TYPE</h2>
                                </td>
                            </tr>

                            <tr>
                                <td class="style6">
                                    <asp:DropDownList ID="drp_ProviderTypes" runat="server" Height="20px" Width="250px">
                                    </asp:DropDownList>
                                    <asp:Button ID="btn_ProviderTypeAdd" runat="server" Height="20px"
                                        OnClick="btn_ProviderTypeAdd_Click" Text="Add" ValidationGroup="ProviderType" />
                                    <br />
                                    <asp:Label ID="lbl_ProviderTypeExists" runat="server" ForeColor="Red"
                                        Style="font-weight: 700" Text="Provider Type already added to the List"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>

                            <tr>

                                <td style="text-align: ">
                                    <asp:GridView ID="grv_ProviderTypeList" runat="server" CellPadding="4" ForeColor="#333333"
                                        OnRowDeleting="grv_ProviderTypeList_RowDeleting"
                                        GridLines="None" AutoGenerateColumns="False" Width="249px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="ProviderTypeID" HeaderText="ProviderTypeID" Visible="False" />
                                            <asp:BoundField DataField="ProviderType" HeaderText="ProviderType" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btn_ProviderTypeAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel></asp:View>
                    <asp:View ID="View2" runat="server"> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <table style="width: 87%;">
                            <tr>
                                <td class="style1">
                                    <h2>Services</h2>
                                </td>
                            </tr>
                            <tr>

                                <td style="text-align: ">
                                    <asp:DropDownList ID="drp_ServiceTypes" runat="server" Height="20px" Width="250px">
                                    </asp:DropDownList>
                                    <asp:Button ID="btn_ServiceTypes" runat="server" Height="20px" OnClick="btn_ServiceTypeAdd_Click" Text="Add" ValidationGroup="ServiceType" />
                                    <br />
                                    <asp:Label ID="lbl_ServiceTypeExists" runat="server" ForeColor="Red" Style="font-weight: 700" Text="Service Type already added to the List" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: ">
                                    <asp:GridView ID="grv_ServiceTypes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grv_ServiceTypes_RowDeleting" Width="249px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="ServiceTypeID" HeaderText="ServiceTypeID" Visible="False" />
                                            <asp:BoundField DataField="ServiceType" HeaderText="ServiceType" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>

                        <asp:AsyncPostBackTrigger ControlID="btn_ServiceTypes" EventName="Click" />

                    </Triggers>
                </asp:UpdatePanel>
</asp:View>
                    <asp:View ID="View3" runat="server"><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                        <table style="width: 87%;">
                            <tr>
                                <td class="style1">
                                    <h2>Makes</h2>
                                </td>
                            </tr>
                            <tr>

                                <td style="text-align: ">
                                    <asp:DropDownList ID="drp_Makes" runat="server" Height="20px" Width="250px">
                                    </asp:DropDownList>
                                    <asp:Button ID="btn_MakeAdd" runat="server" Height="20px" OnClick="btn_MakeAdd_Click" Text="Add" ValidationGroup="Make" />
                                    <br />
                                    <asp:Label ID="lbl_MakeExists" runat="server" ForeColor="Red" Style="font-weight: 700" Text="Make already added to the List" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: ">
                                    <asp:GridView ID="grv_Make" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grv_Makes_RowDeleting" Width="249px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="MakeID" HeaderText="MakeID" Visible="False" />
                                            <asp:BoundField DataField="Make" HeaderText="Mak" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>

                        <asp:AsyncPostBackTrigger ControlID="btn_ServiceTypes" EventName="Click" />

                    </Triggers>
                </asp:UpdatePanel></asp:View>
                </asp:MultiView>
               
            </td>

            <td class="auto-style3">
                
            </td>
        </tr>
    </table>


            </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="btn_ProviderTypeView" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_ServiceTypeView" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_MakeView" EventName="Click" />

        </Triggers>
            </asp:UpdatePanel>
    <br />

    <table align="left" style="vertical-align: top; width: 1000px;">

        <tr>
            <td class="style4" bgcolor="#EFEFEF">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <%--<uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel3" runat="server" />--%>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_NoServiceType" runat="server"
                            Style="color: #990000; font-weight: 700" Text="Please Add Service Type for this Provider"
                            Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_NoProviderType" runat="server" Style="color: #990000; font-weight: 700" Text="Please Add Provider Type for this Provider" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_Sucess" runat="server"
                            Style="color: #003300; font-weight: 700" Text="Details Updated"
                            Visible="False"></asp:Label>
                        <br />
                        <asp:Button ID="Button_Save" runat="server" Text="Save"
                            ValidationGroup="save" OnClick="Button_Save_Click" />
                        &nbsp;<asp:Button ID="Button_Reset" runat="server" OnClick="Button_Reset_Click"
                            Text="Reset" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button_Save" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td bgcolor="#EFEFEF" class="style1">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="price" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="save" />
            </td>
        </tr>
    </table>





</asp:Content>
