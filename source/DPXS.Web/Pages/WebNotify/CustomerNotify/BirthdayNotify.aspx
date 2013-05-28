<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BirthdayNotify.aspx.cs"
    Inherits="WebCX.Web.Pages.CustomerNotify.List" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="WebCrm.Model" %>
<%@ Register Src="../../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>最近生日客户：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search" style="display:list-item">
                      日期： <uc1:DateTimeControl ID="BeginDate" runat="server" />
                        <asp:RadioButtonList ID="DateRadio" runat="server"   RepeatColumns="2" RepeatDirection="Horizontal" AutoPostBack="false" RepeatLayout="Flow" >
                            <asp:ListItem Text="最近一周" Value="week"></asp:ListItem>
                            <asp:ListItem Text="最近一月" Value="month"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:CheckBox ID="MySelfData" runat="server" Text="我的客户" Checked = "true"/>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <td width="80" class="table_title">
                                姓名 姓名
                            </td>
                            <td align="left" class="table_title" width="140">
                                性别
                            </td>
                            <%-- <td width="75" class="table_title">
                                客户名称
                            </td>--%>
                            <td width="75" class="table_title">
                                联系号码
                            </td>
                            <td width="50" class="table_title">
                                手机号码
                            </td>
                            <%--   <td width="60" class="table_title">
                                会员类型
                            </td>--%>
                            <td width="70" class="table_title">
                                职位
                            </td>
                            <td width="70" class="table_title">
                                生日
                            </td>
                            <td width="130" class="table_title ">
                                操作
                            </td>
                        </tr>
                        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rpt_cmd">
                            <ItemTemplate>
                                <tr class="tr_cur">
                                    <td class="td_1">
                                        <%#Container.ItemIndex + 1 %>
                                    </td>
                                    <td class="td_1" title='个人喜好:<%#Eval("Favorites") %>'>
                                        <%#Eval("Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("Sex")%>
                                    </td>
                                    <%-- <td class="td_1">
                                        <%#Eval("Name")%>
                                    </td>--%>
                                    <td class="td_1">
                                        <%#Eval("TelNumber")%>
                                    </td>
                                    <td class="td_1">
                                        <%#(Eval("PhoneNumber"))%>
                                    </td>
                                    <td class="td_1">
                                        <%#(Eval("DutyName"))%>
                                    </td>
                                    <td class="td_1">
                                        <%#(Eval("Birthday")).ToShortDate()%>
                                    </td>
                                    <td class="td_1">
                                        <a href="../../WebCustomer/CustomerInfo.aspx?CustomerId=<%#Eval("Customer.Id") %>" target="rightFrame">
                                            客户详情</a>
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
    <script language="javascript">
        $(function () {
            var week = '<%=this.Week %>';
            var month = '<%=this.Month %>';
            var BeginDateId = 'BeginDate_BirthDateID';
            $('input[type=radio]').click(function () {
                if ($(this).val() == "month") {
                    $('#' + BeginDateId).val(month);
                }
                else {
                    $('#' + BeginDateId).val(week);
                }
            });
        });
    </script>
    </form>
</body>
</html>
