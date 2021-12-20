<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BookShop.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
<script src="Scripts/bootstrap.js"></script>
    <title>我的购物车</title>
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
                                </div>
                            </div>
                        </nav>
                    </div>
                </div>
            </div>
            
            <!--展示购物车-->
            <div style="width:100%;height:85%;">
                <div style="width:70%;height:100%;position:relative;margin:10px auto;">
                    <asp:DataList ID="dltData" runat="server" DataKeyField="oid" OnItemCommand="dltData_ItemCommand" style="width:100%;">
                        <HeaderTemplate>
                            <table style="width:100%;">
                                <tr style="background-color:lavender;">
                                    <td style="width:10%;"><asp:CheckBox ID="cboall" runat="server" OnCheckedChanged="cboall_CheckedChanged" AutoPostBack="True" /></td>
                                    <td style="width:20%">商品图片</td>
                                    <td style="width:30%">商品名</td>
                                    <td style="width:10%">单价</td>
                                    <td style="width:10%">数量</td>
                                    <td style="width:10%">金额</td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                                <tr style="height:20%;">
                                    <td><asp:CheckBox ID="cbowho" runat="server"/></td>
                                    <td>
                                        <img alt="" src="./img/book_map/<%#Eval("ISBN") %>.png" style="width:25%;height:35%;" />
                                    </td>
                                    <td>《<%#Eval("title") %>》</td>
                                    <td><%#Eval("UnitPrice") %></td>
                                    <td><%#Eval("Quantity") %></td>
                                    <td>
                                        <%#Convert.ToDouble(Eval("UnitPrice"))*Convert.ToDouble(Eval("Quantity")) %>
                                    </td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>

                    <div style="width:100%; height:10%;">
                        <div style="float:right" class="btn-group" role="group" aria-label="Basic example">
                            <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="btn btn-primary" OnClick="btnDelete_Click"/>
                            <asp:Button ID="btnSettlement" runat="server" Text="结算" CssClass="btn btn-primary" OnClick="btnSettlement_Click"/>
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
                        <%#str.ToString() %>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
