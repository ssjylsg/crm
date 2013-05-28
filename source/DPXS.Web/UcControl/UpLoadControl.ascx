<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpLoadControl.ascx.cs"
    Inherits="WebCrm.Web.UcControl.UpLoadControl" %>
<%@ Import Namespace="WebCrm.Web.Facade" %>
<div style="height: auto">
    <input type="hidden" id='fileID' name="fileID" />
    <iframe src="<%=AspNetHelper.WebUrl() +"/UcControl/upload.aspx" %>" id="loadFrame"
        name="loadFrame" scrolling="no" frameborder="0" width="500px" height="65px">
    </iframe>
</div>
