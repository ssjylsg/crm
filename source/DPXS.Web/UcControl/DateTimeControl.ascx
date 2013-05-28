<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTimeControl.ascx.cs" Inherits="WebCrm.Web.UcControler.DateTimeControl" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>
<script language="javascript" type="text/javascript" src="<%=AspNetHelper.WebUrl() %>/My97DatePicker/WdatePicker.js"></script>
<asp:TextBox ID="BirthDateID" runat="server" onClick="WdatePicker({ dateFmt: 'yyyy-MM-dd'})" class="Wdate"></asp:TextBox>
 