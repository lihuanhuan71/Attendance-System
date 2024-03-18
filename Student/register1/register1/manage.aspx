<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="register.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
        <div class="one">
            <h1>签到管理页面</h1>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Height="50px" Text="查看签到情况" Width="100px" OnClick="Button3_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="50px" Text="录入/修改MAC" Width="100px" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Height="50px" Text="修改密码" Width="100px" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
