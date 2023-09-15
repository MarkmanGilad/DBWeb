using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_RadioButton1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Click_Radio(object sender, EventArgs e)
    {
        div1.InnerHtml = Request.Form["ctl00$ContentPlaceHolder1$order"];
        div2.InnerHtml = ASC.Value + " " + DESC.Value;

        div3.InnerHtml = ASC.Checked.ToString() + " " + DESC.Checked.ToString();
        if (ASC.Checked)
        {
            ASC.Checked = false;
            DESC.Checked = true;
        }
        else
        {
            ASC.Checked = true;
            DESC.Checked = false;
        }


    }
}