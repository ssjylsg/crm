<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebUser.NewOrEdit" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="新增用户"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                用户：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="StuffID" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                用户名：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtName" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写用户名"
                                    ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPwd" runat="server" CssClass="input_1" TextMode="Password" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写密码"
                                    ControlToValidate="txtPwd" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                确认密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPwd2" runat="server" CssClass="input_1" TextMode="Password" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*请填写密码"
                                    ControlToValidate="txtPwd2" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码输入不一致"
                                    ControlToValidate="txtPwd2" ControlToCompare="txtPwd" ForeColor="Red"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                真实姓名：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtRealName" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写真实姓名"
                                    ControlToValidate="txtRealName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                状态：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ddlFlag" runat="server" CssClass="input_1" Width="200px">
                                    <asp:ListItem Selected="True" Value="1">启用</asp:ListItem>
                                    <asp:ListItem Value="0">停用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                级别：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ddlAdminFlag" runat="server" CssClass="input_1" Width="200px">
                                    <asp:ListItem Selected="True" Value="0">非管理员</asp:ListItem>
                                    <asp:ListItem Value="1">管理员</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                邮箱：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtMail" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMail"
                                    ErrorMessage="请输入正确的邮箱格式" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                手机号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobile"
                                    ErrorMessage="手机号必须为数字" ForeColor="Red" ValidationExpression="\+?[0-9]*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtReamrk" runat="server" CssClass="input_1" Font-Size="14px" Height="60px"
                                    TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交"
                        OnClick="btnSubmit_Click" />
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx'" />
                </div>
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=StuffID.ClientID %>').click(function () {
                var selectText = $(this).find('option:selected').text();
                if (selectText == '请选择') {
                    selectText = '';
                }
                $('#<%=this.txtRealName.ClientID %>').val(selectText);
            });
            $('#<%=txtName.ClientID %>').blur(function () {
                var loginName = $(this).val();
                if (loginName != '') {
                    var url = '<%=AspNetHelper.WebUrl() + "/Pages/CommonHandler/UserHandler.ashx" %>';
                    $.post(url, { type: 'existname', name: loginName, id: '<%=this.Id %>' }, function (data) {
                        if (data.Success) {
                            if (data.Data) {
                                alert("用户名“" + loginName + '”已经存在');
                                return false;
                            }
                        }

                    }, 'json');
                }
            });

        });
    </script>
    </form>
</body>
</html>
