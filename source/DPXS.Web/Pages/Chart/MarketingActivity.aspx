<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketingActivity.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.MarketingActivity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>市场活动分析</title>
    <link href="ChartCommon.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="chartCategory">
            <ul>
                <li><a href="Children/MA_CompanyAction.aspx" target="chartFrame">活动效果</a></li>
                <li><a href="Children/MA_Advertising.aspx"   target="chartFrame">广告效果</a></li>
            </ul>
        </div>
        <div class="charContent">
            <iframe id="chartFrame" name="chartFrame" src="Children/MA_CompanyAction.aspx" frameborder="0"
                scrolling="auto" width="100%" height="100%" style="min-width: 760px; min-height: 450px;
                width: 100%; height: 100%;"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
