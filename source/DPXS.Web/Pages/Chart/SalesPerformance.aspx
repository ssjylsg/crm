<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesPerformance.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.SalesPerformance" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>销售人员业绩分析</title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>销售人员业绩分析：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                        合同签约开始日期：
                        <input id="startDate" runat="Server" style="width: 95px; height: 18px;" type="text"
                            class="Wdate" readonly="readonly" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'endDate\')}'});" />
                        结束日期：
                        <input id="endDate" runat="Server" style="width: 95px; height: 18px;" type="text"
                            class="Wdate" readonly="readonly" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate:'#F{$dp.$D(\'startDate\')}',maxDate:'%y-%M-%d'});" />
                        销售人员：<asp:DropDownList ID="ddlSales" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSales_SelectedIndexChanged" Width="150px">
                            <asp:ListItem>全部</asp:ListItem>
                        </asp:DropDownList>
                        合同状态: <asp:DropDownList ID="ContactState" runat="server" OnSelectedIndexChanged="ddlSales_SelectedIndexChanged" Width="150px"></asp:DropDownList>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <td width="100" class="table_title">
                                合同编号
                            </td>
                            <td width="100" class="table_title">
                                签约时间
                            </td>
                            <td align="left" class="table_title">
                                客户名称
                            </td>
                            <td width="100" class="table_title">
                                开始时间
                            </td>
                            <td width="100" class="table_title">
                                结束时间
                            </td>
                            <td width="100" class="table_title">
                                客户签约人
                            </td>
                            <td width="100" class="table_title ">
                                合同金额
                            </td>
                        </tr>
                        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rpt_cmd">
                            <ItemTemplate>
                                <tr class="tr_cur">
                                    <td class="td_1">
                                        <%#Container.ItemIndex + 1 %>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CODE")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("SIGNDATE").ToString().Substring(0,10)%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CUSTOMERNAME")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("STARTDATE").ToString().Substring(0, 10)%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("ENDDATE").ToString().Substring(0, 10)%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CUSTOMERSIGNPERSON")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("SUM")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="tr_cur">
                            <td align="center" colspan="8" class="td_1">
                                <asp:Label ID="lblEmpty" runat="server" ForeColor="Blue"><%=rptList.Items.Count > 0 ? "" : "暂无数据!" %></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                    PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList"
                    PagingButtonSpacing="10px" PrevPageText="上一页" ShowBoxThreshold="1" HorizontalAlign="Right">
                </webdiyer:AspNetPager>
                <div class="tool_2">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
