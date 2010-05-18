<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Content" ContentPlaceHolderID="HeadContent">
    <%if (false)
      {%>
    <script src="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <%}%>
     <script src="/Scripts/tmpl/jquery.tmpl.js" type="text/javascript"></script>
    <script src="/Scripts/menu/contextmenu.pack.js" type="text/javascript"></script>
    <link href="/Content/menu/cm_default/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/flexigrid/flexigrid.js" type="text/javascript"></script>
    <link href="/Content/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

    <table id="flex1" style="display: none;">
    </table>
    <script type="text/javascript">
        var process = {
            add: function (d) {
                $.post('/Ajax/Add', {}, function (r) { if (r == "") d.sender.flexReload(); });
            },
            remove: function (d) {
                $.post('/Ajax/Remove', { 'id': d.row.id }, function (r) { if (r == "") d.sender.flexReload(); });
            },
            reload: function (d) {
                d.sender.flexReload();
            },
            fourp: function (d) {
                d.sender.flexGetPage(4, { a: 1, b: 2 });
            }
        };
        (function () {
            var cols = [
              { display: 'Id', name: 'id', width: 40, sortable: true, align: 'center' },
				{ display: 'User Name', name: 'name', width: 180, sortable: false, align: 'left' },
				{ display: 'User Email', name: 'email', width: 120, sortable: false, align: 'left' },
				{ display: 'User Age', name: 'age', width: 130, sortable: false, align: 'left'
				},
{ name: 'numcode',
    process: function (e, c) {
        $(e).html("").append('<span style=\\\'color:red\\\'> ${name} - ${age} {{if age==1}} [] {{/if}}</span>', c);
    }
 , display: 'Operation'
}];
            $("#flex1").gridext('/Ajax/GetEntity', cols, '#tablemenu', process,
			 { usedefalutpager: false, rp: 10, autoload: true, colResize: true, colMove: true, pager: "#pager" }); ;
        })();
    </script>
        <ul id="tablemenu" class="jeegoocontext cm_default">
        <li id="add">随机添加一条数据</li>
        <li id="remove">删除此条</li>
        <li id="reload">刷新</li>
        <li id="fourp">4页</li>
        <li id="al5">all
            <ul>
                <li>1111</li>
                <li>222</li>
                <li>333</li>
            </ul>
        </li>
    </ul>
</asp:Content>
