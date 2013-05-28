<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebshipCard.NewOrEdit" %>

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
    <script src="<%=AspNetHelper.WebUrl()%>/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">

        $().ready(function () {
            $("#form1").validate({
                rules: {

                    CardCodeID: "required",
                    ValidDateID: {
                        required: true,
                        dateISO: true
                    },
                    CardTypeID: {
                        required: true
                    }
                },
                messages: {
                    CardCodeID: "<span style=\"color:#ff0000;\">*请输入编号</span>",
                    ValidDateID: {
                        required: "<span style=\"color:#ff0000;\">*请输入时间</span>",
                        dateISO: "<span style=\"color:#ff0000;\">*时间格式不对</span>"
                    },
                    CardTypeID: {
                        required: "<span style=\"color:#ff0000;\">*请选择类别</span>"
                    }
                }
            });
        });     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="会员卡"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                编号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="CardCodeID" name="CardCodeID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                会员卡类别：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CardTypeID" name="CardTypeID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                到期日期：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="ValidDateID" name="ValidDateID" runat="server" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                描述：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DescriptionID" Rows="4" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox>
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
