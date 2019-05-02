<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>New Member Registration</h1>
        </div>
        <div>
            <p>First Name:</p>
            <asp:TextBox ID="txtFName" runat="server"/>

            <p>Last Name:</p>
            <asp:TextBox ID="txtLName" runat="server" />

            <p>Email:</p>
            <asp:TextBox ID="txtEmail" runat="server"/>

            <p>Password:</p>
            <asp:TextBox ID="txtPword" runat="server"/>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <p>Confirm Password:</p>
            <asp:TextBox ID="txtCPword" runat="server" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" text="Register" OnClick="btnRegister_Click"/>
            <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>
