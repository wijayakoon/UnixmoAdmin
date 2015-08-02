<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Provider_Search.aspx.cs" Inherits="NeemoAdmin.Provider_Search" %>
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
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            width: 144px;
            height: 21px;
        }
        .auto-style3 {
            width: 54px;
            height: 21px;
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
                Provider ID</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                <asp:TextBox ID="txt_ProviderID" runat="server" Width="467px">0</asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                &nbsp;</td>
        </tr>
                               <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style4" bgcolor="#EFEFEF">
                Provider name</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                <asp:TextBox ID="txt_ProviderName" runat="server" Width="467px"></asp:TextBox>
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                &nbsp;</td>
        </tr>
                               <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style4" bgcolor="#EFEFEF">
                Provider Type</td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_ProviderTypes" runat="server" AutoPostBack="True" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                &nbsp;</td>
        </tr>
               </table></td>
        </tr>

         <tr valign=top>
            <td class="style2" bgcolor="#EFEFEF">
               <table>
                               <tr>
            <td class="style2" bgcolor="#EFEFEF">
                &nbsp;</td>
            <td class="style4" bgcolor="#EFEFEF">
                Service Type </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                       <asp:DropDownList ID="drp_ServiceTypes" runat="server" 
                   AutoPostBack="True" 
                    Height="20px" Width="460px">
                </asp:DropDownList>
               
                
            </td>
            <td bgcolor="#EFEFEF" class="style7">
               
                &nbsp;</td>
        </tr>
        <tr valign=top>
            <td class="auto-style1" bgcolor="#EFEFEF">&nbsp;</td>
            <td class="auto-style2" bgcolor="#EFEFEF">
                Street
                &nbsp;&nbsp;</td>
            <td bgcolor="#EFEFEF" class="auto-style3"> 
                <asp:TextBox ID="txt_Street" runat="server"></asp:TextBox>
                </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
              
                &nbsp;</td>
        </tr>
                    <tr valign=top>
            <td class="auto-style1" bgcolor="#EFEFEF"></td>
            <td class="auto-style2" bgcolor="#EFEFEF">
                Street
                &nbsp;</td>
            <td bgcolor="#EFEFEF" class="auto-style3"> 
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                        </td>
        </tr>
                    <tr valign=top>
            <td class="auto-style1" bgcolor="#EFEFEF">&nbsp;</td>
            <td class="auto-style2" bgcolor="#EFEFEF">
                City
                &nbsp;&nbsp;&nbsp;</td>
            <td bgcolor="#EFEFEF" class="auto-style3"> 
                <asp:TextBox ID="txt_City" runat="server"></asp:TextBox>
                        </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                        </td>
        </tr>
             <tr valign=top>
            <td class="auto-style1" bgcolor="#EFEFEF">&nbsp;</td>
            <td class="auto-style2" bgcolor="#EFEFEF">
                State
                &nbsp;&nbsp;</td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                <asp:TextBox ID="txt_State" runat="server"></asp:TextBox>
                 </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                &nbsp;</td>
        

        <tr valign=top>
            <td class="auto-style1" bgcolor="#EFEFEF">
                </td>
            <td class="auto-style2" bgcolor="#EFEFEF">
                <asp:Button ID="Button2" runat="server" onclick="btn_Search_Click" 
                    Text="Search" />
            </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                </td>
            <td bgcolor="#EFEFEF" class="auto-style3">
                </td>
        </tr>
               </table></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_Provider" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    onrowcommand="GridView_RowCommand" 
                    CellPadding="3"
                    Font-Names="Arial" GridLines="Vertical" 
                    AllowSorting="True" PageSize="50" Width="0px" Height="16px" 
                    DataKeyNames="ProviderId">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <EmptyDataTemplate>
                    No Records
                    </EmptyDataTemplate>
                    <Columns>                    
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ProviderId" HeaderText="ProviderId" SortExpression="ProviderId" ReadOnly="True" />
                        <asp:BoundField DataField="ProviderName" HeaderText="ProviderName" SortExpression="ProviderName" />
                        <asp:BoundField DataField="Street" HeaderText="Street"  SortExpression="Street" />                      
                        <asp:BoundField DataField="City" HeaderText="City"  SortExpression="City" />                      
                        <asp:BoundField DataField="State" HeaderText="State"  SortExpression="State" />                      
                        <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
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
                               
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
