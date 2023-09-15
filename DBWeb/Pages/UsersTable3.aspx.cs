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
            DataTable dt = ds.Tables[0];

            //dt = SortTable(dt, "firstName", "ASC");

            string table = BuildUsersTable(dt);
            tableDiv.InnerHtml = table;

        }

    }

    public DataSet RetrieveUsersTable(string SQLStr)
    {
        DataSet ds = new DataSet();
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = SQLStr;
        cmd.Connection = con;

        // טעינת הנתונים
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Close();

        return ds;
    }

    public string BuildUsersTable(DataTable dt)
    {

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
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

    public DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();

    }

    public DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }

    public void Click_Filter1(object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Request.Form["filter"]);
        DataSet ds = RetrieveUsersTable(SQLStr);
        string table = BuildUsersTable(ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }

    public void Sort(object sender, EventArgs e)
    {
        Click_Filter1(sender, e);
    }

    public void Delete(object sender, EventArgs e)
    {
        // התחברות למסד הנתונים
        string connectionString = Helper.conString;
        SqlConnection con = new SqlConnection(connectionString);

        // טעינת הנתונים
        string SQLStr = "SELECT * FROM tblUsers";
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "tblUsers");

        // מחיקת שורות שנבחרו מתוך הדאטה סט
        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                int userId = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                DataRow[] dr = ds.Tables["tblUsers"].Select($"userId = {userId}");
                dr[0].Delete();
            }

        }

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, "tblUsers");

        // הדפסת הטבלה המעודכנת
        string table = BuildUsersTable(ds.Tables["tblUsers"]);
        tableDiv.InnerHtml = table;
    }

    public void Edit(object sender, EventArgs e)
    {
        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                Session["userToUpdate"] = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                Response.Redirect("http://localhost:59467/Pages/EditUser.aspx");

            }

        }
        message.InnerHtml = "No user was Selected";
    }

    public void Add(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:59467/Pages/Register.aspx");
    }

    public string CreateRadioBtn(string id)
    {
        return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
        //RadioButton btn = new RadioButton();
        //btn.Text = "";
        //btn.ID = id;
        //btn.Checked = false;
        //btn.GroupName = "RadioBtns";
        //return btn;
        //message.Controls.Add(btn);
        //'{char.ConvertFromUtf32(0x2193)}'
    }

    public int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        return n;
    }

    public void ChangeToAdmin(object sender, EventArgs e)
    {
        ChangeAdmin("Admin", "True");
    }

    public void ChangeToUser(object sender, EventArgs e)
    {
        ChangeAdmin("Admin", "False");
    }

    public void ChangeAdmin(string column, string Value)
    {
        int counter = 0;
        // בניית שאילתא
        string SQL = $"UPDATE tblUsers " +
            $"SET {column} = '{Value}' " +
            $"WHERE ";
        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                if (counter > 0)
                    SQL += "OR ";
                int userId = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                SQL += $" userId = {userId} ";
                counter++;
            }
        }
        if (counter == 0)
        {
            message.InnerHtml = "You must select Row";
            return;
        }
        // עדכון בסיס הנתונים
        message.InnerHtml = ExecuteNonQuery(SQL).ToString();

        // הדפסת הטבלה מחדש
        string SQLStr = "SELECT * FROM tblUsers";
        DataSet ds = RetrieveUsersTable(SQLStr);
        DataTable dt = ds.Tables[0];
        string table = BuildUsersTable(dt);
        tableDiv.InnerHtml = table;
    }




}