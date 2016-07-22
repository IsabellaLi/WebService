<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Async="true" AsyncTimeout="10000" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Test Web Service Call</h2>
    <form id="form1" runat="server">
    <div>
    <asp:label ID="rtLabel" runat="server"></asp:label>
        <br/>
        <div>
            <p>Sync</p>
        <asp:Button ID="syncCall" Text="Sync Call" OnClick="syncCall_Click" runat="server"></asp:Button>
        <asp:Button ID="sleepCall" Text="Just Sleep" OnClick="sleepCall_Click" runat="server"></asp:Button>
        <asp:Button ID="flushCall" Text="Respond, Flush, Sleep" OnClick="flushCall_Click" runat="server"></asp:Button>
            <asp:Button ID="noflush" Text="Respond, Sleep" OnClick="noflush_Click" runat="server"></asp:Button>
        </div>
        <br/>
        <div>
            <p>Async</p>
            <asp:label ID="asynLabel" runat="server"></asp:label>
            <br/>
            <asp:label ID="asynRtLabel" runat="server"></asp:label>
            <br/>
             <asp:Button ID="Button1" Text="Asyn Call" OnClick="asynCall_Click" runat="server"></asp:Button>
        
        </div>
    </div>
    </form>
</body>
</html>
