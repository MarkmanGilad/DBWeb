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
            // התחברות למסד הנתונים
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            // בניית פקודת SQL
            string SQL = BuildSQL();
            SqlCommand cmd = new SqlCommand(SQL, con);
                        
            // ביצוע השאילתא
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            // שימוש בנתונים שהתקבלו
            if (reader.HasRows)
            {
                reader.Read();
                Session["userName"] = reader.GetString(0);
                Session["Login"] = true;
                Session["Admin"] = reader.GetBoolean(1);
                message.InnerHtml = "Admin: " + Session["Admin"].ToString();
                //Response.Redirect("/Pages/Main.aspx");
            }
            else
            {
                Session["userName"] = "Visitor";
                Session["Login"] = false;
                Session["Admin"] = false;
                message.InnerHtml = "Unknown user name or password";
            }
            reader.Close();
            con.Close();
        }
    }

    public string BuildSQL ()
    {
        string SQL = $"SELECT firstName, admin FROM tblUsers " +
                $"WHERE userName='{Request.Form["userName"]}' AND password = '{Request.Form["password"]}'";
        return SQL;
    }

    public SqlDataReader GetDataReader(string SQL)
    {
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // עבודה עם ה Reader
        reader.Read();

        // סגירה
        reader.Close();
        con.Close();
        return reader;
    }


}