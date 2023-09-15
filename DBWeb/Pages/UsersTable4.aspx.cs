using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_UsersTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["Admin"])
        {
            //Response.Redirect("http://localhost:59467/Pages/Main.aspx");
        }

        if (!IsPostBack)
        {
            string SQLStr = "SELECT * FROM " + Helper.tblName;
            DataSet ds = Helper.RetrieveTable(SQLStr);
            DataTable dt = ds.Tables[Helper.tblName];
            string table = Helper.BuildSimpleUsersTable(dt);
            tableDiv.InnerHtml = table;
        }
        
    }

    public string BuildSQLStr (string str)
    {
        if (str.Length==0)
        {
            return "SELECT * FROM tblUsers";
        }
        string SQLStr = $"SELECT * FROM tblUsers " +
            $"WHERE firstName LIKE '%{str}%' OR lastName LIKE '%{str}%' ";
        return SQLStr;
    }

    public void Click_Filter (object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Request.Form["filter"]);
        DataSet ds = Helper.RetrieveTable(SQLStr);
        string table = Helper.BuildUsersTable(ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }
    
}