<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebContract.NewOrEdit" %>
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
                    <li>合同<%= NE=="edit" ? "编辑" : "新增"%>：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合同名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ContractNameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写合同名称"
                                    ControlToValidate="ContractNameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合同编号：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="CodeID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox>
                                <span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请填写合同编号"
                                    ControlToValidate="CodeID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                签约客户：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CustomerID" runat="server" Width="120px">
                                </asp:DropDownList>
                                <span style="color:red">*</span>
                                <asp:TextBox ID="CustomerNameID" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                开始日期：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="StartDateID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                结束日期：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="EndDateID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                公司签约人：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="SignPersonID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                客户签约人：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="CustomerSignPersonID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                签约日期：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="SignDateID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                签约地点：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SignAddressID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                存放地址：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="StorePlaceID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                金额：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SumID" runat="server" CssClass="input_1" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="SumID"
                                    ErrorMessage="必须为数字" ForeColor="Red" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合同状态：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="StateId" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                结算情况：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="SettleStateID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合同内容：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox TextMode="MultiLine" ID="ContentID" runat="server" CssClass="input_1"
                                    Width="353px" Height="111px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox TextMode="MultiLine" ID="RemarkID" runat="server" CssClass="input_1"
                                    Width="353px" Height="111px"></asp:TextBox>
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
            var customerId = '<%=CustomerID.ClientID %>';
            $('#' + customerId).change(function () {
                $('#<%=CustomerNameID.ClientID %>').val($('#' + customerId).find("option:selected").text());
            });
        });
    </script>
    </form>
</body>
</html>
