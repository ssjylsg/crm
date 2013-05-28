<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="DPXS.Web.Admin.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传文件</title>
    <base target="_self" />
    <style type="text/css">    
    input{ border:1px solid #ccc;}
    body{ margin:0px; font-size:9pt;}
    #main{ margin:5px 0px; padding:5px; border:1px dashed #ccc;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        上传文件到服务器<br />
        <asp:FileUpload ID="fileUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="上 传" Width="47px" Height="20px" OnClick="btnUpload_Click" OnClientClick="return checkForm();"/><br />
        <asp:HiddenField ID="hidFileName" runat="server" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function $(id) {
        return document.getElementById(id);
    }
    function checkForm() {
        if ($('fileUpload').value == '') {
            $('lblMessage').innerHTML = "请选择文件！";
            return false;
        }
        return true;
    }
</script>