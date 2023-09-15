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
            Response.Redirect("http://localhost:59467/Pages/Main.aspx");
        }

        if (!IsPostBack)
        {
            string SQLStr = "SELECT * FROM tblUsers";
            DataSet ds = RetrieveUsersTable(SQLStr);
            DataTable dt = ds.Tables[0];
            string table = BuildUsersTable(dt);
            tableDiv.InnerHtml = table;
            
        }
        
    }

    public DataSet RetrieveUsersTable(string SQLStr)
    {
        // connect to DataBase
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);
        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        // Build DataSet to store the data
        DataSet ds = new DataSet();
        // Get Data form DataBase into the DataSet
        ad.Fill(ds, "users");
        return ds;
    }

    public string BuildUsersTable (DataTable dt)
    {
        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public string BuildSQLStr (string column, string order)
    {
        string SQLStr = $"SELECT * FROM tblUsers " +
            $"ORDER BY {column} {order}"; 
        return SQLStr;
    }

    public void Click_Sort (object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Columns.Value, Request.Form["order"]);
        DataSet ds = RetrieveUsersTable(SQLStr);
        string table = BuildUsersTable(ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }
    
}