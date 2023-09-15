using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string SQL = $"SELECT admin FROM tblUsers " +
                $"WHERE userName='{Request.Form["userName"]}' AND password = '{Request.Form["password"]}'";

            object scalar = GetScalar(SQL); // מחזיר רק את הערך של Admin

            if (scalar != null)
            {
                Session["userName"] = Request.Form["userName"];
                Session["Login"] = true;
                Session["Admin"] = (bool)scalar;
                message.InnerHtml = "Admin: " + Session["Admin"].ToString();
            }
            else
            {
                Session["userName"] = "Visitor";
                Session["Login"] = false;
                Session["Admin"] = false;
                message.InnerHtml = "Unknown user name or password";
            }
        }
    }

    public object GetScalar(string SQL)
    {
         // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }


}