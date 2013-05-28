<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySelftCustomer.aspx.cs"
    Inherits="WebCX.Web.Pages.CustomerNotify.MySelftCustomer" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="WebCrm.Model" %>
<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href=" ../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href=" ../../Admin/css/right.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>我的客户：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                        <input type="button" class="btn02 page_btnAdd" value="新增客户" onclick="location.href='<%=AspNetHelper.WebUrl() %>/Pages/WebCustomer/NewOrEdit.aspx?from=myself&BelongPerson=<%=this.CurrentOperatorUser != null ? this.CurrentOperatorUser.Id.ToString():string.Empty %>'" />
                        客户姓名:<asp:TextBox ID="QueryName" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="AccTypeId" runat="server" Width="150px">
                            <asp:ListItem Text="请选择" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="企业" Value="1" Selected="false"></asp:ListItem>
                            <asp:ListItem Text="个人" Value="0" Selected="false"></asp:ListItem>
                        </asp:DropDownList>
                        行业:
                        <asp:DropDownList ID="CustomerBusinessID" runat="server" Width="150px">
                        </asp:DropDownList>
                        来源:
                        <asp:DropDownList ID="CustomerSourceID" runat="server" Width="150px">
                        </asp:DropDownList>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <%--<td  width="50" class="table_title">
                                用户编号
                            </td>--%>
                            <td align="left" class="table_title" width="80">
                                客户编号
                            </td>
                            <%-- <td width="75" class="table_title">
                                客户名称
                            </td>--%>
                            <td width="75" class="table_title">
                                客户简称
                            </td>
                            <td width="50" class="table_title">
                                企业/个人
                            </td>
                            <td width="60" class="table_title">
                                会员类型
                            </td>
                            <td width="70" class="table_title">
                                信用等级
                            </td>
                            <td width="70" class="table_title">
                                客户行业
                            </td>
                            <td width="70" class="table_title">
                                会员卡号
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
                                    <%--<td class="td_1">
                                        <%#Eval("ID")%>
                                    </td>--%>
                                    <td class="td_1">
                                        <%#Eval("Code")%>
                                    </td>
                                    <%-- <td class="td_1">
                                        <%#Eval("Name")%>
                                    </td>--%>
                                    <td class="td_1">
                                        <%#Eval("ShortName")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("AccType").ToString() == "Enterprise"?"企业":"个人"%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("Cagegory.Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CreditRating.Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CustomerBusiness.Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("MemberCard.CardCode")%>
                                    </td>
                                    <td class="td_1">
                                    <a href="../WebCustomer/CustomerInfo.aspx?CustomerId=<%#Eval("Id") %>"
                                                target="rightFrame">客户详情</a>
                                        <a href="../Chart/Children/ER_ExpenseTrend.aspx?CustomerId=<%#Eval("Id") %>" target="rightFrame"
                                            onmouseover='openChart(<%#Eval("Id") %>)'>消费走势</a>  <a href="<%=AspNetHelper.WebUrl() %>/Pages/WebCustomer/VisitRecordList.aspx?CustomerId=<%#Eval("Id") %>"
                                                    target="rightFrame">回访记录</a> <a href="<%=AspNetHelper.WebUrl() %>/Pages/WebDiscuss/List.aspx?CustomerId=<%#Eval("Id") %>"
                                                        target="rightFrame">洽谈记录</a> <a href="<%=AspNetHelper.WebUrl() %>/Pages/WebConsume/List.aspx?CustomerId=<%#Eval("Id") %>"
                                                            target="rightFrame">消费记录</a>
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
    <script type="text/javascript">
        function openChart(id) {

            //window.open('../Chart/Children/ER_ExpenseTrend.aspx?CustomerId=' + id, 'newwindow', 'height=420, width=728,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no,top=' + (screen.height - 420) / 2 + ',left=' + (screen.width - 728) / 2);

        }
    
    
    </script>
    </form>
</body>
</html>
