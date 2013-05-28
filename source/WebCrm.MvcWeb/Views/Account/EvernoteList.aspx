<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<WebCrm.MvcWeb.Models.EvernoteModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EvernoteList
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=Html.ActionLink("新增", "AddEvernote")%>
    <a href="javascript:void" onclick="autoGenerate()">自动生成</a>
     <a href="javascript:void" onclick="deleteAll()">删除所有</a>
      <a href="javascript:void" onclick="getAll()">Json Ajax 获取全部</a>
    <table>
        <tr>
            <th>
                ID
            </th>
            <th>
                Title
            </th>
            <th>
                ReleaseDate
            </th>
            <th>
                Genre
            </th>
            <th>
                Price
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           {%>
        <tr>
            <td>
                <%=Html.DisplayFor(modelItem => item.ID)%>
            </td>
            <td>
                <%=Html.DisplayFor(modelItem => item.Title)%>
            </td>
            <td>
                <%=Html.DisplayFor(modelItem => item.DisplayName)%>
            </td>
            <td>
                <%=Html.DisplayFor(modelItem => item.Content)%>
            </td>
            <td>
                <%=Html.DisplayFor(modelItem => item.Content)%>
            </td>
            <td>
                <%=Html.ActionLink("编辑", "AddEvernote", new { id = item.ID })%>
                <a href="javascript:void" onclick="deleteEvernote('<%=item.ID %>')">删除</a>
            </td>
        </tr>
        <%
           }%>
    </table>
    <script>
        function deleteEvernote(itemId) {
            $.post('<%=Url.Action("DeleteEvernote") %>', { id: itemId }, function (data) {
                if (data.Success) {
                    window.location.reload();
                }
            });
        }
        function autoGenerate() {
            $.post('<%=Url.Action("AutoGenerate") %>', function (data) {
                if (data.Success) {
                    window.location.reload();
                }
            });
        }
        function deleteAll() {
            $.post('<%=Url.Action("DeleteAll") %>', function (data) {
                if (data.Success) {
                    window.location.reload();
                }
            });
        }
        function getAll() {
            $.post('<%=Url.Action("GetAll") %>', function (data) {
                if (data.Success) {
                    alert(data.Data.toString());
                }
            });
        }
    </script>
</asp:Content>
