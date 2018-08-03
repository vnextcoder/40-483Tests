using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class ViewOrderDetailsbySP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        MSOPSClassesDataContext msops_dc = new MSOPSClassesDataContext();
        #region Invoking SP using ADO.NET
        //SqlConnection sqlcon = new SqlConnection(WebConfigurationManager.ConnectionStrings["MSOPSConnectionString"].ConnectionString);
        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = "USP_OrderDetails";
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Connection = sqlcon;
        //cmd.Parameters.AddWithValue("@CustomerID",  ddCustomers.SelectedValue.ToString());
        //sqlcon.Open();


        //gvOrderDetails.DataSource = cmd.ExecuteReader();
        //gvOrderDetails.DataBind();
        //sqlcon.Close();
        #endregion

        #region Invoking SP using LINQ to SQL API
        gvOrderDetails.DataSource = msops_dc.USP_OrderDetails(ddCustomers.SelectedValue);
        gvOrderDetails.DataBind();
        #endregion
    }
}