<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebCorpContactInfo.NewOrEdit" %>

<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" type="text/css" />
    <link href="../../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.10.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="客户管理->联系人"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                客户名称：
                            </td>
                            <td class="table_l_td">
                                <asp:Label ID="CustomerName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                联系人姓名
                            </td>
                            <td>
                                <asp:TextBox ID="NameID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                性别：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="SexID" runat="server" Height="18px" Width="150px">
                                    <asp:ListItem Text="未知" Value="未知"></asp:ListItem>
                                    <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                联系号码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TelNumberID" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                手机号码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="PhoneNumberID" runat="server" CssClass="input_1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                职位：
                            </td>
                            <td>
                                <asp:TextBox ID="DutyNameID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                生日：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="BirthdayID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                电子邮件：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="EmailID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                QQ：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="QQID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                MSN：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="MSNID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                身份证：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="IdCardID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                地址：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="AddressID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                籍贯：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="NativePlaceID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                个人喜好：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="FavoritesID" runat="server" TextMode="MultiLine" Height="77px" Width="435px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" runat="server" TextMode="MultiLine" Height="77px" Width="435px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交"
                        OnClick="btnSubmit_Click" />
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx?CustomerId=<%=this.CustomerId %>'" />
                  
                </div>
            </div>
        </div>
    </div> 
    </form>
</body>
</html>
