<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCrm.Web.Pages.WebMarket.WebJowork.NewOrEdit" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>

<%@ Register Src="~/UcControl/DateTimeControl.ascx" TagName="DateTimeControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src="../../../Scripts/jquery.validate.js" type="text/javascript"></script>
  <script type="text/javascript">

      $().ready(function () {
          $("#form1").validate({
              rules: {

                  NameID: "required",
                  CreateDateID: {
                      required: true,
                      dateISO: true
                  },
                  ContentID: {
                      required: true
                  },
                  TelNoID: {
                      required: true
                  },
                  EmailID:
                  {
                      required: true,
                      email: true
                  },
                  ContactNameID: {
                      required: true
                  },
                  FaxID: {
                      required: true
                  },
                  AddressID: {
                      required: true
                  }
              },
              messages: {
                  NameID: "<span style=\"color:#ff0000;\">*请输入名称</span>",
                  CreateDateID: {
                      required: "<span style=\"color:#ff0000;\">*请输入时间</span>",
                      dateISO: "<span style=\"color:#ff0000;\">*时间格式不对</span>"
                  },
                  ContentID: {
                      required: "<span style=\"color:#ff0000;\">*内容不能为空</span>"
                  },
                  TelNoID: {
                      required: "<span style=\"color:#ff0000;\">*请输入电话号码</span>"
                  },
                  EmailID:
                  {
                      required: "<span style=\"color:#ff0000;\">*请输入电子邮件</span>",
                      email: "<span style=\"color:#ff0000;\">*请输入有效的邮件</span>"
                  },
                  ContactNameID: {
                      required: "<span style=\"color:#ff0000;\">*输入联系人姓名</span>"
                  },
                  FaxID: {
                      required: "<span style=\"color:#ff0000;\">*请输入传真</span>"
                  },
                  AddressID: {
                      required: "<span style=\"color:#ff0000;\">*请输入详细地址</span>"
                  }
              }
          });
      });     
  </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="合作单位"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
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
                                <asp:TextBox ID="NameID" name="NameID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                合作时间：
                            </td>
                            <td class="table_l_td">
                                <uc1:DateTimeControl ID="CreateDateID" name="CreateDateID" runat="server" Width="250px" />
                            </td>
                        </tr>
  
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                联系号码：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="TelNoID" name="TelNoID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                Email：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="EmailID" name="EmailID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                联系人姓名：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="ContactNameID" name="ContactNameID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                传真：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="FaxID" name="FaxID" runat="server"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                地址：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="AddressID" Rows="4" name="AddressID" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox><span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="90" align="right" class="table_l_tit">
                                备注：
                            </td>
                            <td class="table_l_td">
                                <asp:TextBox ID="RemarkID" Rows="4" Columns="20" runat="server" CssClass="input_1"
                                    Width="500px" TextMode="MultiLine"></asp:TextBox>
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
    </form>
</body>
</html>
