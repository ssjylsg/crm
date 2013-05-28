<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseRecord.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.ExpenseRecord" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消费记录分析</title>
    <link href="ChartCommon.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src="../../Framework/Twilight.js" type="text/javascript"></script>
    <script src="CustomerArchitecture.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="chartCategory">
            <ul>
                <li><a href="Children/ER_Receivable.aspx" target="chartFrame">应收账款分析</a></li>
                <li><a href="Children/ER_ExpenseTrend.aspx" target="chartFrame">客户消费走势</a></li>
                <li><a href="OperatingIncome/ER_IncomeTrend.aspx" target="chartFrame">营业收入组成分析</a></li>
                <li><a href="OperatingIncome/ER_GrossProfitTrend.aspx" target="chartFrame">毛利贡献分析</a></li>
            </ul>
        </div>
        <div class="charContent">
            <iframe id="chartFrame" name="chartFrame" src="Children/ER_Receivable.aspx" frameborder="0"
                scrolling="auto" width="100%" height="100%" style="min-width: 760px; min-height: 450px;
                width: 100%; height: 100%;"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
