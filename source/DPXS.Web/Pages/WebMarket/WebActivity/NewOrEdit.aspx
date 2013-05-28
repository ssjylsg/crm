<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebMarket.WebActivity.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>

<%@ Register TagPrefix="uc2" TagName="UpLoadControl" Src="~/UcControl/UpLoadControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../Admin/css/right.css" rel="stylesheet" type="text/css" />
   <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src="../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $().ready(function () {
            $("#form1").validate({
                rules: {

                    NameID: "required",
                    ActionDateID: {
                        required: true,
                        dateISO: true
                    },
                    ContentID: {
                        required: true
                    },
                    FreeID:
                  {
                      number: true,
                      min: 0
                  },
                    StateID: {
                        required: true
                    },
                    DropWorkNameID: {
                        required: true
                    },
                    EvaluateID: {
                        required: true
                    }
                },
                messages: {
                    NameID: "<span style=\"color:#ff0000;\">*请输入名称</span>",
                    ActionDateID: {
                        required: "<span style=\"color:#ff0000;\">*请输入时间</span>",
                        dateISO: "<span style=\"color:#ff0000;\">*时间格式不对</span>"
                    },
                    ContentID: {
                        required: "<span style=\"color:#ff0000;\">*内容不能为空</span>"
                    },
                    FreeID:
                  {
                      number: "<span style=\"color:#ff0000;\">*请输入合法的数字</span>",
                      min: "<span style=\"color:#ff0000;\">*请输入合法的数字</span>"
                  },
                    StateID: {
                        required: "<span style=\"color:#ff0000;\">*请选择状态</span>"
                    },
                    DropWorkNameID: {
                        required: "<span style=\"color:#ff0000;\">*请选择合作单位</span>"
                    },
                    EvaluateID: {
                        required: "<span style=\"color:#ff0000;\">*请选择评价</span>"
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
                        <asp:Label ID="lblTitle" runat="server" Text="活动"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="NameID" name="NameID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                活动时间：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="ActionDateID" name="ActionDateID" runat="server" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                活动内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ContentID" Rows="4" name="ContentID" Columns="20" runat="server"
                                    CssClass="input_1" Width="500px" TextMode="MultiLine"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                费用：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="FreeID" name="FreeID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                状态：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="StateID" name="StateID" runat="server" Width="150px">
                                </asp:DropDownList><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合作单位：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="DropWorkNameID" name="DropWorkNameID" runat="server" Width="150px">
                                </asp:DropDownList><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                评价：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="EvaluateID" name="EvaluateID" runat="server" Width="150px">
                                </asp:DropDownList><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" Rows="4" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                            <td width="90" align="right" class="table_l_tit">
                                附件：
                            </td>
                            <td class="table_l_td" style="height: 100px; width: 50px">
                                <div id="files" runat="Server">
                                </div>
                                <uc2:UpLoadControl ID="UpLoadControl1" runat="server" />
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
