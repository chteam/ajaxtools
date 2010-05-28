using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using FlexigridMvcDemo.Models;
using MvcAjaxToolkit;
using MvcAjaxToolkit.Pager;

namespace FlexigridMvcDemo.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/


        public ActionResult Index(int? page, int? rp, string sortname, string sortorder)
        {
            var sql = "select * from UserInfo";
            if (!string.IsNullOrEmpty(sortname))
                sql += string.Format(" order by {0} {1}", sortname, sortorder);
            var ad = new SqlDataAdapter(sql, DataConfig.ConnectionString);
            new SqlCommandBuilder(ad);
            var ds = new DataSet();
            ad.Fill(ds, "UserInfo");
            var pager = ds.Tables[0].AsEnumerable().Pager(page ?? 1, rp ?? 20);

            var json = pager.ToList().ToFlexigridObject(page ?? 1, pager.TotalCount,

                c => c["id"], x => x.Add("id", t => t["id"])
                    .Add("email", c => c["email"])                    
                    .Add("name", c => c["name"])
                    .Add("age", c => c["age"]));
            return Json(json,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEntity(int? page, int? rp, string sortname, string sortorder)
        {
            PagedList<UserInfo> json;
            using (var t1 = new TEST1Entities())
            {
                var list1 = t1.UserInfo.OrderBy(c => c.Id);
                //var t = (list1 as ObjectQuery).ToTraceString();
                var list = list1.Pager(page ?? 1, rp ?? 10);
                //    var t = new PagedList<object[]>(list.Select(), page??1, 10, list.TotalCount);
                json = list;
                //.ToFlexigridObject(c => new object[] { c.Id, c.Name.Substring(1), c.Email, c.Age });
            }
            var data = json.ToFlexigridObject(c => c.Id, 
                x => x.Add(c => c.Id)
                         .Add(c => c.Email)
                         .Add(c => c.Name)
                         .Add(c => c.Age)
                         .Add(c => 1));
            return Json(data);
        }
        public ActionResult Remove(int id)
        {
            using (var t1 = new TEST1Entities())
            {
                var x = t1.UserInfo.FirstOrDefault(c => c.Id == id);
                if(x!=null)
                {
                    t1.UserInfo.Remove(x);
                }
            }
            return Content("");
        }
        public ActionResult Add()
        {
            using (var t1 = new TEST1Entities())
            {
                var id = t1.UserInfo.Max(c => c.Id);
                t1.UserInfo.Add(new UserInfo
                                    {
                                        Id = id + 1,
                                        Age = 23,
                                        Email = Guid.NewGuid().ToString(),
                                        Name = Guid.NewGuid().ToString()
                                    });
            }
            return Content("");
        }
    }
}
