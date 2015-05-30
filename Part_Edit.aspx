<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Part_Edit.aspx.cs" Inherits="NeemoAdmin.Part_Edit" %>



<%@ Import Namespace="NeemoAdmin.SupportClasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            width: 185px;
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <link rel="stylesheet" href="/Admin/css/jquery-ui.css" id="theme"/>
    <link rel="stylesheet" href="/Admin/css/jquery.fileupload-ui.css"/>
     <link rel="stylesheet" href="/Admin/css/style.css"/>    
    <script src="/Admin/js/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeDefault(id) {
            $.ajax({
                type: "POST",
                url: "Part_New.aspx/Isdefault",
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
                url: "Part_New.aspx/delete",
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
                url: "Part_New.aspx/setfile",
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
   


       
    
    <table align="left"  style="vertical-align:top; width: 1183px;">
        <tr>
            <td align="center" bgcolor="#CCCCCC" class="style3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" 
                    style="font-size: large" Text="EDIT PARTS"></asp:Label>
                </td>
        </tr>
        </table>
    
        <table align="left"  style="vertical-align:top; width: 1000;">

        <tr>
            <td class="style4" bgcolor="#EFEFEF">
                Category</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_Category" runat="server" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                Colour</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_Colour" runat="server" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
            </td>
        </tr>
      
       <tr>
            <td class="style4" bgcolor="#EFEFEF">
                Side</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_Side" runat="server" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                Part No</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                <asp:TextBox ID="txt_PartNo" runat="server" Width="443px" MaxLength="100"></asp:TextBox>
               
                
            </td>
        </tr>
      
      
        <tr>
            <td class="style4" bgcolor="#EFEFEF">
                Part
                Name<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_Name" 
                    ErrorMessage="Name Required" ForeColor="#CC0000" ValidationGroup="save">*</asp:RequiredFieldValidator>
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Name" runat="server" Width="443px" MaxLength="100"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF">
                Short Description</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_ShortDescription" runat="server" Width="443px" 
                    MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top">
            <td class="style4" bgcolor="#EFEFEF">
                Key words<asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT * FROM Part WHERE (PartID = @PartID)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="1" Name="PartID" 
                            QueryStringField="PartID" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Keywords" runat="server" TextMode="MultiLine" 
                    Height="200px" Width="444px" MaxLength="8000"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF">
                Description</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Description" runat="server" TextMode="MultiLine" 
                    Height="200px" Width="444px" MaxLength="8000"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top">
            <td class="style4" bgcolor="#EFEFEF">
                Dimensions(cm)</td>
            <td bgcolor="#EFEFEF">
                Height
                <asp:TextBox ID="txt_Height" runat="server" Width="101px" MaxLength="10"></asp:TextBox>
            &nbsp;Width
                <asp:TextBox ID="txt_Width" runat="server" Width="101px" MaxLength="10"></asp:TextBox>
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                Lenght
                <asp:TextBox ID="txt_Length" runat="server" Width="101px" MaxLength="10"></asp:TextBox>
                Weight (KG)<asp:TextBox ID="txt_Weight" runat="server" Width="101px" MaxLength="10" 
                    Height="24px"></asp:TextBox>
            </td>
        </tr>

        <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>
       
        <tr valign="top">
            <td class="style4" bgcolor="#EFEFEF">
                Active</td>
            <td bgcolor="#EFEFEF">
                <asp:CheckBox ID="chk_Active" runat="server" Checked="True" />
            </td>
            <td bgcolor="#EFEFEF">
                Key words</td>
            <td bgcolor="#EFEFEF">
                &nbsp;</td>
        </tr>
        </table>
    <table align="left"  style="vertical-align:top; width: 1000;">
<tr>
        <td colspan=2>
         <div style="width: 480px">
    </div>
    
            <div style="width: 480px">
        <div class="ContainerHeader">
            <h2>UploadFile</h2>
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

              <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>
            </div>
        </div>
    </div>
    <div style="width: 100%">
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>  
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
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
            <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>
            </td>
           <td>
               &nbsp;<td valign=top>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                
                <table style="width:100%;">
                    <tr>
                        <td class="style6">
                           
                            <h2>Features</h2><br />
                           
                       <asp:DropDownList ID="drp_Features" runat="server" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
                <asp:Button ID="btn_FeatureAdd" runat="server" Height="20px" Text="Add" 
                                        onclick="btn_FeatureAdd_Click" ValidationGroup="feature" />
                            <br />
                        </td>
                    </tr>
                   
                    <tr valign=top>
                        <td>
                            <asp:Label ID="lbl_FeatureExists" runat="server" ForeColor="Red" 
                                style="font-weight: 700" Text="Feature already added to the List" 
                                Visible="False"></asp:Label>
                        </td>
                        <tr valign"=top">
                            <td valign="top">
                                <asp:GridView ID="grv_FeatureList" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="3" ForeColor="Black" GridLines="Vertical" 
                                    OnRowCancelingEdit="CancelEditPartFeature" OnRowEditing="EditPartFeature" 
                                    OnRowUpdating="UpdatePartFeature" Width="613px">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" 
                                                    Text="Update"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" 
                                                    Text="Cancel"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FeatureID" Visible="false">
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl_FeatureIDEdit" runat="server" 
                                                    Text='<%# Eval("FeatureID") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_FeatureID" runat="server" Text='<%# Eval("FeatureID") %>'></asp:Label>
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
                                                <asp:Label ID="lbl_FeatureNameEdit" runat="server" 
                                                    Text='<%# Eval("Feature") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_FeatureName" runat="server" Text='<%# Eval("Feature") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Active">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="chkActive_FeatureEdit" runat="server" 
                                                    Checked='<%# Eval("active") %>' />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkActive_Feature" runat="server" 
                                                    Checked='<%# Eval("active") %>' Enabled="false" />
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
                    </tr>
                </table>
                </ContentTemplate>
                <Triggers>               
                    <asp:AsyncPostBackTrigger ControlID="btn_FeatureAdd" EventName="Click" />               
                </Triggers>
                </asp:UpdatePanel>
            <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                <table style="width:100%;">
                    <tr>
                        <td class="style6">
                            <h2>Price</h2></td>
                        <td class="style6">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style6">
                            Qty.</td>
                        <td class="style6">
                            <asp:TextBox ID="txt_Qty" runat="server" ValidationGroup="price"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txt_Qty" ErrorMessage="Invalid Quantity" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="txt_Qty" ErrorMessage="Invalid Quantity" ForeColor="Red" 
                                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                                ValidationGroup="price">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign=top>
                            Price[EX.GST]</td>
                        <td>
                            <asp:TextBox ID="txt_Price" runat="server" ValidationGroup="price"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Price"
                                ErrorMessage="Price Required" ForeColor="#CC3300" ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_Price"
                                ErrorMessage="Invalid Price" ForeColor="Red" MaximumValue="99999.99" MinimumValue=".01"
                                SetFocusOnError="True" Type="Double" ValidationGroup="price">*</asp:RangeValidator>
                            <asp:Button ID="btn_PriceAdd" runat="server" Height="20px" Text="Add" OnClick="btn_PriceAdd_Click"
                                ValidationGroup="price" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lbl_qantityExists" runat="server" ForeColor="Red" 
                                style="font-weight: 700" Text="Quantity already added to the List" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="grv_PriceList" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" ForeColor="Black" GridLines="Vertical" 
                                OnRowCancelingEdit="CancelEditPart" OnRowEditing="EditPart" 
                                OnRowUpdating="UpdatePart" Width="613px">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                      <asp:TemplateField>
       <EditItemTemplate>
          <asp:LinkButton ID="lnkUpdate" runat="server"  CommandName="Update" Text="Update"></asp:LinkButton>
          <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
       </EditItemTemplate>
          
       <ItemTemplate>
          <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
       </ItemTemplate>
       </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PriceID" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_PriceidEdit" runat="server" Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Priceid" runat="server" 
                                                Text='<%# Eval("Partpriceid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:Label ID="txt_QtyEdit" runat="server" Enabled="false" Font-Names="Arial" 
                                                Font-Size="Small" Height="20px" Style="font-size: x-small;
                                font-family: Arial, Helvetica, sans-serif" Text='<%# Eval("quantity") %>' Width="15px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_Qty" runat="server" Text='<%# Eval("quantity") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" 
                                            HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle Font-Names="Arial" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_EditRetailPriceEdit" runat="server" Font-Names="Arial" 
                                                Font-Size="Small" Height="20px" Style="font-size:small;
                                font-family: Arial, Helvetica, sans-serif" Text='<%# Eval("price","{0:N2}") %>' 
                                                ValidationGroup="pricechange" Width="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="txt_EditRetailPriceEdit" ErrorMessage="Invalid Price" 
                                                ForeColor="#CC3300" ValidationGroup="pricechange">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                                ControlToValidate="txt_EditRetailPriceEdit" ErrorMessage="Invalid Price" 
                                                ForeColor="Red" MaximumValue="99999.99" MinimumValue=".01" 
                                                SetFocusOnError="True" Type="Double" ValidationGroup="pricechange">*</asp:RangeValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="txt_RetailPrice" runat="server" 
                                                Text='<%# Eval("price","{0:N2}") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Height="35px" 
                                            HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
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
                </ContentTemplate>
                <Triggers>
               
                    <asp:AsyncPostBackTrigger ControlID="btn_PriceAdd" EventName="Click" />
               
                </Triggers>
                </asp:UpdatePanel>
                </td>
                </tr>
            </table>
                <table align="left"  style="vertical-align:top; width: 1183px;">

            <tr>
            <td class="style4" bgcolor="#EFEFEF">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_NoPriceWarning" runat="server" 
                            style="color: #990000; font-weight: 700" Text="Please Add Price to This Part" 
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
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <%--<uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel3" runat="server" />--%>
                    </ProgressTemplate>
                </asp:UpdateProgress>
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


      <script src="/Admin/js/jquery.min.js" type="text/javascript"></script>
    <script src="/Admin/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/Admin/js/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="/Admin/js/jquery.iframe-transport.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.handlerurl = 'handler.ashx?id=' + $(".fileupload").attr("id");
    </script>
    <script src="/Admin/js/jquery.fileupload.js" type="text/javascript"></script>
    <script src="/Admin/js/jquery.fileupload-ui.js" type="text/javascript"></script>
    <script src="/Admin/js/application.js" type="text/javascript"></script>    
  
    </asp:Content>