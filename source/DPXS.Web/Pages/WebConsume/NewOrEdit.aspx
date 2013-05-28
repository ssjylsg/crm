<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebConsume.NewOrEdit" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc2" TagName="UpLoadControl" Src="~/UcControl/UpLoadControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .style1
        {
            width: 110px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="客户消费记录"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td align="right" class="style1">
                                客户名称：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CustomerID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                业务人员：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="BussinessPersonID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                消费时间：
                            </td>
                            <td>
                                <uc1:DateTimeControl ID="VisitDateID" runat="server" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                总花费：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SpendTotalID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                消费类型：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ConsumerBusinessType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                打折方式：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="DiscountType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                打折后总消费数：
                            </td>
                            <td>
                                <asp:TextBox ID="AfterDiscountFree" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                积分规则：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ScoreRuleID" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                本次积分：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ScoreID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                收到款项：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ReceiveMoneyID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                录入人：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="WritePersonID" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                消费明细：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ConsumerDetailsID" runat="server" TextMode="MultiLine" Height="93px"
                                    Width="427px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style1">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" runat="server" TextMode="MultiLine" Height="93px" Width="427px"></asp:TextBox>
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
    <script language="javascript" type="text/javascript">
        var CustomerId = '<%=Request.QueryString["CustomerId"] %>';
        if (CustomerId != '') {
            $('#' + '<%=CustomerID.ClientID %>').val(CustomerId);
        }
    </script>
    </form>
</body>
</html>
