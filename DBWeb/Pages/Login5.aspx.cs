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
            User user = Helper.GetRow(Request.Form["userName"], Request.Form["password"]);
            
            if (user.userName == "Visitor")
            {
                Session["Login"] = false;
                message.InnerHtml = "Unknown user name or password";
            }
            else
            {
                 Session["Login"] = true;
                 message.InnerHtml = "Admin: " + user.Admin;
                //Response.Redirect("/Pages/Main.aspx");
            }
            Session["userName"] = user.userName;
            Session["Admin"] = user.Admin;
        }

    }

    public static User GetRow(string userName, string password)
    // The Method check if there is a user with userName and Password. 
    // If true the Method return a user with the first Name and Admin property.
    // If not the Method return a user with first name "Visitor" and Admin = false

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(Helper.conString);

        // בניית פקודת SQL
        string SQL = $"SELECT userName, admin FROM " + Helper.tblName +
                $" WHERE userName='{userName}' AND password = '{password}'";
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.userName = reader.GetString(0);
            user.Admin = reader.GetBoolean(1);
            
        }
        else
        {
            user.userName = "Visitor";
            user.Admin = false;
        }
        reader.Close();
        con.Close();
        
        //while (reader.HasRows)
        //{
        //    reader.Read();
        //    user.userName = reader.GetValue(0).ToString();
        //    user.Admin = (bool)reader.GetValue(1);
        //    object obj = reader.GetValue(2);
        //    // Do something with Data
        //}
        return user;
    }

    




}