<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlexigridDemo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>

<%--	<script src="Scripts/jquery.js" type="text/javascript"></script>
--%>
	<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<%if (false)
	  {
	%>

	<script src="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

	<%
		} %>
        <script src="Scripts/tmpl/jquery.tmpl.js" type="text/javascript"></script>
	<script src="Scripts/menu/contextmenu.pack.js" type="text/javascript"></script>
	<script src="Scripts/flexigrid/flexigrid.js" type="text/javascript"></script>
	<link href="Content/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
	<link href="Content/menu/cm_default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<%--<table  class="table22">
			<thead>
				<tr>
					<th width="50">
						ID
					</th>
					<th width="200">
						Name
					</th>
					<th width="350">
						Email
					</th>
					<th width="50">
						Age
					</th>
				</tr>
			</thead>
			<tbody>
				<%foreach (var dataRow in GetData())
				  {
				%>
				<tr>
					<td>
					<%=dataRow["Id"] %></td>
					<td>
					<%=dataRow["Name"]%></td>
					<td>
					<%=dataRow["Email"]%></td>
					<td>
					<%=dataRow["Age"]%></td>
				</tr>
				<%
					} %>
			</tbody>
		</table>--%>
		<br />
		<input name="name" type="text" class="filter" />
		<input name="email" type="text" class="filter" />
		<input type="button" value="search" onclick="search();" />
		<br />
		<table border="0" cellpadding="0" cellspacing="0" class="table1">
			<tr>
				<td></td>
			</tr>
		</table>
	</div>
	</form>

	<script type="text/javascript">
	//	$(".table22").flexigrid();
		function search() {
			$('.table1').flexGetPage(1, $(".filter").serializeArray());
		}
	</script>

	<script type="text/javascript">
	    var process = {
	        add: function (d) {
	            $.post('Ajax/Add', {}, function (r) { if (r == "") d.sender.flexReload(); });
	        },
	        remove: function (d) {
	            $.post('Ajax/Remove', { 'id': d.row.id }, function (r) { if (r == "") d.sender.flexReload(); });
	        },
	        reload: function (d) {
	            d.sender.flexReload();
	        },
	        fourp: function (d) {
	            d.sender.flexGetPage(4, { a: 1, b: 2 });
	        }
	    };
		(function () {
		    var colModel = [
				{ display: '编号', name: 'id', width: 40, sortable: true, align: 'center' },
				{ display: '姓名', name: 'name', width: 180, sortable: false, align: 'left' },
				{ display: '邮件', name: 'email', width: 120, sortable: false, align: 'left' },
				{ display: '年龄', name: 'age', width: 130, sortable: false, align: 'left'
				}, { display: '操作', name: 'numcode', width: 80, align: 'right',
process:function(e,c){$(e).html("").append('<span style="color:red"> ${name} - ${age} </span>', c);}
                	}
				];
		    
		    $(".table1").gridext('Ajax/GetEntity', colModel, '#tablemenu', process,
			 { usedefalutpager: false, rp: 10, autoload: true, colResize: true, colMove: true, pager: "#pager" }); ;
		})();
		
	</script>
    <div id="pager" style="background:red"></div>
	<div class="page">
	</div>
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

     <table id="flex1" style="display:none;">
 
</table><script type="text/javascript">
            (function () {
                var cols = [
              { display: '编号', name: 'id', width: 40, sortable: true, align: 'center' },
				{ display: '姓名', name: 'name', width: 180, sortable: false, align: 'left' },
				{ display: '邮件', name: 'email', width: 120, sortable: false, align: 'left' },
				{ display: '年龄', name: 'age', width: 130, sortable: false, align: 'left'
				}, 
{ name: 'numcode',
    process: function (e, c) {
        $(e).html("").append('<span style=\\\'color:red\\\'> ${name} - ${age} {{if age==1}} [] {{/if}}</span>', c);
    }
 , display: 'Age'}];
$("#flex1").gridext('Ajax/GetEntity', cols, '#tablemenu', process,
			 { usedefalutpager: false, rp: 10, autoload: true, colResize: true, colMove: true, pager: "#pager" }); ;
})();
</script>

</body>
</html>
