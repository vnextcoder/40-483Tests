﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MSOPSModel.MSOPSEntities ops = new MSOPSModel.MSOPSEntities();
        gvOrders.DataSource = ops.Orders;
        gvOrders.DataBind();
    }
}