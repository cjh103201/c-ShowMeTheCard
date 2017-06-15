using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Security.Cryptography;
using showmethecard.Common;

namespace showmethecard.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection conn;
        SqlCommand cmd;
        

        // POST: Account Login
        [HttpPost]
        public ActionResult Login()
        {
            string connStr = "Server=210.16.214.202;Database=rnh2;Uid=rnh2;Pwd=tjthsdbdlchl";
            conn = new SqlConnection(connStr);
            conn.Open();
            String mId = Request["mId"];
            String password = Request["password"];

            password = Util.SHA256Hash(password);

            string sql = "SELECT M_ID mId, PASSWORD, M_NAME mName, EMAIL, PHONE, M_COUNT mCount, M_POINT mPoint, M_Level mLevel, USERTYPE, DELETED, REG_DATE regDate"
                           + "FROM rnh2.MEMBER"
                           + "WHERE M_ID = " + mId + "AND PASSWORD = " + password + "AND DELETED = '0'" ;

            cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr != null)
            {
                while (dr.Read())
                {
                    ViewBag.Message = dr["mName"];
                }
                dr.Close();

                return RedirectToRoute(new { Controller = "Home", action = "About" });

            } else
            {
                return RedirectToRoute(new { Controller = "Home", Action = "Index" });
            }

        }
    }
}