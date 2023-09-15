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
            string SQLStr = "SELECT * FROM tblUsers";
            DataSet ds = RetrieveUsersTable(SQLStr);
            DataTable dt = ds.Tables["users"];
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

        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = SQLStr;
        //cmd.Connection = con;


        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        //con.Open();
        ad.Fill(ds, "users");
        //con.Close();

        return ds;
    }

    public string BuildUsersTable(DataTable dt)
    {
        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<th>" + column.ColumnName + "</th>";
        }
        str += "</tr>";

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName == "admin")
                {
                    if ((bool)row[column])
                    {
                        str += "<td>" + "Admin" + "</td>";
                    } else
                    {
                        str += "<td>" + "User" + "</td>";
                    }
                } else
                {
                    str += "<td>" + row[column] + "</td>";
                }
                
            }
            str += "</tr>";
        }

        str += "</Table>";
        return str;
    }

    public string BuildSQLStr(string str)
    {
        if (str.Length == 0)
        {
            return "SELECT * FROM tblUsers";
        }
        string SQLStr = $"SELECT * FROM tblUsers " +
            $"WHERE firstName LIKE '%{str}%' OR lastName LIKE '%{str}%' ";
        return SQLStr;
    }

    public void Click_Filter(object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Request.Form["filter"]);
        DataSet ds = RetrieveUsersTable(SQLStr);
        string table = BuildUsersTable(ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }

    
    
}

