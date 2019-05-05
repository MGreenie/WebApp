<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondaryInfo.aspx.cs" Inherits="WebApp.SecondaryInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>More Info</h1>
        </div>

        <div>
            <div>
                <h3>Phone Information:</h3>
                <div>
                    <asp:Label ID="lblPhoneNum" runat="server" Text="Phone Number:" /> <br />
                    <asp:TextBox ID="txtPhoneNum" runat="server"/> 
                </div>
                <br />
                <div>
                    <asp:Label ID="lblTimeToCall" runat="server" Text="Best time to be reached:" /> <br />
                    <asp:Label ID="lblTimeToCallStart" runat="server" Text="From:" />
                    <asp:TextBox ID="txtTimeToCallStart" runat="server"/> 
                    <asp:Label ID="lblTimeToCallEnd" runat="server" Text="To:" />
                    <asp:TextBox ID="txtTimeToCallEnd" runat="server"/> 
                </div>
                <br />
                <div>
                    <asp:Label ID="lblPhoneType" runat="server" Text="Phone Type:" /> <br />
                    <asp:DropDownList ID="listPhoneType" runat="server"></asp:DropDownList>
                </div>
                <br />
                <asp:CheckBox ID="checkPhoneOption" runat="server" Text="Don't Provide Phone Information"/>
            </div>
            
            <br />
            <div>
                <h3>Address Information:</h3>
                <div>
                    <asp:Label ID="lblAddressLineOne" runat="server" Text="Address:" /> <br />
                    <asp:TextBox ID="txtAddressLineOne" runat="server"/> 
                </div>
                <br />
                <div>
                    <asp:Label ID="lblAddressLineTwo" runat="server" Text="Address Line Two:" /> <br />
                    <asp:TextBox ID="txtAddressLineTwo" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label ID="lblCity" runat="server" Text="City:" /> <br />
                    <asp:TextBox ID="txtCity" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label ID="lblState" runat="server" Text="State:" /> <br />
                    <asp:TextBox ID="txtState" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label ID="lblZip" runat="server" Text="Zipcode:" /> <br />
                    <asp:TextBox ID="txtZip" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label ID="lblCountry" runat="server" Text="Country:" /> <br />
                    <asp:TextBox ID="txtCountry" runat="server" />
                </div>
                <br />
                <asp:CheckBox ID="checkAddressOption" runat="server" Text="Don't Provide Address Information"/>
            </div>
            <br />
        </div>
        <asp:Button ID="btnSubmitInfo" runat="server" Text="Next" OnClick="btnSubmitInfo_Click" />
    </form>
</body>
</html>
