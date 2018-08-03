<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOrderDetails.aspx.cs" Inherits="ViewOrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 268px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    Select Company Name</td>
                <td>
                    <asp:DropDownList ID="ddCustomers" runat="server" AutoPostBack="True" 
                        DataSourceID="LinqSrcCustomers" DataTextField="CompanyName" 
                        DataValueField="CustomerID" Height="16px" Width="258px">
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LinqSrcCustomers" runat="server" 
                        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" 
                        Select="new (CustomerID, CompanyName)" TableName="Customers">
                    </asp:LinqDataSource>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="LinqSrcOrderDetails">
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="orderid" 
                SortExpression="orderid" />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" 
                SortExpression="OrderDate" />
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                SortExpression="CustomerID" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                SortExpression="CompanyName" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                SortExpression="ProductName" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                SortExpression="UnitPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="Amt" HeaderText="Amt" SortExpression="Amt" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqSrcOrderDetails" runat="server" 
        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" 
        TableName="OrderDetails" Where="CustomerID == @CustomerID">
        <WhereParameters>
            
            <asp:ControlParameter ControlID="ddCustomers" Name="CustomerID" 
                PropertyName="SelectedValue" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    </form>
</body>
</html>
