using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcAjaxToolkit.Flexigrid
{
    public class ColumnCollection<T> : ICollection<Column> where T : class
    {
        #region Private fields

        private readonly IList<Column> _columns = new List<Column>();

        #endregion

        #region Bind

        public ColumnSettings Bind(Expression<Func<T, object>> action, string title, int width, bool sortable)
        {
            return Bind(action).Title(title).Width(width).Sortable();
        }

        public ColumnSettings Bind(Expression<Func<T, object>> action, string title)
        {
            return Bind(action).Title(title);
        }

        public ColumnSettings Bind(Expression<Func<T, object>> action, string title, int width)
        {
            return Bind(action).Title(title).Width(width);
        }

        public ColumnSettings Bind(Expression<Func<T, object>> action)
        {
            var expression = action.Body.RemoveUnary() as MemberExpression;
            if (expression == null) throw new ArgumentException("非法的使用Bind方法，当前表达式不可解析");
            return Bind(expression.Member.Name);
        }

        //--
        public ColumnSettings Bind(string bindField, string title, int width, bool sortable)
        {
            return Bind(bindField).Title(title).Width(width).Sortable();
        }

        public ColumnSettings Bind(string bindField, string title)
        {
            return Bind(bindField).Title(title);
        }

        public ColumnSettings Bind(string bindField, string title, int width)
        {
            return Bind(bindField).Title(title).Width(width);
        }

        public ColumnSettings Bind(string bindField)
        {
            var column = new Column(bindField);
            _columns.Add(column);
            return column.ColumnSettings;
        }

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<Column> GetEnumerator()
        {
            return _columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<FlexiGridColumn<T>>

        public void Add(Column item)
        {
            _columns.Add(item);
        }

        public void Clear()
        {
            _columns.Clear();
        }

        public bool Contains(Column item)
        {
            return _columns.Contains(item);
        }

        public void CopyTo(Column[] array, int arrayIndex)
        {
            _columns.CopyTo(array, arrayIndex);
        }

        public bool Remove(Column item)
        {
            return _columns.Remove(item);
        }

        public int Count
        {
            get { return _columns.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
    }
}
