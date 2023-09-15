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
            
            // בניית פקודת SQL
            string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userid={(int)Session["userToUpdate"]}";

            // טעינת הנתונים
            DataSet ds = Helper.RetrieveTable(SQLStr);
            DataRow dr = ds.Tables[Helper.tblName].Rows[0];

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

        // בניית פקודת SQL

        // בניית המשתמש להוספה
        User user = new User();
        user.firstName = firstName.Value;
        user.lastName = lastName.Value;
        user.userName = userName.Value;
        user.password = password.Value;
        user.birthday = DateTime.Parse(date.Value);
        user.city = city.Value;

        // עדכון הדאטה סט בבסיס הנתונים
        Helper.Update(user);

        Response.Redirect("http://localhost:59467/Pages/UsersTable2.aspx");
    }
}