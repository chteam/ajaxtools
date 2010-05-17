using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MvcHelper
{
    public class FlexgridData<T> where T : class
    {
        #region Private fields

        private readonly IEnumerable<T> _data;

        private readonly int _page;

        private readonly int _total;

        private IList<FlexgridRowData> _rows;

        #endregion

        #region Constructor
        /// <summary>
        /// 生成Flexigrid可用的数据
        /// </summary>
        /// <param name="data">要转换的数据</param>
        /// <param name="page">当前页面</param>
        /// <param name="total">总条数</param>
        /// <param name="identifier">主键</param>
        /// <param name="properties">要添加的属性</param>
        public FlexgridData(IEnumerable<T> data, int page, int total, Expression<Func<T, object>> identifier, Action<FlexigridModelProperties<T>> properties)
            : this(data, page, total, false)
        {
            _rows = new List<FlexgridRowData>();
            // 运行主键委托
            var identityDelegate = identifier.Compile();
            // 获取属性集
            var dataCollection = new FlexigridModelProperties<T>();
            properties.Invoke(dataCollection);
            foreach (var item in data)
            {
                var item1 = item;
                IList<string> rowData = dataCollection.ProperyItem.Select(properyItem => properyItem(item1).ToString()).ToList();
                // 创建DataList
                _rows.Add(new FlexgridRowData(identityDelegate(item).ToString(), rowData));
            }
        }

        public FlexgridData(IEnumerable<T> data, int page, int total)
            : this(data, page, total, true)
        {
        }

        protected FlexgridData(IEnumerable<T> data, int page, int total, bool initializeRows)
        {
            _data = data;
            _page = page;
            _total = total;

            if (!initializeRows) return;
            _rows = new List<FlexgridRowData>();

            var propertyInfos = typeof(T).GetProperties();

            foreach (var item in data)
            {
                var id = string.Empty;
                IList<string> cells = new List<string>();

                foreach (var info in propertyInfos)
                {
                    cells.Add(info.GetValue(item, null).ToString());
                    if (id.Length == 0)
                    {
                        id = cells[0];
                    }
                }

                _rows.Add(new FlexgridRowData(id, cells));
            }
        }

        #endregion

        public int page
        {
            get
            {
                return this._page;
            }
        }

        public int total
        {
            get
            { 
                return this._total;
            }
        }

        public IList<FlexgridRowData> rows
        {
            get
            {
                return this._rows;
            }
        }
    }
}