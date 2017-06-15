using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using showmethecard.Common;
using showmethecard.Dal;
using System;
using System.Data;

namespace showmethecard.Controllers
{
    public class AccountController : Controller
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        
        // POST: Account Login
        [HttpPost]
        public ActionResult Login()
        {
            conn = new MySqlConnection(@"Data Source=210.16.214.202;Database=rnh2;User Id=rnh2;Password=tjthsdbdlchl");
            conn.Open();

            String mId = Request["mId"];
            String password = Request["password"];
            password = Util.SHA256Hash(password);

            //select - ExecuteScalar
            //            cmd = new MySqlCommand();
            //            cmd.Connection = conn;
            //            cmd.CommandText = "SELECT count(*) FROM rnh2.MEMBER WHERE M_ID = " + mId + "AND PASSWORD = " + password + "AND DELETED = '0'" ;
            //            object result = cmd.ExecuteScalar();

            //            Console.WriteLine("records : "+result);

            //select - dataTable
            //            string sql = "SELECT M_ID mId, PASSWORD, M_NAME mName, EMAIL, PHONE, M_COUNT mCount, M_POINT mPoint, M_Level mLevel, USERTYPE, DELETED, REG_DATE regDate"
            //                       + "FROM rnh2.MEMBER"
            //                       + "WHERE M_ID = " + mId + "AND PASSWORD = " + password + "AND DELETED = '0'";
            //            DataSet ds = new DataSet();
            //            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //            da.Fill(ds, "member");

            //            DataTable dt = ds.Tables["member"];
            //            foreach(DataRow dr in dt.Rows)
            //            {
            //                Console.WriteLine(string.Format("mId={0}, password={1}, dr[mname], dr[mLevel]"));
            //            }

            //행의 개수 select
            cmd = new MySqlCommand();
            String sql = "SELECT Count(*) From rnh2.MEMBER";



            return RedirectToRoute(new { Controller = "Home", action = "About" });
            
        }
    }
}