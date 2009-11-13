using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
namespace MvcAjax {
    public static class DateBindExt {
        public static void DateBindRender(this HtmlHelper Html, DateBindOption dbo) {
            Html.RenderPartial("MvcAjax/DateBind", dbo);
        }
    }
    public class DateBindOption
    {
        public string ID { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
    }

}
