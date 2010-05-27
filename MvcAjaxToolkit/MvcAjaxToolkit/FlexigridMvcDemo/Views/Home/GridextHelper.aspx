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
<script type="text/javascript">
    var process = {
        add: function (d) {
            alert(d.row.Id);
        }
    };
    </script>
      <%= new MvcAjaxToolkit.Flexigrid
    .TableSettings<FlexigridMvcDemo.Models.UserInfo>(this.Page)
           .TableId("flex1")
             .Action("/Ajax/GetEntity")
             .Columns(col => 
               {
                   col.Bind(e => e.Id, "Id").Hide();
                   col.Bind(e => e.Name, "Name", 180, true).Align(TextAlignMode.Left);
                   col.Bind(e => e.Email).Width(20).Title("email");
                   col.Bind(e => e.Age).Title("Age").Width(300)
                       .Template("<span style='color:red'> ${name} - ${id} </span>");
               })
            .Title("Employees")
            .SetPageSize(10)
            .ContextMenu("#tablemenu","process")
            .AutoLoad()
            .SetPager(".page") 
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
</asp:Content>
