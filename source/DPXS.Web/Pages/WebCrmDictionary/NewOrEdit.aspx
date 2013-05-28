<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebCrmDictionary.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
     <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $().ready(function () {
        //alert(123);
            $("#form1").validate({
                rules: {
                    KeyID: "required",
                    DepictID: {
                        required: true
                    },
                    ValueID: {
                        required: true
                    }
                },
                messages: {
                    KeyID: "<span style=\"color:#ff0000;\">*请输入键值</span>",
                    DepictID: {
                        required: "<span style=\"color:#ff0000;\">*请输入描述</span>"
                    },
                    ValueID: {
                        required: "<span style=\"color:#ff0000;\">*内容不能为空</span>"
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
                        <asp:Label ID="lblTitle" runat="server" Text="CRM数据字典"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                键值：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="KeyID" name="KeyID" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                描述：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="DepictID" Rows="4" Columns="20" runat="server" CssClass="input_1"
                                    Width="200px" name="DepictID" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ValueID" Rows="4" name="ValueID" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>  
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交" OnClick="btnSubmit_Click"
                         />
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx'" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
