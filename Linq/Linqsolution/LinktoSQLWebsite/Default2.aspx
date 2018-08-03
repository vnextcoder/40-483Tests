<%@ Page  ViewStateMode="Disabled"  Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Sum() 
        {
            var a=  parseInt(document.getElementById("Text1").value) +
                parseInt(document.getElementById("Text2").value) +
               parseInt(document.getElementById("Text3").value)
            alert(a);
//            if (confirm("Do you want to Submit?")) 
//            {
//                form1.submit();
//            }
        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server" action="def2.aspx">
    <div>
    
        <input id="Text1" name="Text1" type="text" /><br />
        <input id="Text2" type="text" /><br />
        <input id="Text3" type="text" /></div>
    <p>
        <input id="Button1" type="button" value="Sum" onclick="return Sum()" /></p>
    <p>
        <input id="subt1" type="submit" value="Submit my data" /></p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
