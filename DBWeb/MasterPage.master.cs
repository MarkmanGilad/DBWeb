using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["Login"])
        {
            bar1.Style.Add("display", "none");
            //bar2.Style.Add("display", "none");
            
        }
        else
        {
            bar1.Style.Add("display", "block");
            //bar2.Style.Add("display", "block");

        }
    }

    
}
