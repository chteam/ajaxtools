using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcAjaxToolkit.Flexigrid.Models
{

    public class EntityPropertyContainer<T> where T : class
    {
        public EntityPropertyContainer()
        {
            ProperyValue = new List<Func<T, object>>();
            ProperyKey = new List<string>();
        }

        internal IList<Func<T, object>> ProperyValue { get; set; }
        internal IList<string> ProperyKey { get; set; }
        public EntityPropertyContainer<T> Add(Expression<Func<T, object>> value)
        {
            var m=(value.Body.RemoveUnary() as MemberExpression);
            if (m != null)
                ProperyKey.Add(m.Member.Name);
            ProperyValue.Add(value.Compile());
            return this;
        }
        public EntityPropertyContainer<T> Add(Expression<Func<T, object>> key,Expression<Func<T, object>> value)
        {
            var m = (key.Body.RemoveUnary() as MemberExpression);
            if (m != null)
                ProperyKey.Add(m.Member.Name);
            ProperyValue.Add(value.Compile());
            return this;
        }
        public EntityPropertyContainer<T> Add(string key,Expression<Func<T, object>> value)
        {
            ProperyKey.Add(key);
            ProperyValue.Add(value.Compile());
            return this;
        }
    }
}