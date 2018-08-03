using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class RegionPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ClearText()
    {
        txtRegionDesc.Text = "";
        txtRegionID.Text = "";
        txtRegionID.Focus();
        GridView1.DataBind();
    
    }
    protected void btnAddRegion_Click(object sender, EventArgs e)
    {
        try 
	    {	        
		    MSOPSClassesDataContext msops_dc = new MSOPSClassesDataContext();
            Table<Region> tblRegions = msops_dc.GetTable<Region>();
            Region newRegion= new Region {RegionID=txtRegionID.Text, RegionDesc=txtRegionDesc.Text};
            tblRegions.InsertOnSubmit(newRegion);
            msops_dc.SubmitChanges();
            lblMessage.Text="Region Created";
            ClearText();
        
	    }
	    catch (Exception exp)
    	{
		
	    	lblMessage.Text="Error : " + exp.Message;
	    }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
           
    }
    protected void btnModifyRegion_Click(object sender, EventArgs e)
    {
        try
        {
            MSOPSClassesDataContext msops_dc = new MSOPSClassesDataContext();
            Region ModRegion = msops_dc.GetTable<Region>().Single(r => r.RegionID == txtRegionID.Text);
            ModRegion.RegionID = txtRegionID.Text;
            ModRegion.RegionDesc = txtRegionDesc.Text;
            msops_dc.SubmitChanges();
            lblMessage.Text = "Region Modified";
            ClearText();

        }
        catch (Exception exp)
        {

            lblMessage.Text = "Error : " + exp.Message;
        }
    }
}