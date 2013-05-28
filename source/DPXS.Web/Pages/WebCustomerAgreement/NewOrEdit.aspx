<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebCustomerAgreement.NewOrEdit" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../UcControl/UpLoadControl.ascx" TagName="UpLoadControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <li>大客户协议<%= NE=="edit" ? "编辑" : "新增"%>：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                标题：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SubjectID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写标题"
                                    ControlToValidate="SubjectID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox TextMode="MultiLine" ID="ContentID" runat="server" CssClass="input_1"
                                    Width="353px" Height="96px"></asp:TextBox>
                                     <span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写内容"
                                    ControlToValidate="ContentID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                客户：
                            </td>
                            <td class="table_l_td">
                                 <asp:DropDownList ID="CustomerID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                协议类型：
                            </td>
                            <td class="table_l_td">
                                 <asp:DropDownList ID="AgreementTypeID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                               到期时间：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="ExpireID" runat="server" />
                            </td>
                        </tr>
                       
                          
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注信息：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" runat="server" Height="92px" Width="345px" TextMode="MultiLine"></asp:TextBox>
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
    <script type="text/javascript">
        $(function () {

        });
    </script>
    </form>
</body>
</html>
