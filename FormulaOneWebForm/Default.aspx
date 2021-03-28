<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--<asp:DropDownList ID="tb1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="tb2" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedIndexChangedTB23"></asp:DropDownList>
            <asp:DropDownList ID="tb3" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedIndexChangedTB23"></asp:DropDownList>
            <br />
            <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="true"></asp:GridView>-->
            <asp:ListBox runat="server" AutoPostBack="true" ID="lbx"> 
            </asp:ListBox>
        </div>
    </form>
</body>
</html>
