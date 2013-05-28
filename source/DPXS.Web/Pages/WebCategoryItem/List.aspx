<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCX.Web.Pages.WebCategoryItem.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>菜单列表：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tool_search">
                    <asp:Button ID="btnNew" runat="server" class="btn02 page_btnAdd" Text="新增" OnClick="btnNew_Click"
                        Enabled="false" />
                    <asp:TextBox ID="txtQueryText" CssClass="input_1" runat="server"></asp:TextBox>
                    <asp:Button ID="btnQuery" runat="server" class="btn02 page_btnQuery" Text="查询" OnClick="btnQuery_Click" />
                </div>
                <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="tableNav_2" style="padding: 0; margin-top: 10px;">
                    <div style="height: 100%;width:200px; overflow-y: scroll; margin-top: 5px; border: 1px solid;
                        float: left">
                        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" >
                            <SelectedNodeStyle BorderColor="#FF3300" BorderWidth="1px" Height="90%" />
                        </asp:TreeView>
                    </div>
                    <div style="float: left;" style="margin-top: 5px;">
                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    分类类别：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="CategoryID" runat="server" CssClass="input_1" Width="200px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    父类名称：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="ParentItemID" runat="server" CssClass="input_1" Width="200px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    名称：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="NameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    描述：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="DescriptionID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    排序：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="OrderIndexID" runat="server" CssClass="input_1" Width="200px" Text="0"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="OrderIndexID"
                                        ErrorMessage="排序必须为数字" ForeColor="Red" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" align="right" class="table_l_tit">
                                    扩展信息：
                                </td>
                                <td class="table_l_td">
                                    <asp:TextBox ID="OtherInfoID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                    <span style="color: Red">此属性不要做修改</span>
                                </td>
                            </tr>
                        </table>
                        <div class="tool_2" style="margin-left: 30px;">
                            <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交"
                                OnClick="btnSubmit_Click" />
                            <input type="button" class="btn02 page_btnBack" value="取消" onclick="location.href='List.aspx'" />
                            <asp:Button ID="DeleteId" runat="server" class="btn02 page_btnDelete" Text="删除" OnClick="DeleteId_Click" />
                            <asp:Label ID="RequestId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="ParentIdLbl" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="CategoryIdlbl" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <%--   <div class="tool_2">
                </div>--%>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
