<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BookShop.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link type="text/css" rel="stylesheet" href="css/internet.css" />
<link type="text/css" rel="stylesheet" href="css/StyleSheet1.css" />
    <title>我的购物车</title>
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
                                    <!--
                                    <asp:TextBox ID="txtSubmit" runat="server" CssClass="form-control me-2" placeholder="查找" Width="50%"></asp:TextBox>
                                    <asp:Button ID="btnSubmit" runat="server" Text="查找" CssClass="btn btn-outline-success"/>
                                    -->
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
                                    <td><%#Convert.ToDouble(Eval("UnitPrice"))*Convert.ToDouble(Eval("Quantity")) %></td>
                                </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>

                    <!--
                    <div style="width:70%;height:10%;background-color:burlywood; z-index: 9999; position: fixed ! important; top:90%">
                        <h1 class="display-6" style="margin-top:1%;">&nbsp;
                            共
                            <asp:Label ID="lblcount" runat="server" Text="0"></asp:Label>
                            个商品</h1>
                    </div>
                    -->
                </div>
            </div>


        </div>
    </form>
</body>
</html>
