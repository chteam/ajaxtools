﻿using System;
using System.IO;
using System.Text;
using System.Web.UI;
using MvcAjaxToolkit.Interface;

namespace MvcAjaxToolkit.Flexigrid
{
    public class FlexigridRender<T> : IGridRender<TableSettings<T>> where T : class
    {
        //private static int _gridGlobalIndex;
        private string _id = string.Empty;
        public string Render(TableSettings<T> data)
        {
            // 初始化基本信息
            _id = string.IsNullOrEmpty(data.GridId)
                          ? string.Format("FlexiGrid_{0}", Guid.NewGuid().ToString("N"))
                          : data.GridId;
            using (var sw = new StringWriter())
            {
                using (var writer = new HtmlTextWriter(sw))
                {
                    //创建Table
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, _id);
                    writer.RenderBeginTag(HtmlTextWriterTag.Table);
                    writer.RenderEndTag();
                    if (!data.EnableDefaultPager && !string.IsNullOrEmpty(data.PageFilter))
                    {
                        //添加显示分页的HTML
                        if (data.PageFilter.StartsWith("#"))
                            writer.AddAttribute(HtmlTextWriterAttribute.Id, data.PageFilter.Substring(1));
                        if (data.PageFilter.StartsWith("."))
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, data.PageFilter.Substring(1));
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.RenderEndTag();
                    }
                    // 创建Script标签
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, @"text/javascript");
                    writer.RenderBeginTag(HtmlTextWriterTag.Script);
                    writer.Write(GenerateJavascript(data));
                    writer.RenderEndTag();
                }
                return sw.ToString();
            }
        }

        //生成Javascript，此Javascript加以作用域控制
        private string GenerateJavascript(TableSettings<T> data)
        {
            var sb = new StringBuilder();
            sb.Append("(function(){").Append("var cols=[");
            int count = 0;
            int totalCount = data.GridColumns.Count;
            //生成列
            foreach (Column column in data.GridColumns)
            {
                count++;
                sb.Append("{");
                if (!string.IsNullOrEmpty(column.FieldName))
                    sb.AppendFormat("name:'{0}',", column.FieldName);
                if (column.ColumnSettings.ColumnWidth > 0)
                    sb.AppendFormat("width:{0},", column.ColumnSettings.ColumnWidth);
                if (column.ColumnSettings.ColumnSortable)
                    sb.Append("sortable:true,");
                if (column.ColumnSettings.ColumnAlignment != 0)
                    sb.AppendFormat("align:'{0}',", column.ColumnSettings.ColumnAlignment.GetDescription());
                if (column.ColumnSettings.ColumnHidden)
                    sb.Append("hide:true,");
                if (!string.IsNullOrEmpty(column.ColumnSettings.ColumnTemplate) 
                    || !string.IsNullOrEmpty(column.ColumnSettings.ColumnJavascript))
                {
                    sb.Append("process:function(e,c){");
                    if (!string.IsNullOrEmpty(column.ColumnSettings.ColumnTemplate))
                        sb.AppendFormat("$(e).html(\"\").append('{0}',c);",
                                        column.ColumnSettings.ColumnTemplate.Trim()
                                            .Replace("\\'", "'")
                                            .Replace("'", "\\\\\\'"));
                    sb.Append(column.ColumnSettings.ColumnJavascript);
                    sb.Append("},");
                }
                sb.AppendFormat("display:'{0}'", column.ColumnSettings.ColumnTitle).Append("}");
                if (count < totalCount)
                {
                    sb.AppendLine(",");
                }
            }
            sb.AppendLine("];");
            sb.AppendFormat(@"$('#{0}').gridext('{1}',cols,'{2}',{3},",
                            _id, data.ActionUrl, data.MenuId, data.MenuProcess ?? "null")
                .Append("{");
            if (data.EnableDefaultPager)
                sb.Append("usedefalutpager:true,");
            if (!string.IsNullOrEmpty(data.PageFilter))
                sb.AppendFormat("pager:'{0}',", data.PageFilter);
            if (data.EnableAutoLoad)
                sb.Append("autoload:true,");
            if (data.GridWidth > 0)
                sb.AppendFormat("height:{0},", data.GridHeight);
            if (!string.IsNullOrEmpty(data.GridTitle))
                sb.AppendFormat("title:'{0}',", data.GridTitle);
            if (data.ColMove)
                sb.Append("colMove:true,");
            if (data.ColResize)
                sb.Append("colResize:true,");
            if (data.GridDataType != DataType.Json)
                sb.Append("dataType:'xml',");
            sb.AppendFormat("rp:{0}", data.PageSize).Append("});");
            // $(".table1").gridext('Ajax/GetEntity', colModel, '#tablemenu', process,
            //{ colResize: true, colMove: true}); ;
            sb.Append("})();");

            return sb.ToString();
        }

    }
}