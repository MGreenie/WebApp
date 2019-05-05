<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style>
        .header{
            padding: 60px;
            text-align: center;
            background: #1e4716;
            color: whitesmoke;
            font-size: 30px;
        }

        .split{
            height: 20%;
            width: 33.33%;
            position: fixed;
            z-index: 1;
            top: 0;
            overflow-x: hidden;
            padding-top: 20px;
            text-align: center;
        }

        .left{
            left: 0;
        }

        .right{
            right: 0;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Header</h1>
            <p>Max Wahlgren</p>
            <div class="split left">
                <p>Some Text</p>
            </div>
            <div class="split right">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" BackColor="#1E4716" BorderColor="#1E4716" BorderStyle="None" BorderWidth="0px" Font-Bold="True" ForeColor="White" />
            </div>
        </div>
        <div>
            <h1>Home Page</h1>
            
        </div>
    </form>
</body>
</html>
