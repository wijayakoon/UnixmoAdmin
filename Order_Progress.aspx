
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Order_Progress.aspx.cs" Inherits="NeemoAdmin.Order_Progress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style3
        {
            width: 133px;
        }
        .style4
        {
            height: 59px;
            color: #FFFFFF;
        }
        .style5
        {
            height: 59px;
            width: 391px;
        }
        .style6
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <table style="width:500;">
                    <tr>
                        <td class="style4">
                            Select Order Status</td>
                        <td class="style5">
                            <asp:DropDownList ID="drp_ServiceCategory" runat="server" 
                                DataSourceID="SqlDataSource2" DataTextField="OrderStatus" 
                                DataValueField="OrderStatusID" Height="21px" style="margin-left: 0px" 
                                Width="347px" AutoPostBack="True" CssClass="style6">
                            </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT * FROM [OrderStatus]">
                </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" colspan="2">
                            <asp:Panel ID="pnl_EditOrder" runat="server" Visible="False" 
                                style="background-color: #CCCCCC" Width="500px">
                                <br />
                                <strong>&nbsp;Update Order Status</strong><br />
                                <table style="width:100%;">
                                    <tr>
                                        <td class="style3">
                                            Order ID</td>
                                        <td>
                                            <asp:Label ID="lbl_OrderID" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            OrderStatus</td>
                                        <td>
                                            <asp:DropDownList ID="drp_OrderStatus_Edit" runat="server" AutoPostBack="True" 
                                                DataSourceID="SqlDataSource4" DataTextField="OrderStatus" 
                                                DataValueField="OrderStatusID" Height="21px" style="margin-left: 0px" 
                                                Width="347px">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                                SelectCommand="SELECT * FROM [OrderStatus]"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="btn_UpdateOrder" runat="server" Text="Update" 
                                                onclick="btn_UpdateOrder_Click" />
                                            &nbsp;<asp:Button ID="btn_CancelUpdate" runat="server" Text="Cancel" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                           <asp:GridView ID="grv_PriceList" runat="server" CellPadding="4" 
                                AutoGenerateColumns="False" Width="3500px" 
                                OnEditCommand="GridView_RowCommand" DataKeyNames="OrderHeaderID" 
                                DataSourceID="SqlDataSource3" AllowSorting="True" EnableSortingAndPagingCallbacks="True" 
                                PageSize="20" ShowFooter="True"
                                OnSelectedIndexChanged="grv_PriceList_SelectedIndexChanging" 
                                onrowcommand="GridView_RowCommand" ForeColor="#333333" GridLines="None" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>                                    
                                    <asp:ButtonField Text="Invoice" CommandName="ViewInvoice" ><HeaderStyle Width="50px" /> </asp:ButtonField>                                 
                                    <asp:ButtonField Text="Update" CommandName="Select" />
                                     <asp:BoundField DataField="GUID" HeaderText="Invoice GUID" 
                                        SortExpression="GUID" Visible="true" />
                                        <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice No" 
                                        InsertVisible="False" ReadOnly="True" SortExpression="InvoiceNumber" 
                                        Visible="true" ><HeaderStyle Width="70px" /></asp:BoundField>
                                        <asp:BoundField DataField="Billing_Email" HeaderText="Billing_Email" 
                                        SortExpression="Billing_Email" Visible="true" />
                                        <asp:BoundField DataField="OrderStatusID" HeaderText="OrderStatusID" 
                                        SortExpression="OrderStatusID" Visible="false" />
                                      <asp:BoundField DataField="orderstatus" HeaderText="Orderstatus" FooterStyle-HorizontalAlign="Left"
                                        SortExpression="orderstatus" >
