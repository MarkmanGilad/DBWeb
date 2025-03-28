﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // בדיקה אם קיים שם משתמש
            string SQL = $"SELECT COUNT (admin) FROM " + Helper.tblName +
                $" WHERE userName='{Request.Form["userName"]}'";

            int count = (int) Helper.GetScalar(SQL);
            if (count > 0)
            {
                userNameAlert.InnerHtml = "User Name is taken";
            }
            else
            {       // בניית השורה להוספה
                SQL = $"INSERT INTO tblUsers (firstName) " +
                    $"VALUES ('{Request.Form["firstName"]}','{Request.Form["lastName"]}'," +
                    $"'{Request.Form["userName"]}','{Request.Form["password"]}'," +
                    $"'{Request.Form["date"]}', '{Request.Form["city"]}');";
                Helper.ExecuteNonQuery(SQL);
                Response.Redirect("http://localhost:59467/Pages/Main.aspx");
            }
        }
    }
}