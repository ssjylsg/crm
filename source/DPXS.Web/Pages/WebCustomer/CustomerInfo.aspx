<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="WebCrm.Web.Pages.WebCustomer.CustomerInfo" %>

<%@ Import Namespace="WebCrm.Model" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.2.min.js" type="text/javascript"></script>
</head>
<script type="text/javascript">
    $(function () {
        $("#accordion").accordion();
    });
</script>
<body>
    <form id="form1" runat="server">
    <div id="accordion">
        <h3>
            基本客户信息：</h3>
        <div>
            <%
                var customer = this.Customer;%>
            <div class="r_content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                    <tr class="tr_cur">
                        <td class="td_1">
                            客户标识:<%=customer.AccType == CustomerIdentification.Person?"个人":"企业"%>
                        </td>
                        <td class="td_1">
                            客户编号:<%=customer.Code%>
                        </td>
                        <td class="td_1">
                            创建时间:<%=customer.CreateTime.ToShortDateString()%>
                        </td>
                        <td class="td_1">
                            创建人:<%=(customer.CreatePerson != null ? customer.CreatePerson.OperatorName :string.Empty)%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            客户类型:<%=customer.Cagegory.ItemName()%>
                        </td>
                        <td class="td_1">
                            地区:<%=customer.Area.ItemName()%>
                        </td>
                        <td class="td_1">
                            认可程度:<%=customer.LevelSort.ItemName()%>
                        </td>
                        <td class="td_1">
                            信用等级:<%=customer.CreditRating.ItemName()%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            所属人 :<%=customer.BelongPerson != null?customer.BelongPerson.OperatorName:string.Empty%>
                        </td>
                        <td class="td_1">
                            客户简称:<%=customer.ShortName%>
                        </td>
                        <td class="td_1">
                            重要程度:<%=customer.ImportantLevel.GetEnumDesc()%>
                        </td>
                        <td class="td_1">
                            客户名称:<%=customer.Name%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            会员类型 :<%=customer.Cagegory.ItemName()%>
                        </td>
                        <td class="td_1">
                            关系:<%=customer.RelationLevel.ItemName()%>
                        </td>
                        <td class="td_1">
                            重要程度:<%=customer.ImportantLevel.GetEnumDesc()%>
                        </td>
                        <td class="td_1">
                            会员卡号:<%=customer.MemberCard != null?customer.MemberCard.CardCode:string.Empty%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            车辆信息 :<%=customer.Car%>
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                    </tr>
                    <%--   <tr class="tr_cur">
                        <td colspan="4">
                            <div class="r_tit1" style="text-align: center">
                                <ul>
                                    <li>
                                        <%=customer.AccType == CustomerIdentification.Person ? "散客信息":"企业信息"%>:</li></ul>
                            </div>
                        </td>
                    </tr>--%>
                    <%if (customer.AccType == CustomerIdentification.Person)
                      {
                          var person = this.PersonInfo;
                    %>
                    <tr class="tr_cur">
                        <td class="td_1">
                            姓名:<%=person.RealName%>
                            &nbsp;&nbsp;<span style="color: red"><% =person.Realauth ? "已认证":string.Empty%></span>
                        </td>
                        <td class="td_1">
                            身份证:<%=person.IdCard%>
                        </td>
                        <td class="td_1">
                            办公电话:<%=person.Tel%>
                        </td>
                        <td class="td_1">
                            手机:<%= person.Mobile%>
                            &nbsp;&nbsp;<span style="color: red"><% =person.MobileAuth ? "已认证":string.Empty%></span>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            生日:<%=person.BirthDate%>
                        </td>
                        <td class="td_1">
                            性别:<%=person.Sex%>
                        </td>
                        <td class="td_1">
                            详细地址:<%=person.Addr%>
                        </td>
                        <td class="td_1">
                            邮编:<%=person.Post%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            电子邮件 :<%=person.Email%>
                            &nbsp;&nbsp;<span style="color: red"><% =person.EmailAuth ? "已认证":string.Empty%></span>
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                    </tr>
                    <%
                      }
                      else
                      {
                          var corpInfo = this.CorpInfo;

                    %>
                    <tr class="tr_cur">
                        <td class="td_1">
                            公司名称:<%=corpInfo.Name%>
                        </td>
                        <td class="td_1">
                            公司类型:<%=corpInfo.CorpType.ItemName()%>
                        </td>
                        <td class="td_1">
                            网站:<%=corpInfo.Url%>
                        </td>
                        <td class="td_1">
                            联系人:<%= corpInfo.LinkMan%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            电话:<%=corpInfo.LinkManTel%>
                        </td>
                        <td class="td_1">
                            传真:<%=corpInfo.Fax%>
                        </td>
                        <td class="td_1">
                            地址:<%=corpInfo.Address%>
                        </td>
                        <td class="td_1">
                            QQ:<%=corpInfo.QQ%>
                        </td>
                    </tr>
                    <tr class="tr_cur">
                        <td class="td_1">
                            办公室电话 :<%=corpInfo.TelPhone%>
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                        <td class="td_1">
                        </td>
                    </tr>
                    <%
                      }%>
                </table>
            </div>
        </div>
        <h3>
            回访记录：</h3>
        <div>
            <div class="tableNav">
                <div class="tool_search">
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                    <tr>
                        <td width="30" class="table_title">
                        </td>
                        <td width="75" class="table_title">
                            业务人员名称
                        </td>
                        <td width="50" class="table_title">
                            回访日期
                        </td>
                        <td width="70" class="table_title">
                            其他回访人员
                        </td>
                        <td width="70" class="table_title">
                            回访内容概要
                        </td>
                        <td width="130" class="table_title ">
                            详情
                        </td>
                    </tr>
                    <%
                        int count = 1;
                        foreach (CustomerVisitRecord customerVisitRecord in VisitRecords)
                        {

                    %>
                    <tr class="tr_cur">
                        <td class="td_1">
                            <%=count%>
                        </td>
                        <td class="td_1">
                            <%=customerVisitRecord.BusinessPeople.RealName%>
                        </td>
                        <td class="td_1">
                            <%=customerVisitRecord.VisitDate%>
                        </td>
                        <td class="td_1">
                            <%=customerVisitRecord.OtherPerson%>
                        </td>
                        <td class="td_1">
                            <%=customerVisitRecord.Content%>
                        </td>
                        <td class="td_1">
                            <%--<%=customerVisitRecord.Content%>--%>
                            <a href="../WebCustomer/VisitRecord.aspx?read=true&Id=<%=customerVisitRecord.Id %>"
                                target="rightFrame">详细</a>
                        </td>
                    </tr>
                    <%
                            count++;
                        }%>
                </table>
            </div>
        </div>
        <h3>
            洽谈记录：</h3>
        <div>
            <div class="r_content">
                <div class="tableNav">
                    <div class="tool_search">
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                        <tr>
                            <td width="30" class="table_title">
                            </td>
                            <td width="75" class="table_title">
                                业务人员名称
                            </td>
                            <td width="50" class="table_title">
                                回访日期
                            </td>
                            <%--   <td width="60" class="table_title">
                                会员类型
                            </td>--%>
                            <td width="70" class="table_title">
                                其他回访人员
                            </td>
                            <td width="70" class="table_title">
                                洽谈状态
                            </td>
                            <td width="80" class="table_title">
                                回访内容概要
                            </td>
                            <td width="130" class="table_title ">
                                操作
                            </td>
                        </tr>
                        <%
                            count = 1;
                            foreach (DiscussCustomerRecord discussCustomerRecord in DiscussRecords)
                            {%>
                        <tr class="tr_cur">
                            <td class="td_1">
                                <%=count%>
                            </td>
                            <td class="td_1">
                                <%=discussCustomerRecord.BussinessPerson.RealName%>
                            </td>
                            <td class="td_1">
                                <%=discussCustomerRecord.DiscussDate.ToShortDateString()%>
                            </td>
                            <td class="td_1">
                                <%=discussCustomerRecord.OtherPersonName%>
                            </td>
                            <td class="td_1">
                                <%=discussCustomerRecord.Content%>
                            </td>
                            <td class="td_1">
                                <%=discussCustomerRecord.Content%>
                            </td>
                            <td class="td_1">
                                <a href="../WebDiscuss/NewOrEdit.aspx?read=true&Id=<%=discussCustomerRecord.Id %>"
                                    target="rightFrame">详细</a>
                            </td>
                        </tr>
                        <%
                                count++;
                            }%>
                    </table>
                </div>
            </div>
        </div>
        <h3>
            客户消费记录：</h3>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                <tr>
                    <td width="30" class="table_title">
                    </td>
                    <td width="75" class="table_title">
                        总花费
                    </td>
                    <td width="50" class="table_title">
                        消费日期
                    </td>
                    <td width="70" class="table_title">
                        消费类型
                    </td>
                    <td width="70" class="table_title">
                        本次消费积分
                    </td>
                    <td width="80" class="table_title">
                        打折方式
                    </td>
                    <td width="130" class="table_title ">
                        操作
                    </td>
                </tr>
                <%
                    count = 1;
                    foreach (var discussCustomerRecord in this.ConsumRecords.OrderBy(m => m.ConsumptionDate))
                    {%>
                <tr class="tr_cur">
                    <td class="td_1">
                        <%=count%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.SpendTotal.ToString("C")%>
                    </td>
                    <td class="td_1">
                        <%= discussCustomerRecord.ConsumptionDate.HasValue ?discussCustomerRecord.ConsumptionDate.Value.ToShortDateString():string.Empty%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.ConsumerBusinessType != null ? discussCustomerRecord.ConsumerBusinessType.Name:string.Empty%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.Score%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.DiscountType.ItemName()%>
                    </td>
                    <td class="td_1">
                        <a href="../WebConsume/NewOrEdit.aspx?read=true&Id=<%=discussCustomerRecord.Id %>"
                            target="rightFrame">详细</a>
                    </td>
                </tr>
                <%
                        count++;
                    }%>
                <tr class="td_1">
                    <td>
                        <a href="../Chart/Children/ER_ExpenseTrend.aspx?read=true&CustomerId=<%=customer.Id %>"
                            target="rightFrame">消费趋势</a>
                    </td>
                </tr>
            </table>
        </div>
        <h3>
            客户联系人：</h3>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="item_list">
                <tr>
                </tr>
                <tr>
                    <td width="30" class="table_title">
                    </td>
                    <td width="80" class="table_title">
                        姓名
                    </td>
                    <td align="left" class="table_title" width="140">
                        性别
                    </td>
                    <td width="75" class="table_title">
                        联系号码
                    </td>
                    <td width="50" class="table_title">
                        手机号码
                    </td>
                    <td width="70" class="table_title">
                        职位
                    </td>
                    <td width="120" class="table_title">
                        生日
                    </td>
                    <td width="130" class="table_title ">
                        操作
                    </td>
                </tr>
                <%
                    count = 1;
                    foreach (var discussCustomerRecord in this.ContactList)
                    {%>
                <tr class="tr_cur">
                    <td class="td_1">
                        <%=count%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.Name%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.Sex%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.TelNumber%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.PhoneNumber%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.DutyName%>
                    </td>
                    <td class="td_1">
                        <%=discussCustomerRecord.Birthday.HasValue?discussCustomerRecord.Birthday.Value.ToShortDateString():string.Empty%>
                    </td>
                    <td class="td_1">
                        <a href="../WebCustomer/WebCorpContactInfo/NewOrEdit.aspx?read=true&ID=<%=discussCustomerRecord.Id %>"
                            target="rightFrame">详细</a>
                    </td>
                </tr>
                <%
                        count++;
                    }%>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
