<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebSysRole.NewOrEdit" %>

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
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="新增角色"></asp:Label>：
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                角色名：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtName" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*请填写角色名" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="90" align="right" class="table_l_tit">
                                状态：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ddlFlag" runat="server"  CssClass="input_1" Width="200px">
                                    <asp:ListItem Selected="True" Value="1">启用</asp:ListItem>
                                    <asp:ListItem Value="0">停用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr> --%>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="txtReamrk" runat="server" CssClass="input_1" Font-Size="14px" 
                                    Height="60px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交" 
                        onclick="btnSubmit_Click" />
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx'" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
