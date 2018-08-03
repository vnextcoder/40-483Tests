<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderForm.aspx.cs" Inherits="OrderForm" %>

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
                    Order Date:</td>
                <td>
                    <asp:TextBox ID="txtODate" runat="server"></asp:TextBox>
                    <asp:Button ID="btnODateShow" runat="server" onclick="btnODateShow_Click" 
                        Text="Show" />
                </td>
                <td>
                    <asp:Calendar ID="ODateCalendar1" runat="server" 
                        onselectionchanged="ODateCalendar1_SelectionChanged" Visible="False">
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    Shipping Date:</td>
                <td>
                    <asp:TextBox ID="txtSDate" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSDateShow" runat="server" onclick="btnSDateShow_Click" 
                        Text="Show" />
                </td>
                <td>
                    <asp:Calendar ID="SDateCalendar2" runat="server" 
                        onselectionchanged="SDateCalendar2_SelectionChanged" Visible="False">
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    Product ID:</td>
                <td>
                    <asp:DropDownList ID="ddlProductID" runat="server" 
                        DataSourceID="LinkSrcProducts" DataTextField="ProductName" 
                        DataValueField="ProductID">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LinkSrcProducts" runat="server" 
                        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" 
                        Select="new (ProductID, ProductName)" TableName="Products">
                    </asp:LinqDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Customer ID:</td>
                <td>
                    <asp:DropDownList ID="ddlCustomerID" runat="server" 
                        DataSourceID="LinksrcCustomers" DataTextField="CompanyName" 
                        DataValueField="CustomerID">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LinksrcCustomers" runat="server" 
                        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" 
                        Select="new (CustomerID, CompanyName)" TableName="Customers">
                    </asp:LinqDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Quantity</td>
                <td>
                    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnPlaceOrder" runat="server" onclick="btnPlaceOrder_Click" 
                        Text="Place Order" />
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
                        Text="Reset" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
