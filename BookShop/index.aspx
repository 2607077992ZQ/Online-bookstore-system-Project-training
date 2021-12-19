<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BookShop.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
<script src="Scripts/bootstrap.js"></script>
    <title>首页</title>
    <style>
        table{
            /*width:280px;
            height:280px;*/
            text-align:left;
            /*border:1px solid black;*/
            margin-top:5px;
        }
        .td_img{
            width:150px;
            height:170px;
            margin:0 auto;
            padding:0px;
        }
    </style>
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
                        <asp:Label ID="lbluser" runat="server" Text=""> </asp:Label>
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
                                    <asp:Button ID="btnSubmit" runat="server" Text="查找" CssClass="btn btn-outline-success" OnClick="btnSubmit_Click"/>
                                </div>
                            </div>
                        </nav>
                    </div>
                </div>
            </div>
            <!--左侧导航-->
            <div class="div_left">
                <div id="list-example" class="list-group">
                    <asp:LinkButton ID="lkbxs" runat="server" OnClick="lkbxs_Click" CssClass="list-group-item list-group-item-action">小说</asp:LinkButton>
                    <asp:LinkButton ID="lkbls" runat="server" OnClick="lkbls_Click" CssClass="list-group-item list-group-item-action">历史</asp:LinkButton>
                    <asp:LinkButton ID="lkbkx" runat="server" OnClick="lkbkx_Click" CssClass="list-group-item list-group-item-action">科学技术</asp:LinkButton>
                    <asp:LinkButton ID="lkbkf" runat="server" OnClick="lkbkf_Click" CssClass="list-group-item list-group-item-action">开发类</asp:LinkButton>
                </div>
            </div>
            <!--内容-->
            <div class="div_right">
                <asp:DataList ID="dltData" runat="server" RepeatColumns="4" BorderStyle="None" DataKeyField="id" style="width:90%;height:80%;" OnItemCommand="dltData_ItemCommand">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td rowspan="4">
                                    <img alt="" src="./img/book_map/<%#Eval("ISBN").ToString() %>.png" class="td_img"/>
                                </td>
                                <td>《<%#Eval("Title") %>》</td>
                            </tr>
                            <tr>
                                <td>
                                    <b><%#Eval("Author") %></b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>金额:￥</b>
                                    <%#Math.Round(Convert.ToDouble(Eval("UnitPrice")),2)%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="width:100%;">
                                        <div style="float:right;">
                                            <asp:LinkButton ID="btninfo" runat="server" Text="i" CommandName="info" CssClass="btn btn-danger"></asp:LinkButton>
                                            <asp:LinkButton ID="btncart" runat="server" Text="+" CommandName="add" OnClick="btncart_Click" CssClass="btn btn-danger"></asp:LinkButton>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>

                <div style="width:90%;">
                    <div style="float:right">
                    当前在第:
                    <asp:Label ID="lblpage" runat="server" Text="1"></asp:Label>
                    页
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <asp:Button ID="btnup" runat="server" Text="上一页" CssClass="btn btn-primary" OnClick="btnup_Click" />
                            <asp:Button ID="btndown" runat="server" Text="下一页" CssClass="btn btn-primary" OnClick="btndown_Click"/>
                        </div>
                    </div>
                </div>
            </div>

            <!--触发警告-->
            <div class="position-fixed bottom-0 end-0 p-3" style="z-index: 11">
                <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">
                      <strong class="me-auto">错误</strong>
                      <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div class="toast-body">
                        当前已经是最后一面了
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
