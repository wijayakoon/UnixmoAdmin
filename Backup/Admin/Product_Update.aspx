<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product_Update.aspx.cs" Inherits="Neemo.Admin.Product_Update" %>
<%@ Register src="UC_ProcessingInProgressPanel.ascx" tagname="ProcessingInProgressPanel" tagprefix="uc1" %>

<%@ Import Namespace="Neemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <style type="text/css">
        .style1
        {
            height: 57px;
        }
        .style2
        {
            width: 10px;
        }
        .style9
        {
            width: 1%;
        }
        .style10
        {
            width: 110px;
        }
        .style11
        {
            width: 110px;
            height: 24px;
        }
        .style12
        {
            width: 236px;
            height: 24px;
        }
        .style13
        {
            width: 88px;
        }
        .style14
        {
            width: 90px;
        }
        .style15
        {
            width: 156px;
        }
        .style16
        {
            width: 10%;
        }
        </style>
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <link rel="stylesheet" href="css/jquery-ui.css" id="theme"/>
    <link rel="stylesheet" href="css/jquery.fileupload-ui.css"/>
     <link rel="stylesheet" href="css/style.css"/>    
    <script src="Js/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeDefault(id) {
            $.ajax({
                type: "POST",
                url: "Product_Update.aspx/Isdefault",
                data: JSON.stringify({ imagelistid: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Do something interesting here.                                                                               
                    $("#<%=dtlPhotos.ClientID %> tbody").empty();
                    $("#<%=dtlPhotos.ClientID %> tbody").append(response.d);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('bad, ' + errorThrown + ", " + jqXHR.responseText + ", " + textStatus);
                }

            });
        }
        function deleteimg(id) {
            $.ajax({
                type: "POST",
                url: "Product_Update.aspx/delete",
                data: JSON.stringify({ imagelistid: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Do something interesting here.                                                                               
                    $("#<%=dtlPhotos.ClientID %> tbody").empty();
                    $("#<%=dtlPhotos.ClientID %> tbody").append(response.d);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('bad, ' + errorThrown + ", " + jqXHR.responseText + ", " + textStatus);
                }

            });
        }
        function callajax() {
            $.ajax({
                type: "POST",
                url: "Product_Update.aspx/setfile",
                data: JSON.stringify({ file: "true" }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Do something interesting here.                                                                               
                    $("#<%=dtlPhotos.ClientID %> tbody").empty();
                    $("#<%=dtlPhotos.ClientID %> tbody").append(response.d);


                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('bad, ' + errorThrown + ", " + jqXHR.responseText + ", " + textStatus);
                }

            });

        }
       
    </script>
   


       
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
    <table align="left"  style="vertical-align:top; width: 51%;">
        <tr>
            <td align="center" bgcolor="#CCCCCC">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" 
                    style="font-size: large" Text="ADD PRODUCTS"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server"></asp:SqlDataSource>
                </td>
        </tr>
        </table>
        <br />
        <table style="width: 51%;">
            <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Product_New" %>--%>
            <tr>
                <td bgcolor="#EFEFEF" class="style16">
                    Wreck No
                </td>
                <td bgcolor="#EFEFEF" class="style20">
                    <asp:DropDownList ID="drp_Wreck" runat="server" Height="25px" Width="265px" OnSelectedIndexChanged="drp_Wreck_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:TextBox ID="txt_WreckSearch" runat="server" Height="20px" Width="212px"></asp:TextBox>
                    <asp:Button ID="btn_SearchWreck" runat="server" Text="Filter" OnClick="btn_SearchWreck_Click" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" class="style16">
                    Part
                </td>
                <td bgcolor="#EFEFEF" class="style20">
                    <asp:DropDownList ID="drp_Part" runat="server" AutoPostBack="True" 
                        Height="25px" OnSelectedIndexChanged="drp_Part_SelectedIndexChanged" 
                        Width="265px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txt_PartSearch" runat="server" Height="20px" Width="210px"></asp:TextBox>
                    <asp:Button ID="btn_PartSearch" runat="server" OnClick="btn_PartSearch_Click" 
                        Text="Filter" />
                </td>
            </tr>
        </table>
        <table width="100%" style="width: 51%">
            <tr valign="top">
                <td bgcolor="#EFEFEF">
                    <asp:Button ID="btn_wreckDetails" runat="server" Text="Wreck Details" OnClick="btn_wreckDetails_Click" />
                    <asp:Button ID="btn_partDetails" runat="server" OnClick="btn_partDetails_Click" Text="Part Details" />
                    <asp:Button ID="btn_partFeatures" runat="server" Text="Part Features" OnClick="btn_partFeatures_Click" />
                    <asp:Button ID="btn_PartPrice" runat="server" Text="Part Price" OnClick="btn_PartPrice_Click" />
                    <asp:Button ID="btn_PartImages" runat="server" Text="Part Pictures" OnClick="btn_PartImages_Click" />
                </td>
            </t>
        </table>
      
        <br />
        <asp:MultiView ID="mvw_Parts" runat="server">
            <asp:View ID="vw_WreckDetails" runat="server">
                <h2>
                    Wreck Details<asp:SqlDataSource ID="sqlDatasourceWrek" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [vw_WreckDetails_All] WHERE ([WreckID] = @WreckID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drp_Wreck" Name="WreckID" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </h2>
                <table style="border: thin solid #808080; width: 725px;">
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Make
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_Make" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Model
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_Model" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11" bgcolor="#EFEFEF">
                            Chasssis No
                        </td>
                        <td bgcolor="#EFEFEF" class="style12">
                            <asp:TextBox ID="txt_ChassisNo" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Engine No
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_EngineNo" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Engine Capacity
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_EngineSize" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Fuel Type
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_FuelType" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Wheel Base
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_WheelBase" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Body Type
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_BodyType" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Year
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_Year" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style10" bgcolor="#EFEFEF">
                            Key Word
                        </td>
                        <td bgcolor="#EFEFEF" class="style9">
                            <asp:TextBox ID="txt_Year0" runat="server" Width="212px" MaxLength="100" Enabled="False"
                                Height="20px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vw_PartDetails" runat="server">
                <h2>
                    Part Details</h2>
                <asp:ListView ID="lv_Parts" runat="server" DataSourceID="sqlParts">
                    <ItemTemplate>
                        <table width="725px" style="border: thin solid #808080;">
                            <tr>
                                <td width="150px">
                                    Category
                                </td>
                                <td>
                                    <%# Eval("Category")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Part No
                                </td>
                                <td>
                                    <%# Eval("PartNo")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Part
                                </td>
                                <td>
                                    <%# Eval("Part")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Short Description
                                </td>
                                <td>
                                    <%# Eval("ShortDescription")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                    <%# Eval("Description")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Height
                                </td>
                                <td>
                                    <%# Eval("Height")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Width
                                </td>
                                <td>
                                    <%# Eval("Width")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Length
                                </td>
                                <td>
                                    <%# Eval("Length")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Weight
                                </td>
                                <td>
                                    <%# Eval("Weight")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Active
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Active" runat="server" Checked='<%# Eval("Active") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="sqlParts" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="Select * from vw_PartDetails P
Where P.PartID = @PartID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drp_Part" DefaultValue="0" Name="PartID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:View>
            <asp:View ID="vw_PartsFeatures" runat="server">
              <h2>
                    Part Features</h2>
                <table style="border: thin solid #808080; width: 50%;">
                    <tr>                       
                        <td>
                            <asp:GridView ID="grv_FeatureList0" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="FeatureID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FeatureIDEdit0" runat="server" 
                                                Text='<%# Eval("FeatureID") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FeatureID0" runat="server" Text='<%# Eval("FeatureID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Feature ID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_PartfeatureidEdit" runat="server" 
                                                Text='<%# Eval("Partfeatureid") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Partfeatureid" runat="server" 
                                                Text='<%# Eval("Partfeatureid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feature Name" Visible="true">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FeatureNameEdit0" runat="server" 
                                                Text='<%# Eval("Feature") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FeatureName0" runat="server" Text='<%# Eval("Feature") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkActive_FeatureEdit0" runat="server" 
                                                Checked='<%# Eval("active") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActive_Feature0" runat="server" Checked='<%# Eval("active") %>'
                                                Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveFromDate" Visible="False">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_PartFeatureFromDate_Edit" runat="server" 
                                                Text='<%# Eval("EffectiveFrom") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PartFeatureFromDate" runat="server" 
                                                Text='<%# Eval("EffectiveFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveToDate" Visible="False">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_TomDate_PartFeatureEdit" runat="server" 
                                                Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TomDatePartFeature" runat="server" 
                                                Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSourcePartFeatures" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                            SelectCommand="Select * from vw_PartFeatures_All Where PartID = @PartID">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="drp_Part" Name="PartID" 
                                                    PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vw_PartsPrice" runat="server">
                <h2>
                    Part Price</h2>
                <table style="border: thin solid #808080; width: 50%;">
                    <tr>
                        <td>
                            <asp:GridView ID="grv_PriceList0" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="PriceID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_PriceidEdit0" runat="server" 
                                                Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Priceid0" runat="server" Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:Label ID="txt_QtyEdit0" runat="server" Enabled="false" Font-Names="Arial" Font-Size="Small"
                                                Height="20px" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"
                                                Text='<%# Eval("quantity") %>' Width="15px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_Qty0" runat="server" Enabled="false" 
                                                Text='<%# Eval("quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle Font-Names="Arial" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_EditRetailPriceEdit0" runat="server" Font-Names="Arial" Font-Size="Small"
                                                Height="20px" Style="font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                Text='<%# Eval("price","{0:N2}") %>' ValidationGroup="pricechange" 
                                                Width="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_EditRetailPriceEdit"
                                                ErrorMessage="Invalid Price" ForeColor="#CC3300" 
                                                ValidationGroup="pricechange">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_EditRetailPriceEdit"
                                                ErrorMessage="Invalid Price" ForeColor="Red" MaximumValue="99999.99" MinimumValue=".01"
                                                SetFocusOnError="True" Type="Double" ValidationGroup="pricechange">*</asp:RangeValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_RetailPrice0" runat="server" Enabled="false" 
                                                Text='<%# Eval("price","{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle Font-Names="Arial" Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkActive_PartPriceEdit" runat="server" 
                                                Checked='<%# Eval("Active") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActive_PartPrice" runat="server" Checked='<%# Eval("Active") %>'
                                                Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveFromDate">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FromDate_PartPrieEdit" runat="server" 
                                                Text='<%# Eval("EffectiveDateFrom") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FromDate_PartPrie" runat="server" 
                                                Text='<%# Eval("EffectiveDateFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveToDate">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_TomDate_PartPrieEdit" runat="server" 
                                                Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TomDate_PartPrie" runat="server" 
                                                Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourcePartPrice" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT [Quantity], [PartID], [Price] FROM [vw_PartPrice_All] WHERE ([PartID] = @PartID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="drp_Part" Name="PartID" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vw_partImages" runat="server">
                <h2>
                    Part Photos
                </h2>
                <table style="border: thin solid #808080; width: 50%;">
                    <tr>
                        <td>
                            <asp:DataList ID="dtlPartPhotos" runat="server" RepeatColumns="4" 
                                RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <div style="padding: 3px">
                                        <div>
                                            <asp:CheckBox ID="chkdefault" CssClass="chkdefault" GroupName="Default" Checked='<%# Eval("IsDefault")%>'
                                                onclick='<%# String.Format("ChangeDefault({0});", Eval("PartPhotoID"))%>' runat="server"
                                                Text="IsDefault" />
                                        </div>
                                        <div>
                                            <asp:Image ID="imgphotos" CssClass="img" runat="server" Height="100px" ImageUrl='<%# String.Format("{0}/{1}",Common.ThumbnailFileLocation,Eval("Photoname")) %>'
                                                Width="100px" />
                                        </div>
                                        <div>                                            
                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("PartPhotoID") %>' />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                          
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <table>
            <tr>
                <td bgcolor="#EFEFEF" >
                    Price(Inc. GST)</td>
                <td bgcolor="#EFEFEF">
                            <asp:TextBox ID="txt_Price" runat="server" ValidationGroup="save"></asp:TextBox>
                            <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Product_New" %>--%>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txt_Price" ErrorMessage="Price Required" ForeColor="#CC3300" 
                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                ControlToValidate="txt_Price" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="save">*</asp:RangeValidator>
                            <%# Eval("Category")%>

                           
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" >
                    Stock on Hand</td>
                <td bgcolor="#EFEFEF">
                            <asp:TextBox ID="txt_Qty" runat="server" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txt_Qty" ErrorMessage="Invalid Quantity" ForeColor="#CC3300" 
                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator6" runat="server" 
                                ControlToValidate="txt_Qty" ErrorMessage="Invalid Quantity" ForeColor="Red" 
                                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                ValidationGroup="save">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" >
                    Product Related Comments
                </td>
                <td bgcolor="#EFEFEF">
                    <asp:TextBox ID="txt_Coments" runat="server" Height="99px" TextMode="MultiLine" ValidationGroup="price"
                        Width="501px"></asp:TextBox>
                </td>
            </tr>
            </table>
            </ContentTemplate>
     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="drp_Part" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drp_Wreck" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btn_PartSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_SearchWreck" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_partDetails" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_partFeatures" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_PartImages" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btn_PartPrice" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
            <table style="width: 60%">
            <tr>
                <td bgcolor="#EFEFEF" class="style13">
                    Special
                </td>
                <td bgcolor="#EFEFEF" class="style21" >
                    <asp:CheckBox ID="chk_Special" runat="server" 
                        Checked='<%# Eval("onSpecial") %>' />
                </td>
                <td bgcolor="#EFEFEF" class="style14">
                    Soldout
                </td>
                <td bgcolor="#EFEFEF" >
                    <asp:CheckBox ID="chk_Soldout" runat="server" 
                        Checked='<%# Eval("Soldout") %>' />
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" class="style13">
                    Discount product
                </td>
                <td bgcolor="#EFEFEF" class="style21">
                    <asp:CheckBox ID="chk_Discount" runat="server" Checked='<%# Eval("Discount") %>' />
                </td>
                <td bgcolor="#EFEFEF" class="style14">
                    Display on Home Page
                </td>
                <td bgcolor="#EFEFEF" >
                    <asp:CheckBox ID="chk_DisplayonHomePage" runat="server" 
                        Checked='<%# Eval("DisplayonHomePage") %>' />
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" class="style13">
                    Featured</td>
                <td bgcolor="#EFEFEF" class="style21" >
                    <asp:CheckBox ID="chk_Featured" runat="server" 
                        Checked='<%# Eval("Featured") %>' />
                </td>
                <td bgcolor="#EFEFEF" class="style14">
                    New</td>
                <td bgcolor="#EFEFEF">
                    <asp:CheckBox ID="chk_New" runat="server" Checked='<%# Eval("New") %>' />
                </td>
            </tr>
            <tr>
                <td bgcolor="#EFEFEF" class="style13">
                    TopSeller </td>
                <td bgcolor="#EFEFEF" class="style21" >
                    <asp:CheckBox ID="chk_TopSeller" runat="server" 
                        Checked='<%# Eval("TopSeller") %>' />
                </td>
                <td bgcolor="#EFEFEF" class="style14">
                    Any deffect
                </td>
                <td bgcolor="#EFEFEF">
                    <asp:CheckBox ID="chk_Deffects" runat="server" 
                        Checked='<%# Eval("Deffects") %>' 
                        oncheckedchanged="chk_Deffects_CheckedChanged" AutoPostBack="True" />
                </td>
            </tr>
                <tr>
                    <td bgcolor="#EFEFEF" class="style13">
                        Active</td>
                    <td bgcolor="#EFEFEF" class="style21">
                        <asp:CheckBox ID="chk_Active" runat="server" 
                            Checked='<%# Eval("TopSeller") %>' />
                    </td>
                    <td bgcolor="#EFEFEF" class="style14">
                        &nbsp;</td>
                    <td bgcolor="#EFEFEF">
                        &nbsp;</td>
                </tr>
            </table>
            <table>
           
            <tr valign="top">
                <td bgcolor="#EFEFEF" >
                    Coments About the deffect
                </td>
                <td bgcolor="#EFEFEF">
                    <asp:TextBox ID="txt_DeffectNotes" runat="server" Height="122px" TextMode="MultiLine"
                        ValidationGroup="price" Width="497px" Enabled="False"></asp:TextBox>
                </td>
                
            </tr>
            </table>

            <table>
           
            <tr valign="top">
                <td bgcolor="#EFEFEF" class="style15" >
                    Specials Notes
                </td>
                <td bgcolor="#EFEFEF">
                    <asp:TextBox ID="txt_SpecialsNote" runat="server" Height="122px" TextMode="MultiLine"
                        ValidationGroup="price" Width="497px"></asp:TextBox>
                </td>
                
            </tr>
            </table>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="chk_Deffects" EventName="CheckedChanged" />
        </Triggers>
    </asp:UpdatePanel>
        <table>
            <%# Eval("Part")%>
        <td></td>
        <td>
         <div style="width: 480px">
    </div>
    
            <div style="width: 480px">
        <div class="ContainerHeader">
            UploadFile
        </div>
        <div class="ContainerMargin">
            <div class="Container">
                <asp:DataList ID="dtlPhotos" Width="100%" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    OnItemDataBound="dtlPhotos_ItemDataBound">
                    <ItemTemplate>
                        <div style="padding: 3px">
                            <div>                            
                                     <asp:CheckBox ID="chkdefault" CssClass="chkdefault" GroupName="Default"
                                    Checked='<%# Eval("IsDefault")%>' onclick='<%# String.Format("ChangeDefault({0});", Eval("ImageListID"))%>' runat="server" Text="IsDefault" />
                            </div>
                            <div>
                                <asp:Image ID="imgphotos" CssClass="img" runat="server" Height="100px" ImageUrl='<%# String.Format("{0}/{1}",Common.ThumbnailFileLocation,Eval("ThumbNailImageName")) %>'
                                    Width="100px" />
                            </div>
                            <div>
                                <asp:LinkButton ID="lnkbtndelete" CssClass="lnkbtndelete" runat="server" Text="Delete" Onclick='<%# String.Format("deleteimg({0}); return false;", Eval("ImageListID"))%>'></asp:LinkButton>
                                <asp:HiddenField ID="hdnhaveimage" runat="server" Value='<%# Eval("HaveImage") %>' />
                                <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ImageListID") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>

      <div id="fileupload">
      
        <div class="fileupload-buttonbar">
            <label class="fileinput-button">
                <span>Add files...</span>
                <input id="file" type="file" runat="server" class="fileupload" name="files[]" multiple />
            </label>
            <button type="submit" class="start">
                Start upload</button>
            <button type="reset" class="cancel">
                Cancel upload</button>      
        </div>
        
        <div class="fileupload-content">
            <table class="files">
            </table>
            <div class="fileupload-progressbar">
            </div>
        </div>
         <script type="text/javascript">
             var countupload = 0;
             var countdownload = 0;

    </script>
    <script id="template-upload" type="text/x-jquery-tmpl">
    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${name}</td>
        <td class="size">${sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="progress"><div></div></td>
            <td class="start"><button>Start</button></td>
        {{/if}}
        <td class="cancel"><button onclick="countupload = countupload - 1;">Cancel</button></td>
    </tr>
     <script type="text/javascript">
       countupload = countupload + 1;
    {{html "</sc"+"ript>"}}
</script>
    <script id="template-download" type="text/x-jquery-tmpl">
    <tr class="template-download{{if error}} ui-state-error{{/if}}">
        {{if error}}        
            <td></td>
            <td class="name">${namefdsa}</td>
            <td class="size">${sizef}</td>
            <td class="error" colspan="2">Error:
                {{if error === 1}}File exceeds upload_max_filesize (php.ini directive)
                {{else error === 2}}File exceeds MAX_FILE_SIZE (HTML form directive)
                {{else error === 3}}File was only partially uploaded
                {{else error === 4}}No File was uploaded
                {{else error === 5}}Missing a temporary folder
                {{else error === 6}}Failed to write file to disk
                {{else error === 7}}File upload stopped by extension
                {{else error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else error === 'uploadedBytes'}}Uploaded bytes exceed file size
                {{else error === 'emptyResult'}}Empty file upload result
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="preview">
                {{if Thumbnail_url}}
                    <a href="${url}" target="_blank"><img src="${Thumbnail_url}"></a>
                {{/if}}
            </td>
            <td class="name">
                <a href="${url}"{{if thumbnail_url}} target="_blank"{{/if}}>${Name}</a>
            </td>
            <td class="size">${Length}</td>
            <td colspan="2"></td>                                 
        {{/if}}
        

    </tr>
    <script type="text/javascript">
        countdownload = countdownload + 1;
        if(countdownload == countupload)
        {  
           callajax();         
        }
    {{html "</sc"+"ript>"}}  
    </script>
      
    </div>
            <%# Eval("ShortDescription")%>
       
        </table>
        <table>
        <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <%--<uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel3" runat="server" />--%>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_NoPriceWarning" runat="server" 
                            style="color: #990000; font-weight: 700" Text="Please Add Price to This Product" 
                            Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_Sucess" runat="server" 
                            style="color: #003300; font-weight: 700" Text="Details Updated" 
                            Visible="False"></asp:Label>
                        <br />
                        <asp:Button ID="Button_Save" runat="server" Text="Save" 
                            ValidationGroup="save" onclick="Button_Save_Click" style="height: 26px" />
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
            <td class="style1" bgcolor="#EFEFEF">
                </td>
            <td bgcolor="#EFEFEF" class="style1">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="save" 
                    Height="52px" Width="534px" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="price" />
            </td>
        </tr>
    </table>


      <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="js/jquery.iframe-transport.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.handlerurl = 'handler.ashx?id=' + $(".fileupload").attr("id");
    </script>
    <script src="js/jquery.fileupload.js" type="text/javascript"></script>
    <script src="js/jquery.fileupload-ui.js" type="text/javascript"></script>
    <script src="js/application.js" type="text/javascript"></script>    
  
  
    </asp:Content>

