﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GreenRating_Search.aspx.cs" Inherits="NeemoAdmin.GreenRating_Search" %>
<%@ Register src="~/ProcessingInProgressPanel.ascx" tagname="processinginprogresspanel" tagprefix="uc1" %>
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
            </td>
            <td>&nbsp;</td>
            <td></td>
            
        </tr>
         <tr>
            
            <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="GreenRatingID" DataSourceID="SqlDataSource1" 
                            ForeColor="#333333" GridLines="None" onrowcommand="GridView_RowCommand" 
                            Width="1026px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="GreenRatingID" HeaderText="GreenRatingID" 
                                    InsertVisible="False" ReadOnly="True" SortExpression="GreenRatingID" />
                                <asp:BoundField DataField="GreenRating" HeaderText="GreenRating" 
                                    SortExpression="GreenRating" />
                                <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                                    SortExpression="Active" />
                                <asp:BoundField DataField="CreatedDateTime" HeaderText="CreatedDateTime" 
                                    SortExpression="CreatedDateTime" />
                                <asp:BoundField DataField="DeletedDateTime" HeaderText="DeletedDateTime" 
                                    SortExpression="DeletedDateTime" />
                                <asp:BoundField DataField="EffectiveDateFrom" HeaderText="EffectiveDateFrom" 
                                    SortExpression="EffectiveDateFrom" />
                                <asp:BoundField DataField="EffectiveDateTo" HeaderText="EffectiveDateTo" 
                                    SortExpression="EffectiveDateTo" />
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
                    SelectCommand="SELECT GreenRatingID,GreenRating,Active,Image,EffectiveDateFrom,EffectiveDateTo,CreatedDateTime,DeletedDateTime FROM GreenRating ORDER BY [GreenRating]">
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
