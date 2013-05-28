<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUp.aspx.cs" Inherits="WebCrm.Web.SetUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 100px">
        <div>
            <span></span>
            <asp:Button ID="PlugBtn" runat="server" Text="1.插件初始化" OnClick="Button1_Click" Height="21px"
                Width="158px" />
        </div>
        <div>
            <span></span>
            <asp:Button ID="RoleBtn" runat="server" Text="2.增加系统管理员角色" OnClick="Button2_Click"
                Height="21px" Width="158px" />
        </div>
        <div>
            <span></span>
            <asp:Button ID="UserBtn" runat="server" Text="3.正在导入管理员" OnClick="Button3_Click"
                Height="21px" Width="158px" />
        </div>
        <div>
            <span></span>
            <asp:Button ID="RoleUserBtn" runat="server" Text="4.正在给管理员分配角色" Height="21px" OnClick="Button4_Click"
                Width="158px" />
        </div>
        <div>
            <span></span>
            <asp:Button ID="CrmBtn" runat="server" Text="5.正在初始化数据字典" Height="21px" Width="158px"
                OnClick="Button5_Click" />
        </div>
    </div>
    </form>
</body>
</html>
