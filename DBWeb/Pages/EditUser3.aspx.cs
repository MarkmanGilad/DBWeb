using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_EditUser3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataRow dr = (DataRow)Session["userToUpdate"];

            //  מילוי השדות בטופס
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
        DataRow row = (DataRow)Session["userToUpdate"];
        int userId = (int)row["userId"];
        string SQLStr = $"SELECT * FROM tblUsers Where userid={userId}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "users");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["users"].Rows[0];
        ds.Tables["users"].Rows[0]["firstName"] = firstName.Value;
        ds.Tables["users"].Rows[0]["lastName"] = lastName.Value;
        dr["userName"] = userName.Value;
        dr["password"] = password.Value;
        dr["birthday"] = DateTime.Parse(date.Value);
        dr["city"] = city.Value;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "users");

        Response.Redirect("http://localhost:59467/Pages/DeleteUpdate.aspx");
    }
}