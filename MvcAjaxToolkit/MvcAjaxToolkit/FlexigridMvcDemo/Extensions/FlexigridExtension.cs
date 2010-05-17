using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAjaxToolkit;
using System.Collections;
using System.Data;
using System.Linq.Expressions;
using MvcAjaxToolkit.Flexigrid.Models;

//using FlexigridMvcDemo.Extensions;

namespace FlexigridMvcDemo
{
    public static class FlexigridExtension
    {
        /// <summary>
        /// 生成Flexigrid所需的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static FlexgridData<T> ToFlexigridObject<T>(this PagedList<T> list, Expression<Func<T, object>> key, Action<FlexigridModelProperties<T>> properties) where T : class
        {
            var json = new FlexgridData<T>(
               list, list.CurrentPage,
               list.TotalCount,
               key, properties);
            return json;
        }
        /// <summary>
        /// 生成Flexigrid所需的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static FlexgridData<T> ToFlexigridObject<T>(this PagedList<T> list) where T : class
        {
            var json = new FlexgridData<T>(
               list, list.CurrentPage,
               list.TotalCount);
            return json;
        }
        //private static Expression RemoveUnary(Expression body)
        //{
        //    var uniary = body as UnaryExpression;
        //    if (uniary != null)
        //    {
        //        return uniary.Operand;
        //    }

        //    return body;
        //}

        /// <summary>
        /// 生成Flexigrid对象
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="total"></param>
        /// <param name="key"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static FlexgridData<DataRow> ToFlexigridObject(this IEnumerable<DataRow> rows, int page, int total, Expression<Func<DataRow, object>> key, Action<FlexigridModelProperties<DataRow>> properties)
        {
            var json = new FlexgridData<DataRow>(
                rows, page,
                total,
                key, properties);
            return json;
        }
    }
}