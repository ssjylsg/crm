<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CA_AgeStructureUC.ascx.cs" Inherits="WebCrm.Web.Pages.Chart.ChartUC.CA_AgeStructureUC" %>

<!-- 客户结构分析:年龄层次 -->
<span>客户结构分析:年龄层次</span>
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