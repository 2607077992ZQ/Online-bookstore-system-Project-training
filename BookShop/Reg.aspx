<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="BookShop.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
    <script src="Scripts/bootstrap.js"></script>
    <title>注册用户</title>
    <script>
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
            <!--用户名，密码，姓名，地址，电话，邮箱-->
            <div class="div_reguser">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatinguser" runat="server" CssClass="form-control" placeholder="用户名"></asp:TextBox>
                    <label for="floatinguser">登录名</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingPassword" runat="server" type="password" CssClass="form-control" placeholder="密码"></asp:TextBox>
                    <label for="floatingPassword">密码</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingname" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                    <label for="floatingname">姓名</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingAddress" runat="server" CssClass="form-control" placeholder="地址"></asp:TextBox>
                    <label for="floatingAddress">地址</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingphone" runat="server" CssClass="form-control" placeholder="电话"></asp:TextBox>
                    <label for="floatingphone">电话</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="floatingemail" runat="server" CssClass="form-control" placeholder="邮箱"></asp:TextBox>
                    <label for="floatingemail">邮箱</label>
                </div>
                <asp:Button ID="btnok" runat="server" Text="立即注册" CssClass="btn btn-primary" Width="100%" OnClick="btnok_Click"/>
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
