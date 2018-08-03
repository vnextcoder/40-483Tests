using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class def2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            
            TextBox1.Text +=("text 1 is " + Request.Form["Text1"]);
            TextBox1.Text +=("text 2 is " + Request.Form["Text2"]);
            TextBox1.Text +=("text 3 is " + Request.Form["Text3"]);
            TextBox1.Text +=((Convert.ToInt32(Request.Form["Text1"]) + Convert.ToInt32(Request.Form["Text2"]) + Convert.ToInt32(Request.Form["Text3"])));
        }
    }
}