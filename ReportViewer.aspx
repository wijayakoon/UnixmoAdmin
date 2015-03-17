<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="NeemoAdmin.ReportViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="99%" 
        Height="864px">
    <LocalReport ReportPath="SalesInvoice.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>
    </rsweb:ReportViewer>    

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="get_OrderDetails" SelectCommandType="StoredProcedure">
    <selectparameters>
        <asp:QueryStringParameter DefaultValue="485229e4-d036-4bd0-a0c9-05824d0080fd" 
        Name="GUID" QueryStringField="OrderID" 
        Type="String" />
    </selectparameters>
</asp:SqlDataSource>
</asp:Content>



<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
<asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="get_OrderDetails" SelectCommandType="StoredProcedure">
<selectparameters>
<asp:QueryStringParameter DefaultValue="485229e4-d036-4bd0-a0c9-05824d0080fd" Name="GUID" QueryStringField="OrderID" Type="String" />
</selectparameters>
</asp:SqlDataSource>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="SalesInvoice.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="NeemoAdmin.NNS_UNIXMODataSetTableAdapters.get_OrderDetailsTableAdapter"></asp:ObjectDataSource>
   
</asp:Content>--%>