using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class ShowInfo : System.Web.UI.Page
    {
        Model.Users umod = new Model.Users();
        private int info = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            if (Session["info"] != null)
            {
                info = Convert.ToInt32(Session["info"]);
                FillDate();
            }

            //登录名回传，没登录则为空
            if (Session["user"] != null)
            {
                umod = Session["user"] as Model.Users;
                lkbBtn.Visible = false;
                this.lbluser.Text = "欢迎您:" + umod.LoginId;
                this.lkbsign.Visible = true;
            }

        }

        /// <summary>
        /// 查询当前商品的ShowInfo视图，推送到页面
        /// </summary>
        private void FillDate()
        {
            BLL.Books bll = new BLL.Books();
            DataSet ds = bll.Getbook(info);
            this.dltData.DataSource = ds.Tables[0];
            this.DataBind();

        }

        /// <summary>
        /// 触发用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        /// <summary>
        /// 触发注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbsign_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("ShowInfo.aspx");
        }

        protected void dltData_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //取出当前购买数量
            int count = Convert.ToInt32(((Label)this.dltData.Items[e.Item.ItemIndex].FindControl("lblcount")).Text);
            
            if (e.CommandName == "up")
            {
                //将当前的商品的数量加一
                ((Label)this.dltData.Items[e.Item.ItemIndex].FindControl("lblcount")).Text = Convert.ToString(count + 1);
            }

            if(e.CommandName == "down")
            {
                //将当前的商品数量减一
                if (count > 1)
                {
                    ((Label)this.dltData.Items[e.Item.ItemIndex].FindControl("lblcount")).Text = Convert.ToString(count - 1);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
                }

            }

            if(e.CommandName == "cart")
            {
                //添加到购物车，然后返回主页
                AddCart(count);
                Response.Redirect("index.aspx");
            }

        }

        /// <summary>
        /// 将商品添加到购物车
        /// </summary>
        /// <param name="index"></param>
        private void AddCart(int sum)
        {
            if(this.lbluser.Text != "")
            {
                DateTime time = System.DateTime.Now;
                //添加用户订单
                Model.Orders omod = new Model.Orders();
                omod.OrderDate = time;
                omod.UserId = umod.Id;
                omod.TotalPrice = 0;
                BLL.Orders obll = new BLL.Orders();
                obll.Add(omod);

                Model.OrderBook obmod = new Model.OrderBook();
                BLL.OrderBook obookbll = new BLL.OrderBook();
                BLL.Books bookbll = new BLL.Books();
                obmod.OrderID = obll.SelsctOrders(umod.Id).Id;
                obmod.BookID = Convert.ToInt32(Session["info"]);
                obmod.Quantity = sum;
                obmod.UnitPrice = bookbll.GetUnitprice(Convert.ToInt32(Session["info"]));
                obookbll.Add(obmod);

            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        /// <summary>
        /// 返回按钮，回到首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnbreak_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        
    }
}