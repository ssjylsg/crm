<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DPXS.Web.Admin._default" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台管理系统</title>
    <link href="share/style.css" rel="stylesheet" type="text/css" />
    <link href="share/top.css" rel="stylesheet" type="text/css" />
     <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script type="text/javascript">
        var url = location.href;
        var index = url.indexOf('jsessionid');
        if (index != -1) {
            var sid = url.substr(index + 11);
            document.cookie = "JSESSIONID=" + sid + ";path=/;";
        }

        function resizeFrame() {
            document.getElementById("mainFrame").style.height = document.body.offsetHeight - document.getElementById("topArea").offsetHeight - 1 + "px";
        }
        $(window).load(function () {
            resizeFrame();
            tick();
        });
        $(window).resize(function () {
            resizeFrame();
        });
        function refresh() {
            if (window.XMLHttpRequest) {
                http_request = new XMLHttpRequest();
            } else if (window.ActiveXObject) {
                http_request = new ActiveXObject("Microsoft.XMLHTTP");
            }
            var linkurl = '/xxg_manager/manage/login!loginRefresh.htm';
            http_request.open("POST", linkurl, false);
            http_request.send(null);
            parent.mainFrame.location.reload();
        }
        //完整显示当前时间
        function tick() {
            var hours, minutes, seconds, xfile;
            var intHours, intMinutes, intSeconds;
            var today, theday;
            today = new Date();
            function initArray() {
                this.length = initArray.arguments.length
                for (var i = 0; i < this.length; i++)
                    this[i + 1] = initArray.arguments[i]
            }
            var d = new initArray("星期日 ", "星期一 ", "星期二 ", "星期三 ", "星期四 ", "星期五 ", "星期六 ");
            theday = today.getFullYear() + "年" + [today.getMonth() + 1] + "月" + today.getDate() + "日 " + d[today.getDay() + 1];
            intHours = today.getHours();
            intMinutes = today.getMinutes();
            intSeconds = today.getSeconds();
            if (intHours == 0) {
                hours = "12:";
                xfile = "午夜 ";
            } else if (intHours < 12) {
                hours = intHours + ":";
                xfile = "上午 ";
            } else if (intHours == 12) {
                hours = "12:";
                xfile = "正午 ";
            } else {
                intHours = intHours - 12
                hours = intHours + ":";
                xfile = "下午 ";
            }
            if (intMinutes < 10) {
                minutes = "0" + intMinutes + ":";
            } else {
                minutes = intMinutes + ":";
            }
            if (intSeconds < 10) {
                seconds = "0" + intSeconds + " ";
            } else {
                seconds = intSeconds + " ";
            }
            timeString = "&nbsp;当前时间：" + theday + xfile + hours + minutes + seconds;
            document.getElementById("Clock").innerHTML = timeString;
            //Clock.innerHTML = timeString;
            window.setTimeout("tick();", 100);
        }
    </script>
    <style type="text/css">
        html
        {
            height: 100%;
            overflow: hidden;
        }
        body
        {
            height: 100%;
        }
    </style>
</head>
<body>
    <div id="topArea" class="topArea">
        <div class="logobg">
            <div class="topCol">
                <div class="logo">
                </div>
                <div class="logoCol2">
                    <div class="logoCol2A">
                        <ul>
                            <li><a href="Welcome.htm" target="rightFrame">首页</a></li>
                            <li><a href="javascript:history.go(-1);">后退</a></li>
                            <li><a href="javascript:history.go(1);">前进</a></li>
                            <li><a href="#" onclick="javascript:window.location.reload(); ">刷新</a></li>
                            <li><a href="ChangePwd.aspx" target="rightFrame">密码修改</a></li>
                            <li><a href="Login.aspx?act=out" onclick="return confirm('确认退出？')">注销</a></li>
                            <li class="login">
                                <%=this.CurrentOperatorUser != null ?CurrentOperatorUser.OperatorName:string.Empty%>，欢迎您的登录！</li>
                            <li>
                                <div id="Clock">
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="logoCol2B">
                        <span align="right" class="clock" id="Clock"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--主体框架Begin-->
    <iframe id="mainFrame" name="mainFrame" src="main.htm" frameborder="0" scrolling="no"
        style="width: 100%;"></iframe>
    <!--主体框架End-->
</body>
</html>
