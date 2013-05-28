<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upLoad.aspx.cs" Inherits="WebCrm.Web.UcControl.upLoad" %>

<%@ Import Namespace="WebCrm.Web.Facade" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <script src='<%=AspNetHelper.WebUrl()+"/Scripts/jquery-2.0.0.min.js" %>' type="text/javascript"></script>
    <script src='<%=AspNetHelper.WebUrl() +"/Scripts/jquery.form.js"%>' type="text/javascript"></script>
    <link href="../Admin/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/right.css" rel="stylesheet" type="text/css" />
    <div class="r_ContentNav">
        <div class="ui-tabs-panel" style="width: 478px; margin-left: 0px">
            <ul class="info_input">
                <li>
                    <div class="ii_conarea" style="width: 500px">
                        <input id="fulFile" name="fulFile" type="file" class="ful" />
                        <img id="imgUploading" src='<%=AspNetHelper.WebUrl() + "/images/uploading.gif"%>'
                            alt="正在上传..." class="loading_img none" style="display: none" />
                        <input type="hidden" id='fileID' name="fileID" />
                        <input id="btnSubmit" type="button" value="上传" class="btn_sub" />
                    </div>
                    <div>
                        <table id="filesTable" border="0" cellspacing="0" cellpadding="0" width="100%" class="item_list">
                            <tr>
                                <td class="table_title">
                                    文件名称
                                </td>
                                <td class="table_title">
                                    上传时间
                                </td>
                                <td class="table_title">
                                    文件大小
                                </td>
                                <td class="table_title">
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#fileID').val('');
            $("#btnSubmit").click(function () {

                var queryString = $("[id$='form1']").formSerialize();

                if ($("[id$='fulFile']").val() == "") {
                    alert("请选择要上传的文件!");
                    return false;
                }


                $("[id$='form1']").ajaxSubmit({
                    url: '<%=AspNetHelper.WebUrl() + "/Admin/UploadHandler.ashx" %>',
                    type: "post",
                    dataType: "json",
                    resetForm: "true",
                    beforeSubmit: function () {
                        $("[id$='fulFile']").hide();
                        $("[id$='imgUploading']").show();
                        $("[id$='btnSubmit']").hide();
                    },
                    success: function (msg) {

                        $("[id$='fulFile']").show();
                        $("[id$='imgUploading']").hide();
                        $("[id$='btnSubmit']").show();

                        if (msg.Success == false) {
                            alert('上传失败');
                            return false;
                        }

                        var html = '><td>' + msg.Data.FileName + '</td>'
                        + '<td>' + msg.Data.CreateTime + '</td>'
                         + '<td>' + msg.Data.FileSize + 'KB</td>'
                         + '<td> <a href=\'javascript:void(0)\' onclick=deleteFile(' + msg.Data.ID + ')> <span style=\'color:red\'>删除</span></a></td>'
                         ;

                        $("#filesTable").append('<tr id=tr_' + msg.Data.ID + html + '</tr>');
                        $('#fileID').val($('#fileID').val() + ',' + msg.Data.ID);

                        parent.document.getElementById('fileID').value = $('#fileID').val();

                        var obj = parent.document.getElementById("loadFrame");  //取得父页面IFrame对象
                        // alert(obj.height); //弹出父页面中IFrame中设置的高度
                        obj.height = obj.scrollHeight + 15;  //调整父页面中IFrame的高度为此页面的高度 
                        return false;
                    },
                    error: function (jqXHR, errorMsg, errorThrown) {
                        $("[id$='fulFile']").show();
                        $("[id$='imgUploading']").hide();
                        $("[id$='btnSubmit']").show();
                        alert("错误信息:" + errorMsg);
                        return false;
                    }
                });
            });
        });
        function fillForm(queryStr) {
            var q = queryStr.toString().split('&');
            for (var i = 0; i < q.length; i++) {
                var q1 = q[i].split('=');
                var key = q1[0];
                var value = q1[1];
                if (value != '' && key != 'fileID' && key != '__VIEWSTATE' && key != '__EVENTVALIDATION') {
                    $('#' + key).val(value);
                }
            }
        }
        function deleteFile(id) {
            $("#filesTable tr[id='tr_" + id + "']").remove();
            $('#fileID').val($('#fileID').val().replace(',' + id, ''));
        }
    </script>
    </form>
</body>
</html>
