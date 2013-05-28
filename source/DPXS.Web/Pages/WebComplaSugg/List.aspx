<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCrm.Web.Pages.WebComplaSugg.List" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="WebCrm.Model" %>
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
                    <li><%=this.IsPay ? "投诉" : "建议"%></li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                        <%
                            var url = string.Format("location.href='NewOrEdit.aspx?SuggestComplaints={0}'", this.SuggestComplaints); %>
                        <input type="button" class="btn02 page_btnAdd" value="新增" onclick="<%=url %>" />
                        <asp:TextBox ID="txtQueryText" CssClass="input_1" runat="server"></asp:TextBox>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <td  class="table_title" width="140">
                                <%=this.IsPay ? "投诉" : "建议"%>人姓名
                            </td>
                            <td  class="table_title">
                                类别
                            </td>
                            <td  class="table_title">
                                <%=this.IsPay ? "投诉" : "建议"%>日期
                            </td>
                            <td class="table_title">
                                处理时间
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
                                    <td class="td_1">
                                        <%#Eval("CustoMerName")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("SuggestType.Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%#(DateTime.Parse((Eval("SuggestDate")).ToString())).ToShortDateString()%>
                                    </td>
                                    <td class="td_1">
                                        <%#(DateTime.Parse((Eval("SolveDate")).ToString())).ToShortDateString()%>
                                    </td>
                                    <td class="td_1">
                                        <%-- <a href="Assign.aspx?Id=<%#Eval("ID") %>&RealName=<%#Eval("LOGIN_REALNAME") %>">角色分配</a>--%>
                                        <a href="NewOrEdit.aspx?NE=edit&SuggestComplaints=<%=Request.QueryString["SuggestComplaints"] %>&Id=<%#Eval("Id") %>">编辑</a>
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
