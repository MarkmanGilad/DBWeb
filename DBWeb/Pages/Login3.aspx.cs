using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string SQLStr = $"SELECT * FROM " + Helper.tblName +
                $" WHERE userName='{Request.Form["userName"]}' AND password = '{Request.Form["password"]}'";
            DataSet ds = Helper.RetrieveTable(SQLStr);
            if (ds.Tables[Helper.tblName].Rows.Count > 0) 
            {
                Session["userName"] = Request.Form["userName"];
                Session["Login"] = true;
                Session["Admin"] = ds.Tables[0].Rows[0]["Admin"];
                message.InnerHtml = "";
                Response.Redirect("/Pages/Main.aspx");
            }
            else
            {
                Session["userName"] = "Visitor";
                Session["Login"] = false;
                Session["Admin"] = false;
                message.InnerHtml = "Unknown user name or password";
            }
        }
    }
}