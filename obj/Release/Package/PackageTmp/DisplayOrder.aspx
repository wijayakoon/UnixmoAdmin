<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DisplayOrder.aspx.cs" Inherits="NeemoAdmin.DisplayOrder" %>
<%@ Register src="~/ProcessingInProgressPanel.ascx" tagname="ProcessingInProgressPanel" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style5 {
            width: 506px;
        }
        .auto-style6 {
            font-size: medium;
            font-weight: bold;
            width: 186px;
        }
        .auto-style7 {
            font-weight: bold;
            text-align: right;
        }
        .auto-style8 {
            text-align: right;
        }
        .auto-style9 {
            width: 186px;
        }
        .auto-style10 {
            width: 410px;
        }
        .auto-style11 {
            width: 69%;
        }
    </style>
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style10">
                <table style="width: 51%;">
                    <tr>
                        <td rowspan="3">
                            <asp:Image ID="Image1" runat="server" Height="71px" Width="86px" ImageUrl="~/Images/invoicelogo.PNG" />
                        </td>
                        <td class="auto-style1"><strong>UNIXMO
</strong>
</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>A: PO Box 97130 Manukau Auckland
</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>M: +64 27592 1032</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                <table class="auto-style11">
                    <tr>
                        <td colspan="3" style="font-weight: 700">TAX INVOICE</td>
                    </tr>
                    <tr>
                        <td>Invoice NO</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_InvoiceNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Invoice Date</td>
                        <td class="auto-style2"></td>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_InvoiceDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table style="width:100%;">
        <tr>
            <td>
                <asp:SqlDataSource ID="sql_OrderHeader" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select * from orderheader
where GUID = @OrderHeaderid">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="OrderHeaderid" QueryStringField="OrderID" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"><strong>Billing Address</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="lbl_BillingCompanyName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_BillingFirstName" runat="server"></asp:Label>
                            <asp:Label ID="lbl_BillingLastName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_BillingAddress" runat="server"></asp:Label>
                            <asp:Label ID="lbl_BillingCity" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="lbl_BillingState" runat="server"></asp:Label>
                <asp:Label ID="lbl_BillingPostCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderHeaderID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="857px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" SortExpression="ProductCode" >
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" >
                        <ItemStyle Width="500px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" DataFormatString="{0:#,##0.##}">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalValue" HeaderText="TotalValue" SortExpression="TotalValue" DataFormatString="{0:#,##0.##}" >
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="get_OrderDetails" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="GUID" QueryStringField="OrderID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
    <table>
        
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style8">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">Net Total</td>
                        <td class="auto-style7">
                            <asp:Label ID="lblNetTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">Shipping Chanrges</td>
                        <td class="auto-style7">                            <asp:Label ID="lbl_ShippingCharges" runat="server"></asp:Label>
</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                            
                        <td class="auto-style6">TAX</td>
                            
                        <td class="auto-style7">                            <asp:Label ID="lbl_Tax" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">Total Invoice Amount</td>
                        <td class="auto-style7">

                                                    <asp:Label ID="lbl_Total" runat="server"></asp:Label></td>

                       
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
