using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //    DataSet ds = new DataSet();
            //    string constr = ConfigurationManager.ConnectionStrings["sqlsvr"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(constr))
            //    {
            //        string query = "SELECT * FROM NewCustomer";
            //        using (SqlCommand cmd = new SqlCommand(query))
            //        {
            //            cmd.Connection = con;
            //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //            {
            //                sda.Fill(ds);
            //            }
            //        }
            //    }

            //}
            return View();
        }
    }
}