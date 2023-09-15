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
            DataTable dt = ds.Tables[0];
            string table = Helper.BuildSimpleUsersTable(dt);
            tableDiv.InnerHtml = table;
         }
     }

    public string BuildSQLStr (string column, string order)
    {
        string SQLStr = $"SELECT * FROM " + Helper.tblName + 
            $" ORDER BY {column} {order}"; 
        return SQLStr;
    }

    public void Click_Sort (object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Columns.Value, Request.Form["order"]);
        DataSet ds = Helper.RetrieveTable(SQLStr);
        string table = Helper.BuildSimpleUsersTable(ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }
    
}