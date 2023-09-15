using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userToUpdate"]==null)
        {
            Session["userToUpdate"] = 2;
        }

        if (!IsPostBack) // משיכת פרטי המשתמש מבסיס הנתונים
        {
            // התחברות למסד הנתונים
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
            string connectionString = Helper.conString;
            SqlConnection con = new SqlConnection(connectionString);
            
            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM tblUsers Where userid={(int)Session["userToUpdate"]}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);
            
            // יצירת DataSet
            DataSet ds = new DataSet();
            
            // טעינת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "users");
            DataRow dr = ds.Tables["users"].Rows[0];

            //  מילוי השדות בטופס
            //firstName.Value = ds.Tables["users"].Rows[0]["firstName"].ToString();
            firstName.Value = dr["firstName"].ToString();
            lastName.Value = dr["lastName"].ToString();
            userName.Value = dr["userName"].ToString();
            lastName.Value = dr["lastName"].ToString();
            password.Value = dr["password"].ToString();
            if (!dr.IsNull("birthday"))
            {
                date.Value = ((DateTime)(dr["birthday"])).ToString("yyy-MM-dd");
            }
                       
            city.Value = dr["city"].ToString();
            
        }

    }

    public void UpdateUser(object sender, EventArgs e)
    {
        
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM tblUsers Where userid={(int)Session["userToUpdate"]}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "users");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["users"].Rows[0];

        dr["firstName"] = firstName.Value;
        dr["lastName"] = lastName.Value;

        dr["userName"] = userName.Value;
        dr["password"] = password.Value;
        dr["birthday"] = DateTime.Parse(date.Value);
        dr["city"] = city.Value;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        //adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "users");

        Response.Redirect("http://localhost:59467/Pages/UsersTable2.aspx");
    }
}