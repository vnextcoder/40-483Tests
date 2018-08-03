using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnODateShow_Click(object sender, EventArgs e)
    {
        ODateCalendar1.Visible = true;
    }
    protected void ODateCalendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtODate.Text = ODateCalendar1.SelectedDate.ToShortDateString();
        ODateCalendar1.Visible = false;
    }
    protected void SDateCalendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtSDate.Text = SDateCalendar2.SelectedDate.ToShortDateString();
        SDateCalendar2.Visible = false;
    }
    protected void btnSDateShow_Click(object sender, EventArgs e)
    {
        SDateCalendar2.Visible = true;
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        TextBox a = (TextBox)source;
       
        args.IsValid = false;

    }
    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        try
        {
            MSOPSClassesDataContext msops_dc = new MSOPSClassesDataContext();
            string message = null;
            msops_dc.USP_PlaceOrder(Convert.ToDateTime(txtODate.Text), Convert.ToDateTime( txtSDate.Text),
                    ddlProductID.SelectedValue, ddlCustomerID.SelectedValue, Convert.ToInt32( txtQty.Text), ref message);
            lblMessage.Text=message;
        
        }
        catch (Exception ex)
        {
            
            lblMessage.Text="Error : " + ex.Message;
        }
    }
    private void ClearText()
    {
        txtODate.Text = "";
        txtSDate.Text = "";
        txtQty.Text = "";

        ODateCalendar1.Visible = false;
        SDateCalendar2.Visible = false;
        
        ddlCustomerID.ClearSelection();
        ddlProductID.ClearSelection();

        txtODate.Focus();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearText();
    }
}