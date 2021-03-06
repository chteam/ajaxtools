﻿using System.Web.Mvc;
using MvcAjaxToolkit.Flexigrid;

namespace FlexigridMvcDemo
{
    public static class HtmlExtensions
    {
        public static TableSettings<T> Flexigrid<T>(this HtmlHelper helper) where T : class
        {
            return new TableSettings<T>();
        }

        public static TableSettings Flexigrid(this HtmlHelper helper,string id)
        {
            return new TableSettings(id);
        }
    }
}
