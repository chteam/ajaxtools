using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcHelper;
using FlexigridMvcDemo.Models;

namespace FlexigridMvcDemo{

    /// <summary>
    /// Summary description for Data
    /// </summary>
    public class Data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int page;
            int.TryParse(context.Request.Params["page"], out page);
            if (page == 0) page = 1;

            using (var t1 = new Models.TEST1Entities())
            {
                var list = t1.UserInfo.OrderBy(c => c.Id).Pager(page, 10);
                context.Response.Write(JsonAdapter.Serialize(list.ToFlexigridObject(c => c.Id,
                x =>
                {
                    x.Add(c => c.Id)
                    .Add(c => c.Email)
                    .Add(c => c.Name)
                    .Add(c => c.Age)
                    .Add(c => 1);
                })
                    ));
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}