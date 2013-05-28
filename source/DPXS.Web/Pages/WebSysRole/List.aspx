<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCX.Web.Pages.WebSysRole.List" %>

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
                    <li>角色管理：</li>
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
                            <%--<td width="50" class="table_title">
                                编号
                            </td>--%>
                            <td align="left" class="table_title">
                                角色名
                            </td>
                            <td width="120" class="table_title">
                                备注
                            </td>
                            <td width="150" class="table_title">
                                创建时间
                            </td>
                            <td width="150" class="table_title">
                                最后更新时间
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
                                        <%#Eval("RoleName")%>
                                    </td>
                                    <td class="td_1" title='<%#Eval("Remark")%>'>
                                        <%#WebCrm.Web.Facade.AspNetHelper.ToShortString((Eval("Remark")).ToString())%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("CreateTime")%>
                                    </td>
                                    <td class="td_1">
                                        <%#Eval("ModifyTime")%>
                                    </td>
                                    <td class="td_1">
                                        <a href="Authority.aspx?Id=<%#Eval("ID") %>&RoleName=<%#Eval("RoleName") %>">功能授权</a>
                                        <a href="NewOrEdit.aspx?NE=edit&Id=<%#Eval("ID") %>">编辑</a>
                                        
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("ID") %>'
                                            OnClientClick="return confirm('确认删除？')" Visible='<%# Eval("RoleName").ToString() != "系统管理员" %>'>删除</asp:LinkButton>
                                        
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
