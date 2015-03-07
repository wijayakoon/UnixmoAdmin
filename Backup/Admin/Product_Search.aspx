<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product_Search.aspx.cs" Inherits="Neemo.Admin.Product_Search" %>
<%@ Register src="../UserControls/ProcessingInProgressPanel.ascx" tagname="processinginprogresspanel" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 88px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr valign=middle>                        
            <td>Filter : <asp:TextBox ID="TextBox_Search" runat="server" Height="22px" Width="222px"></asp:TextBox> 
                                    <asp:Button ID="btn_Search" runat="server" style="margin-left: 81px" 
                                        Text="Search" onclick="btn_Search_Click" />
                                    <asp:Button ID="btn_New" runat="server" style="margin-left: 81px" 
                                        Text="New Product" onclick="btn_New_Click" />
            </td>
            <td>&nbsp;</td>
            <td></td>
            
        </tr>
         <tr>
            
            <td>
                        <asp:GridView ID="gv_Products" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="ProductID" 
                            ForeColor="#333333" GridLines="None" onrowcommand="GridView_RowCommand" 
                            Width="1026px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                                    InsertVisible="False" ReadOnly="True" SortExpression="ProductID"><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                <asp:BoundField DataField="Part" HeaderText="Product " 
                                    SortExpression="Part" ><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                      <asp:BoundField DataField="WreckNo" HeaderText="WreckNo " 
                                    SortExpression="WreckNo" ><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="PartNo" HeaderText="Part No " 
                                    SortExpression="PartNo" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="Price" HeaderText="Price "  DataFormatString="{0:c}"
                                    SortExpression="Price" ><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Qty " 
                                    SortExpression="Qty" ><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                                    SortExpression="Active" ><HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" /> </asp:CheckBoxField>
                              
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
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT ProductID,Product,Active,Image,EffectiveDateFrom,EffectiveDateTo,CreatedDateTime,DeletedDateTime FROM Product ORDER BY [Product]">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
