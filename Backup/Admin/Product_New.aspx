<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Product_New" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Admin.Product_New" %>



<%@ Import Namespace="Neemo.Admin.SupportClasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style9
        {
            width: 236px;
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
            width: 116px;
        }
        .style14
        {
            width: 154px;
        }
        .style16
        {
            width: 156px;
        }
        .style18
        {
            height: 21px;
        }
        .style19
        {
        }
        .style20
        {
            width: 40%;
        }
        .style21
        {
            width: 120px;
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
                url: "Product_New.aspx/Isdefault",
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
                url: "Product_New.aspx/delete",
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
                url: "Product_New.aspx/setfile",
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
                </td>
        </tr>
        </table>
        <br />
        <table style="width: 51%;">
            <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Product_New" %>--%>
            <tr>
                <td bgcolor="#EFEFEF" width="5%">
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
                <td bgcolor="#EFEFEF" width="5%">
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
        <asp:MultiView ID="mvw_Parts" runat="server">
            <asp:View ID="vw_WreckDetails" runat="server">
                <h2>
                    Wreck Details</h2>
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
                                    Colour
                                </td>
                                <td>
                                    <%# Eval("Colour")%>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    Side
                                </td>
                                <td>
                                    <%# Eval("Side")%>
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
                            <asp:GridView ID="grv_FeatureList" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="FeatureID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FeatureIDEdit" runat="server" Text='<%# Eval("FeatureID") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FeatureID" runat="server" Text='<%# Eval("FeatureID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feature Name" Visible="true">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FeatureNameEdit" runat="server" Text='<%# Eval("Feature") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FeatureName" runat="server" Text='<%# Eval("Feature") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkActive_FeatureEdit" runat="server" Checked='<%# Eval("active") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActive_Feature" runat="server" Checked='<%# Eval("active") %>'
                                                Enabled="false" />
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
                                        &nbsp;</td>
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
                            <asp:GridView ID="grv_PriceList" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" ForeColor="Black"
                                GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="PriceID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_PriceidEdit" runat="server" Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Priceid" runat="server" Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:Label ID="txt_QtyEdit" runat="server" Enabled="false" Font-Names="Arial" Font-Size="Small"
                                                Height="20px" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"
                                                Text='<%# Eval("quantity") %>' Width="15px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_Qty" runat="server" Enabled="false" Text='<%# Eval("quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle Font-Names="Arial" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_EditRetailPriceEdit" runat="server" Font-Names="Arial" Font-Size="Small"
                                                Height="20px" Style="font-size: small; font-family: Arial, Helvetica, sans-serif"
                                                Text='<%# Eval("price","{0:N2}") %>' ValidationGroup="pricechange" Width="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_EditRetailPriceEdit"
                                                ErrorMessage="Invalid Price" ForeColor="#CC3300" ValidationGroup="pricechange">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_EditRetailPriceEdit"
                                                ErrorMessage="Invalid Price" ForeColor="Red" MaximumValue="99999.99" MinimumValue=".01"
                                                SetFocusOnError="True" Type="Double" ValidationGroup="pricechange">*</asp:RangeValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_RetailPrice" runat="server" Enabled="false" Text='<%# Eval("price","{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle Font-Names="Arial" Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkActive_PartPriceEdit" runat="server" Checked='<%# Eval("Active") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActive_PartPrice" runat="server" Checked='<%# Eval("Active") %>'
                                                Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveFromDate">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_FromDate_PartPrieEdit" runat="server" Text='<%# Eval("EffectiveDateFrom") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FromDate_PartPrie" runat="server" Text='<%# Eval("EffectiveDateFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EffectiveToDate">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_TomDate_PartPrieEdit" runat="server" Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TomDate_PartPrie" runat="server" Text='<%# Eval("EffectiveDateTo") %>'></asp:Label>
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
                </table>
            </asp:View>
            <asp:View ID="vw_partImages" runat="server">
                <h2>
                    Part Photos
                </h2>
                <table style="border: thin solid #808080; width: 50%;">
                    <tr>
                        <td>
                            <asp:DataList ID="dtlPartPhotos" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
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
        </asp:MultiView> <table>
            <tr>
                <td bgcolor="#EFEFEF" >
                    Price(Inc. GST)</td>
                <td bgcolor="#EFEFEF">
                            <asp:TextBox ID="txt_Price" runat="server" ValidationGroup="save"></asp:TextBox>
                            <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_New.aspx.cs" Inherits="Neemo.Product_New" %>--%>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txt_Price" ErrorMessage="Price Required" ForeColor="#CC3300" 
                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txt_Qty" ErrorMessage="Invalid Quantity" ForeColor="#CC3300" 
                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
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
       
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <table style="width: 57%">
            <tr>
                <td bgcolor="#EFEFEF" class="style13">
                    Special
                </td>
                <td bgcolor="#EFEFEF" class="style21" >
                    <asp:CheckBox ID="chk_Special" runat="server" Checked='<%# Eval("onSpecial") %>' />
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
                    <asp:CheckBox ID="chk_TopSeller" runat="server" Checked='<%# Eval("TopSeller") %>' />
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
                <td bgcolor="#EFEFEF" class="style16" >
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


  <table >
            
            <tr valign="top">
                <td bgcolor="#EFEFEF" >
                    <h2>Product Specific Images</h2>
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
    <div style="width: 100%">
    </div>
   
    <div>
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
                </td>
            </tr>
            </table>
           
    <table style="width: 37%;">
        <tr>
            <td class="style18">
                &nbsp;
                &nbsp;
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style19">
                &nbsp;<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
<asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="save" 
                        onclick="btn_Save_Click" />
                &nbsp;
                <asp:Button ID="btn_reset" runat="server" Text="Reset" onclick="btn_reset_Click" />
                
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btn_reset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                &nbsp;
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