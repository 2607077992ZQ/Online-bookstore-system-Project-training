<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BookShop.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
<script src="Scripts/bootstrap.js"></script>
    <title>用户登录</title>
    <style></style>
    <script>
        function goto() {
            window.open("Reg.aspx");
        }
        function test() {
            var toastLiveExample = document.getElementById('liveToast')
            var toast = new bootstrap.Toast(toastLiveExample)
            toast.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="boos">
            <!--登录窗体-->
            <div class="div_center">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingInput" runat="server" CssClass="form-control" placeholder="用户名"></asp:TextBox>
                    <label for="floatingInput">用户名</label>
                </div>
                <div class="form-floating">
                    <asp:TextBox ID="floatingPassword" type="password" runat="server" CssClass="form-control" placeholder="密码"></asp:TextBox>
                    <label for="floatingPassword">密码</label>
                </div>
                <br />
                <asp:Button ID="btnlogin" runat="server" Text="登录" CssClass="btn btn-primary" Width="48%" OnClick="btnlogin_Click"/>
                <button class="btn btn-primary" type="submit" style="width:48%;float:right;" onclick="goto()">注册</button>
            </div>
            <!--弹窗-->
            <div class="position-fixed bottom-0 end-0 p-3" style="z-index: 11">
                <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">
                      <strong class="me-auto">错误</strong>
                      <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div class="toast-body">
                        <%#str.ToString() %>
                    </div>
                </div>
            </div>


        </div>
    </form>
</body>
</html>
