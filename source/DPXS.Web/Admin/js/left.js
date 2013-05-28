


var subMenuData = null;
var firstMenuData = null;
var parentIDs = "";

var subWebReportMenuData = null;
var firstWebReportMenuData = null;
var webReportParentIDs = "";

//常规菜单
var getMyMenu = function (postUrl) {
    //先加载拥有权限的二级菜单数据

    $.ajax({
        type: 'POST',
        url: postUrl,
        dataType: 'JSON',
        data:
       {
           sign: 'subMenu'
       },
        success: function (jsonData) {
            //return;

            subMenuData = jsonData; //JSON.parse(jsonData); // 李世岗 调整
            for (var i = 0; i < jsonData.length; i++) {
                var item = jsonData[i]
                parentIDs += item[1] + ","; //item[1]-->PARENT_ID
            }
            //再加载所有的一级菜单数据
            getFirstMenu(postUrl);
        }
    });
}

var getFirstMenu = function (postUrl) {
    $.ajax({
        type: 'POST',
        url: postUrl,
        dataType: 'JSON',
        data:
       {
           sign: 'firstMenu'
       },
        success: function (jsonData) {
            firstMenuData = jsonData; // JSON.parse(jsonData); // 李世岗 调整;
            for (var i = 0; i < jsonData.length; i++) {
                var item = jsonData[i]
                if (parentIDs.indexOf(item.ID + ',') != -1) {
                    genFirstMenuHTML(item);
                }
            }

            //生成完所有的一级菜单后，再添加所有的二级菜单

            for (var i = 0; i < subMenuData.length; i++) {
                var item = subMenuData[i];
                genSubMenuHTML(item);
            }

            //点击事件添加上
            beforeJSFn();

            //getMyWebReportMenu();
        }
    });
}

//生成一级菜单
var genFirstMenuHTML = function (item) {
    var id = item.ID;
    var text = item.FUN_NAME;
    var html = '<div class="l_menu_1" id="firstMenu_' + id + '">';
    html += '<h3><a class="menu_1_on">' + text + '</a></h3>';
    html += '<ul id="firstMenuUl_' + id + '">';
    html += '</ul>';
    html += '</div>';
    $('#leftmenu').append(html);
}

//生成二级菜单
var genSubMenuHTML = function (item) {
    var id = item[0];
    var parentID = item[1];
    var name = item[2];
    var url = item[4];
    html = '<li class="menu_2_off"><a href="' + url + '" target="rightFrame">' + name + '</a></li>';
    $('#firstMenuUl_' + parentID).append(html);
}

//之前控制菜单点击脚本
var beforeJSFn = function () {
    var h3 = $('.l_menu_1 h3');
    var ul = $('.l_menu_1 ul');

    var hideAll = function () {
        h3.find('a').attr('class', 'menu_1_on');
        ul.hide();
    };

    var menu = $('.l_menu_1 h3').click(function () {
        hideAll();
        $(this).next().show();
        $(this).find("a").attr('class', 'menu_1_off');
    });

    hideAll();
}

//报表菜单
var getMyWebReportMenu = function () {
    return; // 李世岗 报表不使用
    //先加载拥有权限的二级菜单数据
    $.ajax({
        type: 'POST',
        url: 'left.aspx',
        dataType: 'JSON',
        data:
       {
           sign: 'subWebReportMenu'
       },
        success: function (jsonData) {
            subWebReportMenuData = jsonData; // JSON.parse(jsonData); // 李世岗 调整;
            for (var i = 0; i < jsonData.length; i++) {
                var item = jsonData[i]
                webReportParentIDs += item[1] + ","; //item[1]-->PARENT_ID
            }
            //再加载所有的一级菜单数据
            getFirstWebReportMenu();
        }
    });
}

var getFirstWebReportMenu = function () {
    return; // 李世岗 报表不使用
    $.ajax({
        type: 'POST',
        url: 'left.aspx',
        dataType: 'JSON',
        data:
       {
           sign: 'firstWebReportMenu'
       },
        success: function (jsonData) {
            firstWebReportMenuData = JSON.parse(jsonData); // 李世岗 调整;
            for (var i = 0; i < jsonData.length; i++) {
                var item = jsonData[i]
                if (webReportParentIDs.indexOf(item.ID + ',') != -1) {
                    genFirstWebReportMenuHTML(item);
                }
            }

            //生成完所有的一级菜单后，再添加所有的二级菜单
            for (var i = 0; i < subWebReportMenuData.length; i++) {
                var item = subWebReportMenuData[i];
                genSubWebReportMenuHTML(item);
            }

            //点击事件添加上
            beforeJSFn();
        }
    });
}


//生成一级菜单
var genFirstWebReportMenuHTML = function (item) {
    var id = item.ID;
    var text = item.NAME;
    var html = '<div class="l_menu_1" id="firstWebReportMenu_' + id + '">';
    html += '<h3><a class="menu_1_on">' + text + '</a></h3>';
    html += '<ul id="firstWebReportMenuUl_' + id + '">';
    html += '</ul>';
    html += '</div>';
    $('#leftmenu').append(html);
}

//生成二级菜单
var genSubWebReportMenuHTML = function (item) {
    var id = item[0];
    var parentID = item[1];
    var name = item[2];
    var isOnline = item[3];
    var filePath = item[4];
    var url = "";
    if (isOnline == 1) {
        filePath = escape(filePath);
        url = "../Pages/ReportOnline/ShowReport.aspx?path=" + filePath + '&reportInfoID=' + id;
    }
    else {
        url = "../Pages/WebReportInfo/ReadFrx.aspx?path=" + filePath;
    }

    html = '<li class="menu_2_off"><a href="' + url + '" target="rightFrame">' + name + '</a></li>';
    $('#firstWebReportMenuUl_' + parentID).append(html);
}
