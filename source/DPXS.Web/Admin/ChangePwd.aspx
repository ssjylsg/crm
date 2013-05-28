<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="WebCX.Web.Admin.ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/right.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="修改密码"></asp:Label>：
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                当前用户：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtName" runat="server" Enabled="false" CssClass="input_1" Width="200px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                原始密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtOriPwd" runat="server" CssClass="input_1" TextMode="Password" 
                                    Width="200px"></asp:TextBox> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="*请填写原始密码" ControlToValidate="txtOriPwd" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                新密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPwd" runat="server" CssClass="input_1" TextMode="Password" 
                                    Width="200px"></asp:TextBox> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*请填写密码" ControlToValidate="txtPwd" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                确认密码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtPwd2" runat="server" CssClass="input_1" TextMode="Password" 
                                    Width="200px"></asp:TextBox> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*请填写密码" ControlToValidate="txtPwd2" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ErrorMessage="两次密码输入不一致" ControlToValidate="txtPwd2" ControlToCompare="txtPwd" 
                                    ForeColor="Red"></asp:CompareValidator>
                            </td>
                        </tr>                        
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交" 
                        onclick="btnSubmit_Click" />
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="javascript:history.go(-1);" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
