<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebDept.NewOrEdit" %>

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
                                <asp:TextBox ID="txtParentName" runat="server" Width="196px" Enabled="False"  ></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td width="90" align="right" class="table_l_tit">
                                公司：
                            </td>
                            <td class="table_l_td">
                               <asp:DropDownList ID="CompanyID" runat="server" Width="200px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                全称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DeptNameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写全称"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                          <tr>
                            <td width="90" align="right" class="table_l_tit">
                                名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RealNameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*请填写名称"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                部门代码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DeptShortCodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写信息"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                部门编号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DeptCodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*请填写部门编号"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                            <td width="90" align="right" class="table_l_tit">
                                简拼：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="PYCodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*请填写简拼"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                            <td width="90" align="right" class="table_l_tit">
                                部门负责人:
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DeptLeaderID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*请填写负责人"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                          <tr>
                            <td width="90" align="right" class="table_l_tit">
                                联系电话：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TelNoID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*请填写联系号码"
                                    ControlToValidate="TelNoID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                传真号码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="FaxNoID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*请填写传真号码"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                电子邮箱：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="EmailID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*请填写电子邮箱"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                            <td width="90" align="right" class="table_l_tit">
                                排序：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SortID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*请填写信息"
                                    ControlToValidate="DeptNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
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
