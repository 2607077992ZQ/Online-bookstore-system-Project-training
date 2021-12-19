<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="BookShop.ShowInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
<script src="Scripts/bootstrap.js"></script>
    <title></title>
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
            <!--标题-->
            <div class="div_title">
                <div class="div_title_head">
                    <div style="float:right; margin-top:5px; margin-right:10px;">
                        <asp:LinkButton ID="lkbBtn" runat="server" BorderStyle="None" ForeColor="Black" style="TEXT-DECORATION:none;" OnClick="lkbBtn_Click">用户登录</asp:LinkButton>
                        <asp:Label ID="lbluser" runat="server" Text=""></asp:Label>
                        <asp:LinkButton ID="lkbsign" runat="server" style="TEXT-DECORATION:none;" OnClick="lkbsign_Click" Visible="false">注销</asp:LinkButton>
                    </div>
                </div>
                <!--顶部导航-->
                <div class="div_title_foot">
                    <div class="div_title_center">
                        <nav class="navbar navbar-expand-lg navbar-light bg-light">
                            <div class="container-fluid">
                                <a class="navbar-brand" href="index.aspx">首页</a>
                                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                    <li class="nav-item">
                                        <a class="nav-link" href="Cart.aspx">我的购物车</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="login.aspx">用户登录</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">管理员页面</a>
                                    </li>
                                    </ul>
                                    <asp:TextBox ID="txtSubmit" runat="server" CssClass="form-control me-2" placeholder="查找" Width="50%"></asp:TextBox>
                                    <asp:Button ID="btnSubmit" runat="server" Text="查找" CssClass="btn btn-outline-success"/>
                                </div>
                            </div>
                        </nav>
                    </div>
                </div>
            </div>
            <!--详细页面-->
            <div style="width:70%;height:85%; position:relative;margin:10px auto;">
                <asp:DataList ID="dltData" runat="server" DataKeyField="Bid" OnItemCommand="dltData_ItemCommand" style="width:100%;height:100%">
                    <ItemTemplate>
                        <table style="width:100%; height:100%;">
                            <tr>
                                <td rowspan="7" style="width:40%;">
                                    <img alt="" src="img/Book_map/<%#Eval("ISBN").ToString() %>.png" style="width:100%; height:70%;"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>书籍名称:</b>《<%#Eval("title") %>》
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>出版社:</b><%#Eval("PublisherId") %></td>
                            </tr>
                            <tr>
                                <td>
                                    <b>作者简介:</b><%#Eval("AuthorDescription") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>书本简介:</b><%#Eval("ContentDescription") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>售价:</b><asp:Label ID="lblunit" runat="server"><%#Math.Round(Convert.ToDouble(Eval("Unitprice")),2) %></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><!--下方按钮-->
                                    <div id="left" style="width:50%; float:left">
                                        <asp:LinkButton ID="lkbdown" runat="server" CssClass="btn btn-primary" CommandName="down">-</asp:LinkButton>
                                        &nbsp;
                                        <asp:Label ID="lblcount" runat="server" Text="1"></asp:Label>
                                        &nbsp;
                                        <asp:LinkButton ID="lkbup" runat="server" CssClass="btn btn-primary" CommandName="up">+</asp:LinkButton>
                                    </div>
                                    <div id="right" style="width:50%;float:right;">
                                        <div style="float:right;" class="btn-group" role="group" aria-label="Basic example">
                                            <asp:Button ID="btnbreak" runat="server" Text="返回" OnClick="btnbreak_Click" CssClass="btn btn-primary"/>
                                            <asp:Button ID="btnok" runat="server" Text="购买" CssClass="btn btn-primary" CommandName="buy"/>
                                            <asp:Button ID="btnCart" runat="server" Text="加入购物车" CssClass="btn btn-primary" CommandName="cart"/>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        
            <!--触发警告-->
            <div class="position-fixed bottom-0 end-0 p-3" style="z-index: 11">
                <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">
                      <strong class="me-auto">错误</strong>
                      <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div class="toast-body">
                        最少购买一件商品
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
