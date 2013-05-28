<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrEdit.aspx.cs" Inherits="WebCX.Web.Pages.WebCustomer.NewOrEdit" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<%@ Register Src="../../UcControl/DateTimeControl.ascx" TagName="DateTimeControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 85px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mContainer" class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>
                        <asp:Label ID="lblTitle" runat="server" Text="基本信息"></asp:Label>：
                        <input id="hiddenID" type="hidden" value="<%=Id %>" />
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tableNav_2">
                    <table cellpadding="0" cellspacing="0" width="100%" class="r_content">
                        <tr id="path">
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="content" id="tdcontent">
                                <div class="form" id="formblock">
                                    <div id="formMain">
                                        <table cellpadding="1px" cellspacing="0px" style="width: 100%;">
                                            <tr>
                                                <td class="style1">
                                                    客户标识：
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="IdentificationID" AutoPostBack="false" runat="server" TextAlign="Left"
                                                        RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                        <asp:ListItem Text="企业" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="个人" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 70px;">
                                                    客户编号：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Code" runat="server" MaxLength="150"></asp:TextBox>
                                                    <input type="button" value="获取编号" id="GetCutomerId" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    创建时间：
                                                </td>
                                                <td>
                                                    <asp:Label ID="CreateTime" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 70px;">
                                                    客户类型：
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CustomerTypeParentId" runat="server" OnSelectedIndexChanged="CustomerTypeParentId_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="CustomerTypeItemId" runat="server">
                                                    </asp:DropDownList>
                                                    <span class='required' style='color: red'>*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    地区：
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="AreaParentId" runat="server" OnSelectedIndexChanged="AreaParentId_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="AreaId" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 70px;" sign="1">
                                                    认可程度：
                                                </td>
                                                <td sign="1">
                                                    <asp:DropDownList ID="LevelSort" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    信用等级:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CreditRatingID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 70px;" id="assignName">
                                                    所属人：
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="BelongPersonID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td sign="1" class="style1">
                                                    客户简称：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ShortName" runat="server" MaxLength="500"></asp:TextBox>
                                                    <input type="button" value="检测同名" id="CheckShortName" />
                                                </td>
                                                <td style="width: 70px;" sign="1">
                                                    重要程度：
                                                </td>
                                                <td sign="1">
                                                    <asp:DropDownList ID="ImportantLevelId" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    客户名称：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="NameId" runat="server"></asp:TextBox>
                                                    <span class='required' id='Customer_sName' style='color: red'>*</span>
                                                </td>
                                                <td style="width: 70px;">
                                                    会员类型：
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CagegoryTypeId" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td sign="1" class="style1">
                                                    关系：
                                                </td>
                                                <td sign="1">
                                                    <asp:DropDownList ID="RelationLevelID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 70px;" sign="1">
                                                    会员卡号:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="MemberCardID" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    客户车辆：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="CarId" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td style="width: 70px;" sign="1">
                                                    客户来源：
                                                </td>
                                                <td sign="1">
                                                    <asp:DropDownList ID="CustomerSourceID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    客户行业：
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CustomerBusinessID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 70px;" sign="1">
                                                </td>
                                                <td sign="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="r_tit1">
                                                        <ul>
                                                            <li id="AccTypeInfo">联系人信息:</li></ul>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr name="PersonIdTr">
                                                <td sign="1" class="style1">
                                                    姓名：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="RealNameID" runat="server" MaxLength="50"></asp:TextBox>
                                                    <asp:CheckBox ID="RealauthID" runat="server" Text="是否实名认证" />
                                                    <span class='required' id='CustomerContact_sName' style='color: red'>*</span>
                                                </td>
                                                <td style="width: 70px;" sign="2">
                                                    身份证：
                                                </td>
                                                <td sign="2">
                                                    <asp:TextBox ID="IdCardID" runat="server" MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr name="PersonIdTr">
                                                <td class="style1">
                                                    办公电话：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TelID" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width: 70px;">
                                                    手机：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="MobileId" runat="server" MaxLength="50" />
                                                    <asp:CheckBox ID="MobileAuthID" runat="server" Text="是否手机认证" />
                                                </td>
                                            </tr>
                                            <tr name="PersonIdTr">
                                                <td class="style1">
                                                    生日
                                                </td>
                                                <td>
                                                    <uc1:DateTimeControl ID="BirthDate" runat="server" />
                                                </td>
                                                <td style="width: 70px;" sign="2">
                                                    性别：
                                                </td>
                                                <td sign="2">
                                                    <asp:DropDownList ID="SexID" runat="server">
                                                        <asp:ListItem Text="未知" Value="未知"></asp:ListItem>
                                                        <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr name="PersonIdTr">
                                                <td sign="2" class="style1">
                                                    详细地址：
                                                </td>
                                                <td sign="2">
                                                    <asp:TextBox ID="AddrID" runat="server" MaxLength="100"></asp:TextBox>
                                                </td>
                                                <td style="width: 70px;" sign="2">
                                                    邮编：
                                                </td>
                                                <td sign="2">
                                                    <asp:TextBox ID="PostID" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr name="PersonIdTr">
                                                <td sign="1" class="style1">
                                                    电子邮件：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="EmailId" runat="server" MaxLength="150"></asp:TextBox>
                                                    <asp:CheckBox ID="EmailAuthID" runat="server" Text="是否邮件认证" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EmailId"
                                                        ErrorMessage="请输入正确的邮箱格式" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr name="CorpIdTr">
                                                <td sign="1" class="style1">
                                                    公司名称：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="CorpNameID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td>
                                                    公司类型
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CorpTypeID" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr name="CorpIdTr">
                                                <td sign="1" class="style1">
                                                    网站：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="UrlID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td>
                                                    联系人
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="LinkManID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr name="CorpIdTr">
                                                <td sign="1" class="style1">
                                                    电话：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="LinkManTelID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td>
                                                    传真
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="FaxID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr name="CorpIdTr">
                                                <td sign="1" class="style1">
                                                    地址：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="AddressID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td>
                                                    QQ
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="QQID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr name="CorpIdTr">
                                                <td sign="1" class="style1">
                                                    办公室电话：
                                                </td>
                                                <td sign="1">
                                                    <asp:TextBox ID="TelPhoneID" runat="server" MaxLength="150"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    备注：
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox Rows="5" TextMode="MultiLine" runat="server" ID="RemarkID" Style="width: 75%;
                                                        height: 45px;" MaxLength="500"></asp:TextBox>
                                                </td>
                                            </tr>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="tool_2">
            <asp:Button ID="btnSubmit" runat="server" class="btn02 page_btnSubmit" Text="提交"
                OnClick="btnSubmit_Click" OnClientClick="return submitCheck();" />
            <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx'" />
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('select').width(150);
            var BelongPerson = '<%=Request.QueryString["BelongPerson"] %>'
            if (BelongPerson != '') {
                $('#' + '<%=BelongPersonID.ClientID %>').val(BelongPerson);
            }
            $('#ShortName').blur(function () {
                if ($('#NameId').val() == '') {
                    $('#NameId').val($(this).val());
                }
            });
            if ('<%=this.Id %>' != 0) {
                $('#GetCutomerId').attr('disabled', true);
            }
            // 判断客户名称简称
            $('#CheckShortName').click(function () {
                $.post('/Pages/WebCustomer/DataRequest.ashx', { type: 'checkcustomername', name: $('#' + '<%=this.ShortName.ClientID %>').val(), id: '<%=this.Id %>' }, function (data) {
                    if (JSON.parse(data).Result == 'True') {
                        alert("客户名称重复,请重新填写");
                        return false;
                    }
                    alert("此客户名没有重复");
                    return true;
                });
            });
            // 获取客户编号
            $('#GetCutomerId').click(function () {
                $.post('/Pages/WebCustomer/DataRequest.ashx', { type: 'getcustomerno', id: new Date().getSeconds() }, function (data) {
                    $('#<%=Code.ClientID %>').val(JSON.parse(data).Result);
                });

            });

            // 企业/客人 
            var IdentificationID = '<%=this.IdentificationID.ClientID %>';
            $("input[type=radio][name=" + IdentificationID + "]").click(function () {

                // 企业 1
                if ($(this).val() == "1") {
                    showEnterpriseInfo();
                }
                else {
                    showPersonInfo();
                }

            });
            var isPostBack = '<%=IsPostBack %>' == 'True';
            if (!isPostBack) {
                // 企业/客户默认选中
                var isPerson = '<%=this.IsPerson %>';

                if (isPerson == 'True') {
                    showPersonInfo();
                }
                else {
                    showEnterpriseInfo();
                }
                $("input[type=radio][name=" + IdentificationID + "][value=1]").attr('checked', isPerson == 'False');
            }
            else {
                if ($("input[type=radio][name=" + IdentificationID + "][value=1]").attr('checked')) {
                    showEnterpriseInfo();
                }
                else {
                    showPersonInfo();
                }
            }

        });
        function showPersonInfo() {
            $('[name=PersonIdTr]').show();
            $('[name=CorpIdTr]').hide();
            $('#AccTypeInfo').html("个人信息");
        }
        function showEnterpriseInfo() {
            $('[name=PersonIdTr]').hide();
            $('[name=CorpIdTr]').show();
            $('#AccTypeInfo').html("企业信息");
        }
        function submitCheck() {
            if (checkEmpty('<%=CustomerTypeItemId.ClientID %>', '客户类型必须') == false ||
                checkEmpty('<%=NameId.ClientID %>', '客户名称不能为空') == false) {
                return false;
            }

            return true;
        }
        // 控件为空判断
        function checkEmpty(controlId, msg) {
            if ($('#' + controlId).val() == null || $('#' + controlId).val().length == 0) {
                $('#' + controlId).focus();
                alert(msg);
                return false;
            }
            return true;
        }
        // double 类型判断
        function checkNum(controlId, msg) {
            var vaule = $('#' + controlId).val();
            if (vaule == null || vaule.length == 0) {
                $('#' + controlId).val('0');
                return true;
            }
            if (isNaN(vaule)) {
                $('#' + controlId).focus();
                alert(msg);
                return false;
            }
            return true;
        }

    </script>
    </form>
</body>
</html>
