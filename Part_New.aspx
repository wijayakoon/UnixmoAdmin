<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="NeemoAdmin.Part_New" %>



<%@ Import Namespace="NeemoAdmin.SupportClasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
        }
        .style4
        {
            height: 26px;
            width: 848px;
        }
        .style6
        {
            height: 26px;
            }
        .style7
        {
            height: 26px;
            width: 846px;
        }
        .style8
        {
            height: 26px;
            width: 843px;
        }
        .style9
        {
            height: 26px;
            width: 806px;
        }
        .style10
        {
            width: 806px;
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
   


       

    <table align="left"  style="vertical-align:top; width: 1000px;">
        <tr>
            <td align="center" bgcolor="#CCCCCC" class="style3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000066" 
                    style="font-size: large" Text="ADD PARTS"></asp:Label>
                </td>
        </tr>
        </table>
    <table align="left"  style="vertical-align:top; width: 1000px;">

          <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>
        <tr>
            <td class="style8" bgcolor="#EFEFEF">
                Category</td>
            <td bgcolor="#EFEFEF" class="style2" width="250px">
               
                       <asp:DropDownList ID="drp_Category" runat="server" 
                    Height="20px" Width="350px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style9">
               
                Colour</td>
            <td bgcolor="#EFEFEF" class="style2" width="250px">
               
                       <asp:DropDownList ID="drp_Colour" runat="server" 
                    Height="20px" Width="350px">
                </asp:DropDownList>
               
                
            </td>
        </tr>
      
       <tr>
            <td class="style8" bgcolor="#EFEFEF">
                Side</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_Side" runat="server" 
                    Height="20px" Width="350px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style9">
               
                Part No</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                <asp:TextBox ID="txt_PartNo" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
               
                
            </td>
        </tr>
      
        <tr>
            <td class="style8" bgcolor="#EFEFEF">
                Part Name</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Name" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style10">
                Short Description</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_ShortDescription" runat="server" Width="350px" 
                    MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr valign="top">
            <td class="style3" bgcolor="#EFEFEF">
                Key words</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Keywords" runat="server" TextMode="MultiLine" 
                    Height="200px" Width="444px" MaxLength="8000"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style10">
                Description</td>
            <td bgcolor="#EFEFEF">
                <asp:TextBox ID="TextBox_Description" runat="server" TextMode="MultiLine" 
                    Height="200px" Width="350px" MaxLength="8000"></asp:TextBox>
            </td>
        </tr>
          <tr valign="top">
            <td class="style8" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td bgcolor="#EFEFEF">
                Height:
                <asp:TextBox ID="txt_Height" runat="server" Width="90px" MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="txt_Height" ErrorMessage="Height Required" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                ControlToValidate="txt_Height" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="price">*</asp:RangeValidator>
            &nbsp; Width:
                <asp:TextBox ID="txt_Width" runat="server" Width="90px" MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txt_Width" ErrorMessage="Width Required" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                ControlToValidate="txt_Width" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="price">*</asp:RangeValidator>
                &nbsp;</td>
                <td bgcolor="#EFEFEF" class="style10"></td>
            <td bgcolor="#EFEFEF" >
                Lenght: 
                <asp:TextBox ID="txt_Length" runat="server" Width="90px" MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txt_Length" ErrorMessage="Lenght Required" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                ControlToValidate="txt_Length" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="price">*</asp:RangeValidator>
            &nbsp;Weight (KG):<asp:TextBox ID="txt_Weight" runat="server" Width="101px" 
                    MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txt_Weight" ErrorMessage="Price Required" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator7" runat="server" 
                                ControlToValidate="txt_Weight" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="price">*</asp:RangeValidator>
              </td>
        </tr>
        <%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_New.aspx.cs" Inherits="Neemo.Part_New" %>--%>
      
        <tr valign="top">
            <td class="style8" bgcolor="#EFEFEF">
                </td>
            <td bgcolor="#EFEFEF" class="style2">
                <asp:CheckBox ID="chk_Active" runat="server" Checked="True" />
            </td>
            <td bgcolor="#EFEFEF" class="style9">
                &nbsp;</td>
            <td bgcolor="#EFEFEF" class="style2">
                &nbsp;</td>
        </tr>
        </TABLE>
            <table align="left"  style="vertical-align:top; width: 1000px;">

        <tr>
        <td width="850" colspan="2">
         <div style="width: 480px">
    </div>
    
            <div style="width: 480px">
        <div class="ContainerHeader">
            <H2>UploadFile</H2>
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
        <br />
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

         <td colspan=2 valign=top bgcolor="#CCCCCC">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                
                <table style="width:100%;">
                    <tr>
                        <td class="style6">
                           
                            <H2>Features</H2></td>
                    </tr>
                   
                    <tr>
                        <td class="style6">
                            <asp:DropDownList ID="drp_Features" runat="server" Height="20px" Width="250px">
                            </asp:DropDownList>
                            <asp:Button ID="btn_FeatureAdd" runat="server" Height="20px" 
                                onclick="btn_FeatureAdd_Click" Text="Add" ValidationGroup="feature" />
                            <br />
                            <asp:Label ID="lbl_FeatureExists" runat="server" ForeColor="Red" 
                                style="font-weight: 700" Text="Feature already added to the List" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        
                        <td left;"="" style="text-align:">
                            <asp:GridView ID="grv_FeatureList" runat="server" CellPadding="4" ForeColor="#333333" 
                            OnRowDeleting="grv_FeatureList_RowDeleting"
                                GridLines="None" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="FeatureID" HeaderText="FeatureID" Visible="False" />
                                    <asp:BoundField DataField="Featurename" HeaderText="Featurename" />
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
                        </tr>
                </table>
                </ContentTemplate>
                <Triggers>               
                    <asp:AsyncPostBackTrigger ControlID="btn_PriceAdd" EventName="Click" />               
                </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                <table style="width:100%;">
                    <tr>
                        <td class="style1">
                            <H2>Pricing</H2></td>
                    </tr>
                    <tr>
                        <td class="style6">
                            Qty<br />
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
                            Price[EX.GST]<br />
                            <asp:TextBox ID="txt_Price" runat="server" ValidationGroup="price"></asp:TextBox>
                            <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <uc1:ProcessingInProgressPanel ID="ProcessingInProgressPanel4" runat="server" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txt_Price" ErrorMessage="Price Required" ForeColor="#CC3300" 
                                ValidationGroup="price">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                ControlToValidate="txt_Price" ErrorMessage="Invalid Price" ForeColor="Red" 
                                MaximumValue="99999.99" MinimumValue=".01" SetFocusOnError="True" Type="Double" 
                                ValidationGroup="price">*</asp:RangeValidator>
                            <asp:Button ID="btn_PriceAdd" runat="server" Height="20px" 
                                onclick="btn_PriceAdd_Click" Text="Add" ValidationGroup="price" />
                            <%-- </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btn_PriceAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>--%></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_qantityExists" runat="server" ForeColor="Red" 
                                style="font-weight: 700" Text="Quantity already added to the List" 
                                Visible="False"></asp:Label>
                            <asp:GridView ID="grv_PriceList" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" 
                                OnRowDeleting="grv_PriceList_RowDeleting">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" Visible="False" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                                    <asp:BoundField DataField="DateFrom" DataFormatString="&quot;dd/mm/yyyy&quot;" 
                                        HeaderText="Start Date" Visible="False" />
                                    <asp:BoundField DataField="DateTo" DataFormatString="&quot;dd/mm/yyyy&quot;" 
                                        HeaderText="End Date" Visible="False" />
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
               
                    <asp:AsyncPostBackTrigger ControlID="btn_PriceAdd" EventName="Click" />
               
                </Triggers>
                </asp:UpdatePanel>
                </td>
           </tr> 
           </table>
    <table align="left"  style="vertical-align:top; width: 1000px;">

         <tr>
            <td class="style4" bgcolor="#EFEFEF">
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