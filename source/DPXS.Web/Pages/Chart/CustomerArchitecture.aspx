<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerArchitecture.aspx.cs" Inherits="WebCrm.Web.Pages.Chart.CustomerArchitecture" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户结构分析</title>
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
              <li><a href="Children/CA_CustomerArea.aspx" target="chartFrame">按区域分布</a></li>
              <li><a href="Children/CA_AgeStructure.aspx" target="chartFrame">按年龄层次</a></li>
              <li><a href="Children/CA_Rate.aspx" target="chartFrame">按单位和散客比例</a></li>
              <li><a href="Children/CA_CustomerType.aspx?CaType=source" target="chartFrame">按客户来源</a></li>
              <li><a href="Children/CA_CustomerCategory.aspx" target="chartFrame">按客户类型</a></li>
              <li><a href="Children/CA_CustomerType.aspx?CaType=bussiness" target="chartFrame">按行业</a></li>
          </ul>
       </div>
       
       <div class="charContent">
            <iframe id="chartFrame" name="chartFrame" src="Children/CA_CustomerArea.aspx" frameborder="0" scrolling="auto" width="100%" height="100%"
            style=" min-width:800px; min-height:450px; width: 100%; height:100%;"></iframe>
       </div>        
    </div>    
    </form>
</body>
</html>
