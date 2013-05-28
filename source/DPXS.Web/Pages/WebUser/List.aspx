<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCX.Web.Pages.WebUser.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>用户管理：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                        <input type="button" class="btn02 page_btnAdd" value="新增" onclick="location.href='NewOrEdit.aspx'" />
                        <asp:TextBox ID="txtQueryText" CssClass="input_1" runat="server"></asp:TextBox>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <%--<td  width="50" class="table_title">
                                用户编号
                            </td>--%>
                            <td align="left" class="table_title">
                                用户名
                            </td>
                            <td width="75" class="table_title">
                                真实姓名
                            </td>
                            <td width="70" class="table_title">
                                状态
                            </td>
                            <td width="200" class="table_title">
                                是否管理员
                            </td>
                            <td width="150" class="table_title">
                                最后登录时间
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
                                        <%#Eval("OperatorCode")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("OperatorName")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("UseFlag").ToString() == "1" ? "启用" : "禁用"%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("IsAdmin").ToString() == "True" ? "是":"否"%>
                                    </td>
                                    <td class="td_1">
                                        <%#string.IsNullOrEmpty((Eval("LastLoginTime") ?? string.Empty).ToString()) ? string.Empty : DateTime.Parse(Eval("LastLoginTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                    </td>
                                    <td class="td_1">
                                        <%--<a href="Authority.aspx?Id=<%#Eval("ID") %>&RealName=<%#Eval("OperatorName") %>">角色分配</a>--%>
                                        <a href="NewOrEdit.aspx?NE=edit&Id=<%#Eval("Id") %>">编辑</a>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>'
                                            OnClientClick="return confirm('确认删除？')">删除</asp:LinkButton>
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
