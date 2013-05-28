<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="WebCX.Web.Pages.WebLoginInfo.Assign" %>

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
                    <li>
                        角色分配对象--><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>：
                    </li>
                </ul>
            </div>
            <div class="r_content">
                <table border="0" cellspacing="0" cellpadding="10px">
                	<tr>
                		<td style="vertical-align:top; width:200px;">
                            <asp:TreeView ID="tvRole" runat="server"  ShowLines="True" 
                                ShowCheckBoxes="Leaf" ontreenodecheckchanged="tvRole_TreeNodeCheckChanged"
                                onclick="TreeViewCheckBox_Click(event)">                          
                            </asp:TreeView>  
                        </td>
                        <td style=" vertical-align:top;  width:180px; border-left:1px dashed #006699;">
                            <asp:TreeView ID="tvMenu" runat="server"  ShowLines="True" 
                                ShowCheckBoxes="Leaf" onclick="TreeViewCheckBox_Click(event)" 
                                Enabled="False">                          
                            </asp:TreeView>
                        </td>
                        <td style="vertical-align:top; text-align:left; padding-bottom:10px;">
                            
                            <asp:TreeView ID="tvReport" runat="server"  ShowLines="True" 
                                ShowCheckBoxes="Leaf" Enabled="False"
                                onclick="TreeViewCheckBox_Click(event)">                          
                            </asp:TreeView>
                        </td>
                	</tr>
                </table>
                <div class="tool_2">
                    <asp:Button ID="btnBack" runat="server" style=" margin-top:5px;" class="btn02 page_btnBack" Text="返回" 
                        onclick="btnBack_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
