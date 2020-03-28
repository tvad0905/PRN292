<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Region : "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="154px" AutoPostBack="True" OnDataBound="DropDownList1_DataBound">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Corporation : "></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" Height="17px" Width="226px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="FirstName : "></asp:Label>
&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
        Last Name :&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Information" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="lbResult" runat="server" Text="Add Succesfull" Visible="False"></asp:Label>
        <br />
    </form>
</body>
</html>