<FooterStyle HorizontalAlign="Left"></FooterStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RegistrationID" HeaderText="RegistrationID" 
                                        SortExpression="RegistrationID" Visible="False" />
                                    <asp:BoundField DataField="RecordSourceIP" HeaderText="RecordSourceIP" 
                                        SortExpression="RecordSourceIP" Visible="False" />
                                    <asp:BoundField DataField="TotalInvoice" HeaderText="TotalInvoice" 
                                        SortExpression="TotalInvoice" DataFormatString="{0:c}"/>
                                    <asp:BoundField DataField="TaxTotal" HeaderText="TaxTotal" 
                                        SortExpression="TaxTotal" Visible="False" DataFormatString="{0:c}"/>
                                    <asp:BoundField DataField="ShippingCharges" HeaderText="ShippingCharges" 
                                        SortExpression="ShippingCharges" Visible="False" />
                                    <asp:BoundField DataField="Handlingcharges" HeaderText="Handlingcharges" 
                                        SortExpression="Handlingcharges" Visible="False" />
                                    
                                    <asp:BoundField DataField="Billing_LastName" HeaderText="Billing_LastName" 
                                        SortExpression="Billing_LastName" />
                                    <asp:BoundField DataField="Billing_FirstName" HeaderText="Billing_FirstName" 
                                        SortExpression="Billing_FirstName" />
                                    <asp:BoundField DataField="Billing_CompanyName" 
                                        HeaderText="Billing_CompanyName" SortExpression="Billing_CompanyName" 
                                        Visible="False" />
                                    <asp:BoundField DataField="Billing_Address" HeaderText="Billing_Address" 
                                        SortExpression="Billing_Address" />
                                    <asp:BoundField DataField="Billing_City" HeaderText="Billing_City" 
                                        SortExpression="Billing_City" />
                                    <asp:BoundField DataField="Billing_State" HeaderText="Billing_State" 
                                        SortExpression="Billing_State" Visible="False" />
                                    <asp:BoundField DataField="Billing_PostCode" HeaderText="Billing_PostCode" 
                                        SortExpression="Billing_PostCode" Visible="False" />
                                    <asp:BoundField DataField="Billing_Country" HeaderText="Billing_Country" 
                                        SortExpression="Billing_Country" Visible="False" />
                                    <asp:BoundField DataField="Billing_Email" HeaderText="Billing_Email" 
                                        SortExpression="Billing_Email" Visible="False" />
                                    <asp:BoundField DataField="Billing_Phone" HeaderText="Billing_Phone" 
                                        SortExpression="Billing_Phone" />
                                    <asp:BoundField DataField="Billing_Mobile" HeaderText="Billing_Mobile" 
                                        SortExpression="Billing_Mobile" />
                                    <asp:BoundField DataField="Billing_Fax" HeaderText="Billing_Fax" 
                                        SortExpression="Billing_Fax" Visible="False" />
                                    <asp:BoundField DataField="Shipping_FirstName" HeaderText="Shipping_FirstName" 
                                        SortExpression="Shipping_FirstName" />
                                    <asp:BoundField DataField="Shipping_LastName" HeaderText="Shipping_LastName" 
                                        SortExpression="Shipping_LastName" />
                                    <asp:BoundField DataField="Shipping_CompanyName" 
                                        HeaderText="Shipping_CompanyName" SortExpression="Shipping_CompanyName" 
                                        Visible="False" />
                                    <asp:BoundField DataField="Shipping_Address" HeaderText="Shipping_Address" 
                                        SortExpression="Shipping_Address" />
                                    <asp:BoundField DataField="Shipping_City" HeaderText="Shipping_City" 
                                        SortExpression="Shipping_City" />
                                    <asp:BoundField DataField="Shipping_State" HeaderText="Shipping_State" 
                                        SortExpression="Shipping_State" Visible="False" />
                                    <asp:BoundField DataField="Shipping_PostCode" HeaderText="Shipping_PostCode" 
                                        SortExpression="Shipping_PostCode" />
                                    <asp:BoundField DataField="Shipping_Country" HeaderText="Shipping_Country" 
                                        SortExpression="Shipping_Country" Visible="False" />
                                    <asp:BoundField DataField="Shipping_Email" HeaderText="Shipping_Email" 
                                        SortExpression="Shipping_Email" Visible="False" />
                                    <asp:BoundField DataField="Shipping_Phone" HeaderText="Shipping_Phone" 
                                        SortExpression="Shipping_Phone" />
                                    <asp:BoundField DataField="Shipping_Mobile" HeaderText="Shipping_Mobile" 
                                        SortExpression="Shipping_Mobile" />
                                    <asp:BoundField DataField="Shipping_Fax" HeaderText="Shipping_Fax" 
                                        SortExpression="Shipping_Fax" Visible="False" />
                                    <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                                        SortExpression="Active" />
                                    <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                                        SortExpression="DateCreated" />
                                    <asp:BoundField DataField="DateDeleted" HeaderText="DateDeleted" 
                                        SortExpression="DateDeleted" Visible="False" />
                                 
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    
                    SelectCommand="SELECT Oh.*,oh.Totalamount + oh.TaxTotal TotalInvoice,os.orderstatus FROM [OrderHeader] OH
inner join OrderStatus OS on OH.OrderstatusID= Os.OrderstatusID
WHERE (OH.OrderstatusID = @OrderstatusID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drp_ServiceCategory" DefaultValue="1" 
                            Name="OrderstatusID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
