<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="HeadContent">
<%if (false)
      {%>
    <script src="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <%}%>
    <script src="/Scripts/flexigrid/flexigrid.js" type="text/javascript"></script>
    <link href="/Content/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
   <div style="width:400px">
    <table id="flex1" style="display:none;"></table>
    </div>
    <script type="text/javascript">
        (function () {
            var cols = [
                { display: '编号', name: 'Id', width: 40, sortable: true, align: 'center' },
				{ display: '姓名', name: 'Name', width: 180, sortable: false, align: 'left' },
				{ display: '邮件', name: 'Email', width: 120, sortable: false, align: 'left' },
				{ display: '年龄', name: 'Age', width: 130, sortable: false, align: 'left'},
                { display: '年龄', name: 'Age', width: 130, sortable: false, align: 'left'},
                { display: '年龄', name: 'name', width: 130, sortable: false, align: 'left'}
                ];
            $("#flex1").gridext('<%=Url.Action("Index","Ajax") %>', cols, null, null,
			 { usedefalutpager: false, rp: 10, autoload: true, colResize: true, colMove: true, pager: "#pager" }); ;
        })();
    </script>
    
</asp:Content>
