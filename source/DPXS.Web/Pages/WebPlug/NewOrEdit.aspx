<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebPlug.NewOrEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>功能菜单<%= NE=="edit" ? "编辑" : "新增"%>：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                父节点：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtParentName" runat="server" Width="196px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="PlugNameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写名称"
                                    ControlToValidate="PlugNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                编号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="PlugCodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写编号"
                                    ControlToValidate="PlugCodeID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                页面地址：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="PlugWebFileID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                排序：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SortID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SortID"
                                    ErrorMessage="必须为数字" ForeColor="Red" ValidationExpression="\+?[1-9][0-9]*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox TextMode="MultiLine" ID="RemarkID" runat="server" CssClass="input_1"
                                    Width="353px" Height="111px"></asp:TextBox>
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
    </form>
</body>
</html>
