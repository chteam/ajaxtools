using System.Web.Mvc;
using MvcAjaxToolkit.Flexigrid;

namespace FlexigridMvcDemo
{
    public static class HtmlExtensions
    {
        public static TableSettings<T> Flexigrid<T>(this HtmlHelper helper) where T : class
        {
            return new TableSettings<T>();
        }

        public static FlexigridSettings Flexigrid(this HtmlHelper helper)
        {
            return new FlexigridSettings();
        }
    }
}
