<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .smallErrorStyle {
            text-decoration: underline;
            font-size: x-small;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome</h1>
        </div>
        <div>
            <h4>Username:</h4>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <h4>Password:</h4>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </div>
            <asp:Button ID="btnForgotPword" runat="server" CssClass="smallErrorStyle" Text="Forgot Password" BackColor="White" BorderStyle="None" />
        <p>
        <asp:Button ID="btnLogin" runat="server" Text="Login" />
        <asp:Button ID="btnReister" runat="server" Text="Register" OnClick="btnReister_Click" />
        </p>
    </form>
</body>
</html>
