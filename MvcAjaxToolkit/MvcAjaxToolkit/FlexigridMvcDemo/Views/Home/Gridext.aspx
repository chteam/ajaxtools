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
    <table id="flex1" style="display:none;"></table>
    <script type="text/javascript">
        (function () {
            var cols = [
                { display: '±àºÅ', name: 'id', width: 40, sortable: true, align: 'center' },
				{ display: 'ĞÕÃû', name: 'name', width: 180, sortable: false, align: 'left' },
				{ display: 'ÓÊ¼ş', name: 'email', width: 120, sortable: false, align: 'left' },
				{ display: 'ÄêÁä', name: 'age', width: 130, sortable: false, align: 'left'
				}
                ];
            $("#flex1").gridext('<%=Url.Action("GetEntity","Ajax") %>', cols, null, null,
			 { usedefalutpager: false, rp: 10, autoload: true, colResize: true, colMove: true, pager: "#pager" }); ;
        })();
    </script>
    
</asp:Content>
