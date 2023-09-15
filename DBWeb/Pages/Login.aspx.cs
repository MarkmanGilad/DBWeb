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
            string SQLStr = $"SELECT * FROM tblUsers " +
                $"WHERE userName='{Request.Form["userName"]}' AND password = '{Request.Form["password"]}'";
            DataSet ds = RetrieveUsersTable(SQLStr);

            if (ds.Tables["users"].Rows.Count > 0) 
            {
                Session["userName"] = Request.Form["userName"];
                Session["Login"] = true;
                Session["Admin"] = ds.Tables[0].Rows[0]["Admin"];
                message.InnerHtml = "";
                Response.Redirect("/Pages/Main.aspx");
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

    public DataSet RetrieveUsersTable(string SQLStr)
    {

        DataSet ds = new DataSet();
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = SQLStr;
        cmd.Connection = con;

        // טעינת הנתונים
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds,"users");
        con.Close();

        return ds;

        
    }
}