<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebTemplate.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
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
                                模板名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TemplateNameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写合同名称"
                                    ControlToValidate="TemplateNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                模板编号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TemplateCodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写合同编号"
                                    ControlToValidate="TemplateCodeID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                模板类型：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="MsgTypeID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                模板内容：
                            </td>
                            <td class="table_l_td">
                                <div>
                                    模板可选字段：姓名： [Name] 生日：[Birthday] 节假日：[HolidayName]</div>
                                <asp:TextBox TextMode="MultiLine" ID="MsgContentID" runat="server" CssClass="input_1"
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
    <script type="text/javascript">
        $(function () {
            var customerId = '<%=MsgTypeID.ClientID %>';
            $('#' + customerId).change(function () {
                var selectValue = $('#' + customerId).find("option:selected").text();
                var msg = "";
                if (selectValue == "生日提醒") {

                    msg = "   亲爱的Name客户您好，您马上要在Birthday过生日了，提前祝您生日愉快！";
                }
                else {
                    msg = "   亲爱的Name客户您好，HolidayName节假日马上就要到了，提前祝您节日愉快！";
                }
                $('#<%=MsgContentID.ClientID %>').val(msg);
            });
        });
    </script>
    </form>
</body>
</html>
