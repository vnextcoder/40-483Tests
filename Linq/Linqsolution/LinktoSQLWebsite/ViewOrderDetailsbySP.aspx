<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOrderDetailsbySP.aspx.cs" Inherits="ViewOrderDetailsbySP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <strong>Select Company Name:</strong></td>
                <td>
                    <asp:DropDownList ID="ddCustomers" runat="server" AppendDataBoundItems="True" 
                        AutoPostBack="True" DataSourceID="LinkSrcCustomers" DataTextField="CompanyName" 
                        DataValueField="CustomerID" 
                        onselectedindexchanged="ddCustomers_SelectedIndexChanged">
                        <asp:ListItem Value="">Select Company</asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LinkSrcCustomers" runat="server" 
                        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" 
                        Select="new (CustomerID, CompanyName)" TableName="Customers">
                    </asp:LinqDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvOrderDetails" runat="server" Height="82px" Width="641px">
                    </asp:GridView>
                </td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
