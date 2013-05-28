<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CA_CustomerAreaUC.ascx.cs" Inherits="WebCrm.Web.Pages.Chart.ChartUC.CustomerAreaUC" %>

<!-- 客户结构分析:区域分布 -->
<asp:Chart ID="Chart1" runat="server">
    <Series>
        <asp:Series Name="Series1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>

<span>客户结构分析:区域分布</span>
