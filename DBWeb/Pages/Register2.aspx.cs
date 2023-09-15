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
            // בדיקה אם קיים שם משתמש
            string SQL = $"SELECT COUNT (admin) FROM tblUsers " +
                $"WHERE userName='{Request.Form["userName"]}'";

            int count = (int) GetScalar(SQL);
            if (count > 0)
            {
                userNameAlert.InnerHtml = "User Name is taken";
            }
            else
            {       // בניית השורה להוספה
                SQL = $"INSERT INTO tblUsers (firstName, lastName, userName, password, birthday, city) " +
                    $"VALUES ('{Request.Form["firstName"]}','{Request.Form["lastName"]}'," +
                    $"'{Request.Form["userName"]}','{Request.Form["password"]}'," +
                    $"'{Request.Form["date"]}', '{Request.Form["city"]}');";
                ExecuteNonQuery(SQL);
                Response.Redirect("/Pages/Main.aspx");
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

    public int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        return n;
    }

}