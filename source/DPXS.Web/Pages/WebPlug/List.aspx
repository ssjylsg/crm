<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebCX.Web.Pages.WebPlug.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="rightArea">
         <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>功能菜单列表：</li>
                </ul>
            </div>
            <div class="r_content">
                <div class="tool_search">
                    <asp:Button ID="btnNew" runat="server" class="btn02 page_btnAdd"  Text="新增" 
                        onclick="btnNew_Click" />
                    <asp:Button ID="btnEdit" runat="server" class="btn02 page_btnEdit" Text="编辑" Enabled="false"
                        onclick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" class="btn02 page_btnDelete" Text="删除" OnClientClick="return confirm('确认删除？')"
                        Enabled="false" onclick="btnDelete_Click"/>
                    <asp:TextBox ID="txtQueryText" CssClass="input_1" runat="server"></asp:TextBox>
                    <asp:Button ID="btnQuery" runat="server"  class="btn02 page_btnQuery" Text="查询" 
                        onclick="btnQuery_Click" />
                </div>
                <div class="tableNav_2">
                    <asp:TreeView ID="TreeView1" runat="server"  ShowLines="True" 
                        onselectednodechanged="TreeView1_SelectedNodeChanged">
                        <SelectedNodeStyle BorderColor="#FF3300" BorderWidth="1px" />                            
                    </asp:TreeView>
                </div>
                <div class="tool_2"></div>
            </div>
         </div>
    </div>
    </form>
</body>
</html>
