<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authority.aspx.cs" Inherits="WebCX.Web.Pages.WebSysRole.Authority" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function TreeViewCheckBox_Click(e) {
            if (window.event == null)
                o = e.target;
            else
                o = window.event.srcElement;
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                __doPostBack("", "");
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightArea">
        <div class="r_ContentNav">
            <div class="r_tit1">
                <ul>
                    <li>功能授权对象--><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>： </li>
                </ul>
            </div>
            <div class="r_content">
                <table border="0" cellspacing="0" cellpadding="10px">
                    <tr>
                       <%-- <td style="vertical-align: top; width: 300px;">
                            <asp:TreeView ID="tvReport" runat="server" ShowLines="True" ShowCheckBoxes="Leaf"
                                OnTreeNodeCheckChanged="tvReport_TreeNodeCheckChanged" onclick="TreeViewCheckBox_Click(event)">
                            </asp:TreeView>
                        </td>--%>
                        <td style="vertical-align: top; width: 180px; border-right: 1px dashed #006699;">
                            <asp:TreeView ID="tvMenu" runat="server" ShowLines="True" ShowCheckBoxes="Leaf" OnTreeNodeCheckChanged="tvMenu_TreeNodeCheckChanged"
                                onclick="TreeViewCheckBox_Click(event)">
                            </asp:TreeView>
                        </td>
                        <td style="vertical-align: top; text-align: left; margin-bottom: 10px;">
                            <asp:TreeView ID="tvUser" runat="server" ShowLines="True" ShowCheckBoxes="Leaf" OnTreeNodeCheckChanged="tvUser_TreeNodeCheckChanged"
                                onclick="TreeViewCheckBox_Click(event)">
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
                <div class="tool_2">
                   <input type="button" class="btn02 page_btnBack" value="返回" onclick="location.href='List.aspx'" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
