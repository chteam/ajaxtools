using System;
using System.ComponentModel;
using MvcAjaxToolkit.Interface;
using MvcAjaxToolkit;

namespace MvcAjaxToolkit.Flexigrid
{
    public class TableSettings<T> where T : class
    {
        #region Private Fields

        private readonly IGridRender<TableSettings<T>> _renderer;

        #endregion

        #region Constructor

        public TableSettings()
        {
            MenuProcess = null;
            MenuId = null;
            EnableTableToggleButton = false;
            GridColumns = new ColumnCollection<T>();
            _renderer = new FlexigridRender<T>();
        }

        #endregion
        //EntityModelCodeGenerator
        #region Public Properties
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GridHeight { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GridWidth { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SortOrderType DefaultSortOrder { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DefaultSortField { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PageFilter { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableDefaultPager { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableTableToggleButton { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PageSize { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GridTitle { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataType GridDataType { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ActionUrl { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GridId { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableAutoLoad { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColumnCollection<T> GridColumns { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 设置要生成Table的Id
        /// </summary>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public TableSettings<T> TableId(string elementId)
        {
            GridId = elementId;
            return this;
        }

        /// <summary>
        /// Flexigrid调用的数据源页面
        /// </summary>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        public TableSettings<T> Action(string actionUrl)
        {
            ActionUrl = actionUrl;
            return this;
        }

        /// <summary>
        /// 传递数据的类型 Xml 或 Json，默认为Json
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public TableSettings<T> DataType(DataType dataType)
        {
            GridDataType = dataType;
            return this;
        }

        /// <summary>
        /// 设置FlexiGrid标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public TableSettings<T> Title(string title)
        {
            GridTitle = title;
            return this;
        }

        /// <summary>
        /// 允许自动加载
        /// </summary>
        /// <returns></returns>
        public TableSettings<T> AutoLoad()
        {
            EnableAutoLoad = true;
            return this;
        }

        /// <summary>
        /// 设置每页容纳条数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableSettings<T> SetPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }


        //public FlexiGridSettings<T> ShowTableToggleButton(bool show)
        //{
        //    this._enableTableToggleButton = show;
        //    return this;
        //}
        /// <summary>
        /// 设置为默认分页
        /// </summary>
        /// <returns></returns>
        public TableSettings<T> SetPager()
        {
            EnableDefaultPager = true;
            return this;
        }

        /// <summary>
        /// 设置可分页并设定指定的分页元素
        /// </summary>
        /// <param name="pagerFilter">分页Div的Class或Id，支持.class或#Id</param>
        /// <returns></returns>
        public TableSettings<T> SetPager(string pagerFilter)
        {
            EnableDefaultPager = false;
            PageFilter = pagerFilter;
            return this;
        }

        /// <summary>
        /// 默认排序的字段名，及排序方式
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public TableSettings<T> DefaultSortOption(string fieldName, SortOrderType order)
        {
            DefaultSortField = fieldName;
            DefaultSortOrder = order;
            return this;
        }


        /// <summary>
        /// 设置表格的列
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public TableSettings<T> Columns(Action<ColumnCollection<T>> action)
        {
            action(GridColumns);
            return this;
        }

        /// <summary>
        /// 设置表格宽度
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public TableSettings<T> Width(int width)
        {
            GridWidth = width;
            return this;
        }

        /// <summary>
        /// 设置表格高度
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public TableSettings<T> Height(int height)
        {
            GridHeight = height;
            return this;
        }

        public override string ToString()
        {
            return _renderer.Render(this);
        }

        #endregion

        /// <summary>
        /// 设置可移动列
        /// </summary>
        public bool ColMove { get; private set; }

        /// <summary>
        /// 设置可移动列
        /// </summary>
        public TableSettings<T> ColumnsMove()
        {
            ColMove = true;
            return this;
        }

        /// <summary>
        /// 设置列可自定义大小 
        /// </summary>
        public bool ColResize { get; private set; }


        /// <summary>
        /// 设置列可自定义大小 
        /// </summary>
        /// <returns></returns>
        public TableSettings<T> ColumnsResize()
        {
            ColResize = true;
            return this;
        }

        public string MenuId { get; private set; }
        public string MenuProcess { get; private set; }

        /// <summary>
        /// 设置右键菜单 
        /// </summary>
        /// <param name="menuId">菜单</param>
        /// <param name="process">菜单 处理的JS</param>
        /// <returns></returns>
        public TableSettings<T> ContextMenu(string menuId, string process)
        {
            MenuId = menuId;
            MenuProcess = process;
            return this;
        }
    }
}