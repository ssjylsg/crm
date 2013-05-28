<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DPXS.Web.Admin.Admin.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/right.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.js" type="text/javascript"></script>

    <script src="/js/jquery.ext.js" type="text/javascript"></script>

    <script type="text/javascript">
        function checkForm() {
            var txtUserName = $('#txtUserName');
            var txtPassword = $('#txtPassword');
            var id = '<%=Id %>';

            if (txtUserName.valueIsEmpty()) {
                alert('请输入用户名！');
                txtUserName.focus();
                return false;
            }
            if (txtPassword.valueIsEmpty() && parseInt(id) == 0) {
                alert('请输入密码！');
                txtPassword.focus();
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>管理员<%=Id > 0 ? "修改" : "添加" %>：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tool_1">
                </div>
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                账号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="input_1" TextMode="Password"></asp:TextBox> 注：为空表示不修改
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                姓名：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtRealName" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                电话：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtTel" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                手机：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                邮箱：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                QQ：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtQQ" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtReamrk" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                状态：
                            </td>
                            <td class="table_l_td">
                                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="Button1" runat="server" class="btn02" Text="提交" OnClientClick="return checkForm();"
                        OnClick="btnSubmit_Click" />
                    <input type="button" class="btn02" value="返回" onclick="history.go(-1);" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
