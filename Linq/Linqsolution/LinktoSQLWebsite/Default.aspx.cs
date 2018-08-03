using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MSOPSClassesDataContext dc = new MSOPSClassesDataContext();
        GridView1.DataSource = dc.GetTable<Customer>();
        GridView1.DataBind();

        
    }
}