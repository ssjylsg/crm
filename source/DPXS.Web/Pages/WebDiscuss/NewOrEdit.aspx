<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebDiscuss.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
     <%@ Register src="../../UcControl/UpLoadControl.ascx" tagname="UpLoadControl" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="洽谈记录"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                客户名称：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CustomerID" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                洽谈时间:
                            </td>
                            <td>
                                <uc1:DateTimeControl ID="VisitDateID" runat="server" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                洽谈业务员：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="BusinessPeopleID" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                其他业务人员：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="OtherPersonID" TextMode="MultiLine" runat="server" CssClass="input_1"
                                    Rows="2" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                洽谈状态：
                            </td>
                            <td>
                                <asp:DropDownList ID="State" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                洽谈内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="Content" runat="server" TextMode="MultiLine" CssClass="input_1"
                                    Rows="2" cols="20" Height="151px" Width="536px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                附件：
                            </td>
                            
                            <td class="table_l_td" style="height:100px;width:50px">
                            
                            <uc2:UpLoadControl ID="UpLoadControl1" runat="server"/>
                            <div id="files" runat="Server">
                                
                            </div>
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
