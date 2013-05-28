<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebCrm.MvcWeb.Models.EvernoteModel>" %>

<%@ Import Namespace="WebCrm.MvcWeb.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddEvernote
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (this.Html.BeginForm())
      {%>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <div class="editor-label">
                标题：
                <%=this.Html.HiddenFor(m=>m.ID) %>
                <%= Html.TextBoxFor(m => m.Title)%>
            </div>
            <div class="editor-field">
                内容：
                <%= Html.TextBoxFor(m => m.Content) %>
            </div>
            <div class="editor-label">
                创建人
                <%=this.Html.DropDownListFor(m => m.CreateUser, HelperMvc.BindBussinessPerson(Model != null?Model.CreateUser.ToString():string.Empty))%>
            </div>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
    </div>
    <%
      }%>
</asp:Content>
