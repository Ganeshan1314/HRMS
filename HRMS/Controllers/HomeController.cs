using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnetion"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Login1(string username,string password)
        {
            con.Open();
            //string sql = "select * from [user] where [username]='" + txtusername.Text + "' and [password]='" + txtpassword.Text + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_Verify_user";
            cmd.Parameters.AddWithValue("@Username", username.Trim());
            cmd.Parameters.AddWithValue("@Password", password.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 1)
            {
                return Json("Successfully Logged in");
            }
            else
            {
                return Json("Invalid Username or Password", JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult Register_Save_Click()
        {
            return Json("Data Inserted Successfully",JsonRequestBehavior.AllowGet);
        }
    }
}