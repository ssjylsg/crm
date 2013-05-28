<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebFinancial.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>

<%@ Register TagPrefix="uc2" TagName="UpLoadControl" Src="~/UcControl/UpLoadControl.ascx" %>
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
                    <li>
                        <%=this.IsPay ? "应付" : "应收"%>功能菜单<%= NE=="edit" ? "编辑" : "新增"%>：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="table_l_nav">
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                名称：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="NameID" runat="server" CssClass="input_1" Width="200px"></asp:TextBox><span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请填写名称"
                                    ControlToValidate="NameID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                <%=this.IsPay ? "收款单位" : "欠款单位"%>：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="CustomerID" runat="server" Width="120px">
                                </asp:DropDownList><span style="color:red">*</span>
                                <asp:TextBox ID="CustomerNameID" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                <%=this.IsPay ? "应付日期" : "欠款起始日"%>：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="FinancialDateID" runat="server" />                                
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                负责人：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="ChargePersonID" runat="server" Width="120px">
                                </asp:DropDownList><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                <%=this.IsPay ? "应付金额" : "欠款金额"%>：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="SumPriceID" runat="server" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="SumPriceID"
                                    ErrorMessage="必须为数字" ForeColor="Red" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                是否<%=this.IsPay ? "已付" : "已收"%>：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="StateId" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%if (this.IsPay)
                          {%>
                         <tr>
                            <td width="90" align="right" class="table_l_tit">
                                应付账款类型：
                            </td>
                            <td class="table_l_td">
                                <asp:DropDownList ID="FinancialPayTypeID" runat="server" Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%
                          }%>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                处理结果：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TreatResultID" runat="server" TextMode="MultiLine" Width="353px"
                                    Height="111px"></asp:TextBox>
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
                         <%
                             var url = string.Format("location.href='List.aspx?FinancialType={0}'", this.FinancialType); %>
                    <input type="button" class="btn02 page_btnBack" value="返回" onclick="<%=url %>" />
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
