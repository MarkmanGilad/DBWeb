using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_DeleteUpdate : System.Web.UI.Page
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
            //DataSet ds = RetrieveUsersTable(SQLStr);
            Session["ds"] = RetrieveUsersTable(SQLStr);
            DataTable dt = ((DataSet)Session["ds"]).Tables["users"];
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
                str += "<td>" + row[column] + "</td>";
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
        //string SQLStr = $"SELECT * FROM tblUsers WHERE firstName='{str}'";
        //string SQLStr = $"SELECT * FROM tblUsers WHERE firstName LIKE '%{str}%'";
        string SQLStr = $"SELECT * FROM tblUsers WHERE" +
            $" firstName LIKE '%{str}%' OR" +
            $" lastName LIKE '%{str}%' ";
        return SQLStr;
    }

    public void Click_Filter(object sender, EventArgs e)
    {
        string expression;
        if (filter.Value == "")
        {
            expression = null;
        } else
        {
            expression = $"firstName = '{filter.Value}' OR lastName = '{filter.Value}'";
        }

        DataSet ds = (DataSet)Session["ds"];
        DataTable dt = ds.Tables["users"];
        DataRow [] dr = dt.Select(expression);
        dt = dr.CopyToDataTable();
        string table = BuildUsersTable(dt);
        tableDiv.InnerHtml = table;
    }

    public void Delete(object sender, EventArgs e)
    {
        if (delete.Value == "")
            return;
        // update DataSet
        int userId = int.Parse(delete.Value);
        //string expression = $"userId = {userId}";
        DataSet ds = (DataSet)Session["ds"];
        DataTable dt = ds.Tables["users"];
        DataRow[] dr = dt.Select($"userId = {userId}");
        if (dr.Length > 0)
        {
            dr[0].Delete();
        }
        else
        {
            msg.InnerHtml = "Id is not valid";
            return;
        }
        

        // Update DataBase with the updated dataSet
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);
        string SQLStr = "SELECT * FROM tblUsers";
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        SqlCommandBuilder builder = new SqlCommandBuilder(ad);
        //ad.UpdateCommand = builder.GetDeleteCommand();
        ad.Update(ds, "users");

        // הדפסת הטבלה המעודכנת
        string table = BuildUsersTable(dt);
        tableDiv.InnerHtml = table;
    }

    public void Edit(object sender, EventArgs e)
    {
        if (edit.Value == "")
            return;
        // update DataSet
        int userId = int.Parse(edit.Value);
        string expression = $"userId = {userId}";
        DataSet ds = (DataSet)Session["ds"];
        DataTable dt = ds.Tables["users"];
        DataRow[] dr = dt.Select(expression);
        DataRow row = dr[0];
        Session["userToUpdate"] = row;
        Response.Redirect("http://localhost:59467/Pages/EditUser3.aspx");
    }

    public void Add(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:59467/Pages/Register.aspx");
    }

    public void ChangeAdmin(object sender, EventArgs e)
    {
        if (change.Value == "")
            return;
        // update DataSet
        int userId = int.Parse(change.Value);
        string expression = $"userId = {userId}";
        DataSet ds = (DataSet)Session["ds"];
        DataTable dt = ds.Tables["users"];
        DataRow[] dr = dt.Select(expression);
        DataRow row = dr[0];
        if ((bool)row["admin"])
        {
            row["admin"] = false;
        } else
        {
            row["admin"] = true;
        }

        // Update DataBase with the updated dataSet
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);
        string SQLStr = "SELECT * FROM tblUsers";
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        SqlCommandBuilder builder = new SqlCommandBuilder(ad);
        //ad.UpdateCommand = builder.GetUpdateCommand();
        ad.Update(ds, "users");

        // הדפסת הטבלה המעודכנת
        string table = BuildUsersTable(dt);
        tableDiv.InnerHtml = table;
    }
}