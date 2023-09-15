using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Pages_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // בניית השורה להוספה
            User user = new User();

            user.firstName = Request.Form["firstName"];
            user.lastName = Request.Form["lastName"];
            user.userName = Request.Form["userName"];
            user.password = Request.Form["password"];
            user.birthday = DateTime.Parse(Request.Form["date"]);
            user.city = Request.Form["city"];

            // עדכון הדאטה סט בבסיס הנתונים
            Helper.Insert(user);
                        
            Response.Redirect("http://localhost:59467/Pages/Main.aspx");
        }
        


    }
}