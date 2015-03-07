<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Part_Search.aspx.cs" Inherits="NeemoAdmin.Part_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style4
        {
            width: 144px;
        }
        .style7
        {
            width: 54px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">

                   

          
        <tr valign=top>
            <td class="style2" bgcolor="#EFEFEF">
               <table>
                               <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style4" bgcolor="#EFEFEF">
                Category</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_Category" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="CategoryName" 
                    DataValueField="CategoryID" AutoPostBack="True" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="select 0 CategoryID,'Select Category' CategoryName  Union select CategoryID,Category from Category">
                </asp:SqlDataSource>
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                <asp:Button ID="btn_New" runat="server" onclick="btn_New_Click" 
                    Text="New" />
            </td>
        </tr>
        <tr valign=top>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style4" bgcolor="#EFEFEF">
                Part Name</td>
            <td bgcolor="#EFEFEF" class="style7">
                <asp:TextBox ID="txt_Search" runat="server" Width="467px"></asp:TextBox>
                <asp:Button ID="btn_Search" runat="server" onclick="btn_Search_Click" 
                    Text="Search" />
            &nbsp;</td>
            <td bgcolor="#EFEFEF" class="style7">
                &nbsp;</td>
        </tr>
               </table></td>
        </tr>

        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    onrowcommand="GridView_RowCommand" 
                    CellPadding="3" DataSourceID="SqlDataSourceParts" 
                    Font-Names="Arial" GridLines="Vertical" 
                    AllowSorting="True" PageSize="50" Width="0px" Height="16px" 
                    DataKeyNames="PartId">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <EmptyDataTemplate>
                    No Records
                    </EmptyDataTemplate>
                    <Columns>                    
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="PartId" HeaderText="PartId" 
                            SortExpression="PartId" ReadOnly="True" />

                        <asp:BoundField DataField="PartNo" HeaderText="PartNo" 
                            SortExpression="PartNo" />
                        <asp:BoundField DataField="Part" HeaderText="Part" 
                            SortExpression="Part" />                      
                        <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                            SortExpression="Active" />
                        <asp:BoundField DataField="Price" HeaderText="Price"  DataFormatString="{0:c}" 
                            SortExpression="Price" />
                        <asp:BoundField DataField="Category" HeaderText="Category" 
                            SortExpression="Category" />
                        <asp:BoundField DataField="Part" HeaderText="Part" 
                            SortExpression="Part" />
                        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                            SortExpression="CategoryID" />                            
                        
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                               
            <asp:SqlDataSource ID="SqlDataSourceParts" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="sp_searchPart_All" SelectCommandType="StoredProcedure">
                <SelectParameters>                    
                    <asp:ControlParameter ControlID="drp_Category" DefaultValue="0" 
                        Name="CategoryID" PropertyName="SelectedValue" Type="Int32" />

                  <%--  <asp:ControlParameter ControlID="drp_Brand" DefaultValue="0" 
                        Name="BrandId" PropertyName="SelectedValue" Type="Int32" />--%>
                    
                    <asp:ControlParameter ControlID="txt_Search" 
                        Name="Part" PropertyName="Text" Type="String" 
                        DefaultValue=" " />
                </SelectParameters>
            </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
