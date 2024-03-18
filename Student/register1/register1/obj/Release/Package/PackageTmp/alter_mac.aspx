<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alter_mac.aspx.cs" Inherits="register.alter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="one">
            <h1>管理MAC地址</h1>
            <div class="big">
        <p>
            请输入学号： 
        </p>
                <p>
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="200px"></asp:TextBox>
        </p>
        <p>
            请输入新的MAC：</p>
                <p>
                    <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="200px"></asp:TextBox>
                </p>
        <p>
&nbsp;<asp:Button ID="Button1" runat="server" Text="修改" Height="50px" Width="70px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="取消" Height="50px" Width="70px" OnClick="Button2_Click" />
        </p>
                <p>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
                </p>
                </div>
           </div>
    </form>
</body>
</html>
