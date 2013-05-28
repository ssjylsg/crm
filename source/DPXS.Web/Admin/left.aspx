<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="DPXS.Web.Admin.left" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/left.css" rel="stylesheet" type="text/css" />
</head>
<body class="webBg">
    <div class="leftArea" id="leftmenu">
        <%--        <div class="l_menu_1">
            <h3><a class="menu_1_on">【固定】用户管理</a></h3>
            <ul>
                <li class="menu_2_off"><a href="Admin/Edit.aspx" target="rightFrame">添加管理员</a></li>
                <li class="menu_2_off"><a href="Admin/List.aspx" target="rightFrame">管理员列表</a></li>
            </ul>
        </div>

        <div class="l_menu_1">
            <h3><a class="menu_1_on">【固定】检票大屏显示</a></h3>
            <ul>
                <li class="menu_2_off"><a href="../Pages/ParkShow/ParkSet.aspx" target="rightFrame">景点设置</a></li>
                <li class="menu_2_off"><a href="../Pages/ParkShow/ParkPreview.aspx" target="_blank">预览</a></li>
            </ul>
        </div>

        <div class="l_menu_1">
            <h3><a class="menu_1_on">【固定】报表管理</a></h3>
            <ul>
                <li class="menu_2_off"><a href="../Pages/WebReportCategory/List.aspx" target="rightFrame">报表类别</a></li>
                <li class="menu_2_off"><a href="../Pages/WebReportInfo/List.aspx" target="rightFrame">报表模板</a></li>
            </ul>
        </div>

        <div class="l_menu_1">
            <h3><a class="menu_1_on">【固定】权限管理</a></h3>
            <ul>
                <li class="menu_2_off"><a href="../Pages/WebSysFunctions/List.aspx" target="rightFrame">功能菜单</a></li>                
                <li class="menu_2_off"><a href="../Pages/WebLoginInfo/List.aspx" target="rightFrame">用户管理</a></li>
                <li class="menu_2_off"><a href="../Pages/WebSysRole/List.aspx" target="rightFrame">角色管理</a></li>
            </ul>
        </div>
        --%>
    </div>
    <script src="<%=AspNetHelper.WebUrl()%>/Scripts/json2.js" type="text/javascript"></script>
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src="js/left.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
           getMyMenu('<%=AspNetHelper.WebUrl()+"/Pages/CommonHandler/PagePlug.ashx" %>');
        });
    </script>
</body>
</html>
