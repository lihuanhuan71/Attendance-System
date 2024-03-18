<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alter_password.aspx.cs" Inherits="register.alter_password" %>

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
           <h1>修改密码</h1>
            <div class="big">
                <p>
                    &nbsp;&nbsp;
                    学号：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
                <p>
            原密码：<asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            新密码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="确认" Height="50px" Width="70px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="取消" Height="50px" Width="70px" OnClick="Button2_Click" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
               </div>
            </div>
    </form>
</body>
</html>
