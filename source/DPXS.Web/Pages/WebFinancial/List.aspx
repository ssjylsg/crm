<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCX.Web.Pages.WebFinancial.List" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="WebCrm.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <li>财务管理-><%=this.IsPay ? "应付" : "应收"%>款项：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                        <%
                            var url = string.Format("location.href='NewOrEdit.aspx?FinancialType={0}'", this.FinancialType); %>
                        <input type="button" class="btn02 page_btnAdd" value="新增" onclick="<%=url %>" />
                        <asp:TextBox ID="txtQueryText" CssClass="input_1" runat="server"></asp:TextBox>
                        <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <td   class="table_title" width="150">
                                名称
                            </td>
                            <td align="left" class="table_title" width="150">
                                客户名称
                            </td>
                            <td width="75" class="table_title">
                                <%=this.IsPay ? "应付" : "应收"%>净额
                            </td>
                            <td width="70" class="table_title">
                                是否
                                <%=this.IsPay ? "已付" : "已收"%>
                            </td>
                            <td width="75" class="table_title">
                                <%=this.IsPay ? "应付日期" : "欠款起始日"%>
                            </td>
                            <td width="100" class="table_title">
                                负责人
                            </td>
                            <td width="100" class="table_title">
                                处理结果
                            </td>
                            <td width="70" class="table_title">
                                录入时间
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
                                        <%#Eval("Name")%>
                                    </td>
                                    <td class="td_1">
                                        <%if (this.IsPay)
                                          {%>
                                        <%#Eval("Cooperation.Name") ?? Eval("CustomerName")%>
                                        <%
                                      }
                                          else
                                          {%>
                                        <%#Eval("Customer.Name") ?? Eval("CustomerName")%>
                                        <%
                                      }%>
                                    </td>
                                    <td class="td_1">
                                        <%#decimal.Parse((Eval("SumPrice")).ToString()).ToString("C")%>
                                    </td>
                                     <td class="td_1">
                                        <%#Eval("State").ToString() == "False" ? "否":"是"%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("FinancialDate").ToShortDate()%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("ChargePerson.OperatorName")%>
                                    </td>
                                    <td class="td_1" title='<%#Eval("TreatResult") %>'>
                                        <%#(Eval("TreatResult") ?? string.Empty).ToString().ToShortString(5)%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CreateTime").ToShortDate()%>
                                    </td>
                                    <td class="td_1">
                                        <%--<a href="Authority.aspx?Id=<%#Eval("ID") %>&RealName=<%#Eval("OperatorName") %>">角色分配</a>--%>
                                        <a href="NewOrEdit.aspx?FinancialType=<%=Request.QueryString["FinancialType"] %>&NE=edit&Id=<%#Eval("Id") %>">编辑</a>
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
