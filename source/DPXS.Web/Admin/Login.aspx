<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DPXS.Web.Admin.Login" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>中惠旅CRM</title>
    <link href="share/login.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <%--<script src="js/jquery.ext.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(function () {
            var txtUserName = $('#txtUserName');
            var txtPassword = $('#txtPassword');
            var txtValidCode = $('#txtValidCode');
            var btnSubmit = $('#btnSubmit');

            //txtUserName.val('请输入用户名').focus(function() { $(this).val(''); });
            //txtPassword.val('123456').focus(function() { $(this).val(''); });
            // txtValidCode.val('请输入验证码').focus(function() { $(this).val(''); });

            // 用户登录
            btnSubmit.click(function () {
                var hdAct = $('#hdAct');

                if (txtUserName.valueIsEmpty() || txtUserName.val() == '请输入用户名') {
                    alert('请输入用户名！');
                    txtUserName.focus();
                    return false;
                }

                if (txtPassword.valueIsEmpty()) {
                    alert('请输入密码！');
                    txtPassword.focus();
                    return false;
                }

                if (txtValidCode.valueIsEmpty() || txtValidCode.val() == '请输入验证码') {
                    alert('请输入验证码！');
                    txtValidCode.focus();
                    return false;
                }

                hdAct.val('login');
            });

            //创建桌面快捷方式
            //$('#shortcut').click(function () {
            //    try {
            //        var WshShell = new ActiveXObject("WScript.Shell");
            //        var oUrlLink = WshShell.CreateShortcut(WshShell.SpecialFolders("Desktop") + "\\" + "Web领导查询系统" + ".url");
            //        oUrlLink.TargetPath = location.href;
            //        oUrlLink.Save();
            //    } catch (e) {
            //        alert("当前IE安全级别不允许操作！");
            //    } 
            //});
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginbg">
        <div class="content">
            <div class="login_box">
                <div class="bd">
                    <div class="field">
                        <label>
                            用户名：</label>
                        <input id="txtUserName" name="txtUserName" maxlength="32" class="login-text" type="text"
                            value="" />
                    </div>
                    <div class="field">
                        <label>
                            密   码： </label>
                        &nbsp;<input id="txtPassword" name="txtPassword" maxlength="32" type="password" class="login-text" />
                    </div>
                    <div class="field">
                        <label>
                            验证码：</label>
                        <input id="txtValidCode" name="txtValidCode" type="text" class="login-yzm" maxlength="4" />
                        <img style="cursor: pointer;" width="35px" height="18px" id="imgCode" src="/admin/ValidCode.aspx"
                            align="absmiddle" onclick="this.src+='?'" clientidmode="Inherit" />
                    </div>
                    <div class="submit">
                        <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="J_Submit" OnClick="btnSubmit_Click" />
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
    </form>
</body>
</html>
