<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegionPage.aspx.cs" Inherits="RegionPage" %>

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
                    Region ID:</td>
                <td>
                    <asp:TextBox ID="txtRegionID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description:</td>
                <td>
                    <asp:TextBox ID="txtRegionDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnAddRegion" runat="server" Font-Bold="True" 
                        onclick="btnAddRegion_Click" Text="Add Region" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="btnModifyRegion" runat="server" Font-Bold="True" 
                        Text="Modify Region" onclick="btnModifyRegion_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="LinqsrcRegions" ForeColor="#333333" 
                        GridLines="None" Height="116px" Width="625px" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="RegionID" HeaderText="RegionID" 
                                SortExpression="RegionID" />
                            <asp:BoundField DataField="RegionDesc" HeaderText="RegionDesc" 
                                SortExpression="RegionDesc" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqsrcRegions" runat="server" 
                        ContextTypeName="MSOPSClassesDataContext" EntityTypeName="" TableName="Regions">
                    </asp:LinqDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
