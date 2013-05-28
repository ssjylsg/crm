<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebCrm.MvcWeb.Models.LogOnModel>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>LogOn</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <link href="../../Content/login.css" rel="stylesheet" type="text/css" />
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "登录失败，请重试.") %>
    <div class="loginbg">
        <div class="content">
            <div class="login_box">
                <div class="bd">
                    <div class="field">
                        <label>
                            用户名：</label>
                        <%=this.Html.TextBoxFor(m=>m.UserName,new{maxlength="32" ,@class="login-text"}) %>
                    </div>
                    <div class="field">
                        <label>
                            密 码：
                        </label>
                        &nbsp;<%=this.Html.PasswordFor(m => m.Password, new { @class = "login-text" })%>
                    </div>
                    <div class="field">
                        <label>
                            验证码：</label>
                        <%=this.Html.TextBoxFor(m=>m.ValidCode,new{ @class="login-yzm", maxlength="4"}) %>
                        <img style="cursor: pointer;" width="35px" height="18px" id="imgCode" src="../../ValidCode.aspx"
                            align="absmiddle" onclick="this.src+='?'" clientidmode="Inherit" />
                    </div>
                    <div class="submit">
                        <input type="submit" value="登 录" class="J_Submit" />
                        <input name="重置" type="reset" class="J_Submit" value="重 置" />
                        <%--<span id="shortcut"class="shortcut">创建桌面快捷方式</span>--%>
                    </div>
                </div>
                <div class="footer">
                    版权所有 浙江深大
                </div>
                <!--container-->
                <input id="hdAct" name="hdAct" type="hidden" />
            </div>
        </div>
    </div>
    <% } %>
    <script language="javascript" type="text/javascript">
        var result = '<%=ViewData["Result"] %>';
        if (result != '') {
            alert(result);
        }
    
    
    </script>
</body>
</html>
