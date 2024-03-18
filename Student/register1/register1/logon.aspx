<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logon.aspx.cs" Inherits="register.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            left: 0;
            top: 0;
            bottom: 0;
            right: 0;
            position: absolute;
            margin-left: auto;
            margin-right: auto;
            margin-top: auto;
        }
    </style>
</head>

<body style="background-color:rgba(149, 211, 209, 0.84);">
    <form id="form1" runat="server">
        <div class="auto-style1" >
           <h1>学生签到管理页面</h1>
           <div class="big">
           <p>
             学号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
           </p>
           <p>
            密码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
           </p>
         </div>
        <asp:Button ID="Button1" runat="server" Text="登陆" Height="50px" Width="70px" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="取消" Height="50px" Width="70px" />
            <h5>（第一次登陆时，默认密码与学号相同，请同学们登陆后自行修改密码）<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
            </h5></div>       
    </form>
</body>
</html>
