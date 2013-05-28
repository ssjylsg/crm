<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebComplaSugg.NewOrEdit" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>
<%@ Register Src="../../UcControl/UpLoadControl.ascx" TagName="UpLoadControl" TagPrefix="uc2" %>
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
            $("#form1").validate({
                rules: {

                    CustomerNameID: "required",
                    SuggestDateID: {
                        required: true,
                        dateISO: true
                    },
                    SuggestTypeID: {
                        required: true
                    },
                    SolveDateID: {
                        required: true,
                        dateISO: true
                    },
                    ContentID:
                  {
                      required: true
                  },
                    SolveTypeID: {
                        required: true
                    }
                },
                messages: {
                    CustomerNameID: "<span style=\"color:#ff0000;\">*必填项</span>",
                    SuggestDateID: {
                        required: "<span style=\"color:#ff0000;\">*请输入时间</span>",
                        dateISO: "<span style=\"color:#ff0000;\">*时间格式不对</span>"
                    },
                    SuggestTypeID: {
                        required: "<span style=\"color:#ff0000;\">*请选择类别</span>"
                    },
                    SolveDateID: {
                        required: "<span style=\"color:#ff0000;\">*请输入时间</span>",
                        dateISO: "<span style=\"color:#ff0000;\">*时间格式不对</span>"
                    },
                    ContentID:
                  {
                      required: "<span style=\"color:#ff0000;\">*请输入内容</span>"
                  },
                    SolveTypeID: {
                        required: "<span style=\"color:#ff0000;\">*请选择解决方案</span>"
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
                        <%=this.IsPay ? "投诉" : "建议"%><%= NE=="edit" ? "编辑" : "新增"%>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                <%=this.IsPay ? "投诉" : "建议"%>名称：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CustomerID" runat="server" Width="150px">
                                </asp:DropDownList>
                                <span style="color:red">*</span>
                                <asp:TextBox ID="CustomerNameID" name="CustomerNameID" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                类别：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="SuggestTypeID" name="SuggestTypeID" runat="server" Width="150px">
                                </asp:DropDownList>
                                <span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                <%=this.IsPay ? "投诉" : "建议"%>时间：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="SuggestDateID" name="SuggestDateID" runat="server" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ContentID" Rows="4" name="ContentID" Columns="20" runat="server"
                                    CssClass="input_1" Width="500px" TextMode="MultiLine"></asp:TextBox>
                                    <span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                经手人：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="HandlerPersonID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                处理人：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="DealPersonID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                处理时间：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="SolveDateID" name="SolveDateID" runat="server" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                解决方案：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="SolveTypeID" name="SolveTypeID" runat="server" Width="150px">
                                </asp:DropDownList>
                                <span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                解决结果：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SolveResultsID" Rows="4" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                附件：
                            </td>
                            <td class="table_l_td" style="height: 100px; width: 50px">
                                <uc2:UpLoadControl ID="UpLoadControl1" runat="server" />
                                <div id="files" runat="Server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tool_2">
                    <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交"
                        OnClick="btnSubmit_Click" />
                    <%
                        var url = string.Format("location.href='List.aspx?SuggestComplaints={0}'", this.SuggestComplaints); %>
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="<%=url %>" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var customerId = '<%=CustomerID.ClientID %>';
            $('#' + customerId).change(function () {
                $('#<%=CustomerNameID.ClientID %>').val($('#' + customerId).find("option:selected").text());
            });
        });
    </script>
    </form>
</body>
</html>
