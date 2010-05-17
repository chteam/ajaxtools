<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S.aspx.cs" Inherits="FlexigridMvcDemo.S" %>
<%@ Import Namespace="MvcAjaxToolkit.Flexigrid.Enum" %>
<%@ Import Namespace="MvcAjaxToolkit.Flexigrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  	<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<%if (false)
	  {
	%>

	<script src="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
	<%
		} %><link href="Content/Site.css" rel="stylesheet" type="text/css" />
	<script src="Scripts/menu/contextmenu.pack.js" type="text/javascript"></script>
    <script src="Scripts/tmpl/jquery.tmpl.js" type="text/javascript"></script>
	<script src="Scripts/flexigrid/flexigrid.js" type="text/javascript"></script>
	<link href="Content/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
	<link href="Content/menu/cm_default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var process = {
            add: function (d) {
                alert(d.row.id);
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%= new FlexigridTableSettings<FlexigridMvcDemo.Models.UserInfo>()
             .TableId("flex1")
             .Action("/Ajax/GetEntity")
             .Columns(col => 
               {
                   col.Bind(e => e.Id, "Id").Hide();
                   col.Bind(e => e.Name, "Name",180,true).Align(FlexigridAlign.Left);
                   col.Bind(e => e.Email).Width(20).Title("email");
                   col.Bind(e => e.Age).Title("Age").Width(300)
                       .Template("<span style='color:red'> ${Name} - ${Id} </span>");
               })
            //.DefaultSortOption("Id", FlexiGridSortOrder.Ascending)
            .Title("Employees")
            .SetPageSize(10)
            .ColumnsMove()
            .ColumnsResize()
            //  .ContextMenu("#tablemenu","process")
           // .ShowTableToggleButton(false)
           // .Width(800)
            //.Height(200)
            .AutoLoad()
            .SetPager() 
        %>
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
    </div>

    <%--  <%= new FlexigridTableSettings<System.Data.DataRow>()
          .TableId("flex2")
          .Action("/Ajax/GetEntity")
          .Columns(col => 
               {
                   col.Bind("Id", "编号").Hide();
                   col.Bind("Name", "名称",180,true).Align(FlexigridAlign.Left);
                   col.Bind("Email").Width(20).Title("邮箱");
                   col.Bind("Age").Width(180).Title("年龄").Sortable().Align(FlexigridAlign.Right);
               })
              //  .SetPager(".page") 
          .SetPageSize(2)
          .AutoLoad()
        
%>
--%>
    </form>
</body>
</html>
