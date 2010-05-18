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
    <table id="myFlexigrid">
    <thead>
        <tr>
            <th width="200">Id</th>
            <th width="400">Name</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>1</td>
            <td>Jack</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Alpha</td>
        </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        $('#myFlexigrid').flexigrid();
    </script>
</asp:Content>
