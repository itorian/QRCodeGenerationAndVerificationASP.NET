<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateQR.aspx.cs" Inherits="QRCodeGenerationAndVerification.ValidateQR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <asp:Image ID="imgQRCode" runat="server" />
    </div>
    </form>
</body>
</html>
