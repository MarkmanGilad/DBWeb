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

            // התחברות למסד הנתונים
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM tblUsers WHERE userName='{Request.Form["userName"]}'";
            //string SQLStr = $"SELECT * FROM tblUsers WHERE 0=1";
            SqlCommand cmd = new SqlCommand(SQLStr, con);
            

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            
            //adapter.UpdateCommand = builder.GetInsertCommand();
            adapter.Fill(ds, "users");

            if (ds.Tables["users"].Rows.Count > 0)
            {
                msgBox.InnerHtml = "The userName is taken";
                return;
            }

            {
                // בניית השורה להוספה
                DataRow dr = ds.Tables["users"].NewRow();

                dr["firstName"] = Request.Form["firstName"];
                dr["lastName"] = Request.Form["lastName"];
                dr["userName"] = Request.Form["userName"];
                dr["password"] = Request.Form["password"];
                dr["birthday"] = Request.Form["date"];
                dr["city"] = Request.Form["city"];
                
                ds.Tables["users"].Rows.Add(dr);

                // עדכון הדאטה סט בבסיס הנתונים
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetInsertCommand();
                adapter.Update(ds, "users");

                Response.Redirect("http://localhost:59467/Pages/Main.aspx");
            }


        }

        //if (IsPostBack)
        //{
        //    User myUser = new User();

        //    myUser.userName = Request.Form["username"];
        //    myUser.password = Request.Form["pass"];
        //    myUser.firstName = Request.Form["firstName"];
        //    myUser.lastName = Request.Form["lastname"];

        //    Helper.Insert(myUser);

        //}
        //if (ds.Tables["users"].Rows.Count > 0)
        //{
        //    msgBox.InnerHtml = "Error userName allready exists";
        //} else


       // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True"
    }
}