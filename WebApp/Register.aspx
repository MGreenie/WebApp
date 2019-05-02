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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Member] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Member] ([firstName], [lastName], [email], [salt], [hash]) VALUES (@firstName, @lastName, @email, @salt, @hash)" SelectCommand="SELECT * FROM [Member]" UpdateCommand="UPDATE [Member] SET [firstName] = @firstName, [lastName] = @lastName, [email] = @email, [salt] = @salt, [hash] = @hash WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="firstName" Type="String" />
                    <asp:Parameter Name="lastName" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="salt" Type="String" />
                    <asp:Parameter Name="hash" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="firstName" Type="String" />
                    <asp:Parameter Name="lastName" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="salt" Type="String" />
                    <asp:Parameter Name="hash" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <div>
                <asp:Label ID="lblFName" runat="server" Text="First Name:" /> <br />
                <asp:TextBox ID="txtFName" runat="server"/> 
            </div>
            <br />
            <div>
                <asp:Label ID="lblLName" runat="server" Text="Last Name:" /> <br />
                <asp:TextBox ID="txtLName" runat="server"/>
            </div>
            <br />
            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label> <br />
                <asp:TextBox ID="txtEmail" runat="server"/>
            </div>
            <br />
            <div>
                <asp:Label ID="lblPWord" runat="server" Text="Password:"></asp:Label> <br />
                <asp:TextBox ID="txtPWord" runat="server" TextMode="Password"/>
            </div>
            <br />
            <div>
                <asp:Label ID="lblCPWord" runat="server" Text="Confirm Password:"></asp:Label> <br />
                <asp:TextBox ID="txtCPword" runat="server" TextMode="Password"/>
            </div>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnRegister" runat="server" text="Register" OnClick="btnRegister_Click"/> 
            <asp:Label runat="server"></asp:Label>
            <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>
