<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl< MvcAjax.DateBindOption>" %>
<div>
    hidden with selectvalue;
    <select id="<%=Model.ID %>_year">
    </select>
    <select id="<%=Model.ID %>_month">
    </select>
    <select id="<%=Model.ID %>_day">
    </select>
    <input type="text" id="<%=Model.ID %>" name="<%=Model.ID %>" value="2009-3-19 10:40:44" />
</div>

<script type="text/javascript">
    $("#demo").dateselect({ begin: 1985, end: 2033 });
    $("#demo1").dateselect();
</script>

