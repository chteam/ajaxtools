using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FlexigridMvcDemo.Models;

namespace FlexigridDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<DataRow> GetData()
        {
            var ad = new SqlDataAdapter("select top 20 * from UserInfo", DataConfig.ConnectionString);
            new SqlCommandBuilder(ad);
            var ds = new DataSet();
            ad.Fill(ds, "UserInfo");
            return ds.Tables[0].AsEnumerable();
        }
    }
}