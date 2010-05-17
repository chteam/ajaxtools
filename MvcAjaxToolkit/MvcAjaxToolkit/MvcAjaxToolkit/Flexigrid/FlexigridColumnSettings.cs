using MvcAjaxToolkit;

namespace MvcAjaxToolkit.Flexigrid
{
    public class ColumnSettings
    {
        internal FlexigridAlign ColumnAlignment { get; private set; }
        internal bool ColumnSortable { get; private set; }
        internal string ColumnTitle { get; private set; }
        internal int ColumnWidth { get; private set; }
        internal bool ColumnHidden { get; private set; }
        internal string ColumnTemplate { get; private set; }
        internal string ColumnJavascript { get; private set; }

        /// <summary>
        /// 设置当前列的宽度 未指定的情况下将置为100
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public ColumnSettings Width(int width)
        {
            ColumnWidth = width;
            return this;
        }
        /// <summary>
        /// 设置当前列的标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ColumnSettings Title(string title)
        {
            ColumnTitle = title;
            return this;
        }
        /// <summary>
        /// 设置为可排序
        /// </summary>
        /// <returns></returns>
        public ColumnSettings Sortable()
        {
            Sortable(true);
            return this;
        }
        /// <summary>
        /// 设置当前列是否可排序
        /// </summary>
        /// <param name="sortable"></param>
        /// <returns></returns>
        public ColumnSettings Sortable(bool sortable)
        {
            ColumnSortable = sortable;
            return this;
        }
        /// <summary>
        /// 设置当前列对齐方式
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        public ColumnSettings Align(FlexigridAlign align)
        {
            ColumnAlignment = align;
            return this;
        }
        /// <summary>
        /// 设置当前列为隐藏列
        /// </summary>
        /// <returns></returns>
        public ColumnSettings Hide()
        {
            ColumnHidden = true;
            return this;
        }
        /// <summary>
        /// 为当前列设置显示模板
        /// </summary>
        /// <returns></returns>
        public ColumnSettings Template(string template)
        {
            ColumnTemplate = template;
            return this;
        }
        /// <summary>
        /// 为当前列设置Javascript脚本会在模板进行后执行
        /// 编写此Javascript可用$(e)为当前td内部的Div，可做输出
        /// c为当前行绑定的实体，c.[属性名]即可取到其属性
        /// </summary>
        /// <returns></returns>
        public ColumnSettings Javascript(string content)
        {
            ColumnJavascript = content;
            return this;
        }
    }
}
