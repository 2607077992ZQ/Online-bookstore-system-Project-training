using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class index : System.Web.UI.Page
    {
        Model.Users umod = new Model.Users();
        private int page = 0; //页数

        protected void Page_Load(object sender, EventArgs e)
        {
            //清空详细信息索引
            Session["info"] = null;

            //获取首页搜索框内容，并展现
            string search = Request.QueryString["search"];
            string cid = Request.QueryString["cid"];
            if (search != null)
            {
                string str = $"title like '%{search}%' or Author like '%{search}%'";
                FillData(str);
            }
            else if (cid != null)
            {
                string str = $"CategoryId = '{cid}'";
                FillData(str);
            }
            else
            {
                FillData("");
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
        /// 分页获取数据
        /// </summary>
        private void FillData(string str)
        {
            //取得当前页的页码
            int curpage = Convert.ToInt32(this.lblpage.Text);
            BLL.Books ubll = new BLL.Books();
            PagedDataSource ps = new PagedDataSource();

            //获取数据集
            DataSet ds = ubll.GetList(str);
            //获取图书表有多少行
            page = ds.Tables[0].Rows.Count;

            ps.DataSource = ds.Tables[0].DefaultView;
            //是否可以分页
            ps.AllowPaging = true;
            //显示的数量
            ps.PageSize = 8;

            //取得当前页的页码内容
            ps.CurrentPageIndex = curpage - 1;
            this.dltData.DataSource = ps;
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
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnup_Click(object sender, EventArgs e)
        {
            if (lblpage.Text != "1")
            {
                this.lblpage.Text = Convert.ToString(Convert.ToInt32(this.lblpage.Text) - 1);
                this.FillData("");
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndown_Click(object sender, EventArgs e)
        {
            double i = (double)page / 8;

            if (i >= Convert.ToInt32(lblpage.Text) && i!=1)
            {
                this.lblpage.Text = Convert.ToString(Convert.ToInt32(this.lblpage.Text) + 1);
                this.FillData("");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
            }

            
        }

        /// <summary>
        /// 触发查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblpage.Text = Convert.ToString(1);
            string lookup = this.txtSubmit.Text.Trim();
            if (lookup != "")
            {
                Response.Redirect($"index.aspx?search={lookup}");
            }
            else
            {
                Response.Redirect($"index.aspx");
            }

        }

        /// <summary>
        /// 触发详细信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btninfo_Click(object sender, EventArgs e)
        {
            

        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbsign_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("index.aspx");
        }

        /// <summary>
        /// DataList内按钮
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dltData_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //添加到该用户的购物车
            if (e.CommandName == "add")
            {
                int i = Convert.ToInt32(this.dltData.DataKeys[e.Item.ItemIndex].ToString());
                //Response.Write($"<script>alert('{i}')</script>");
                AddCart(i);
            }

            //展现当前商品的详细信息
            if(e.CommandName == "info")
            {
                int i = Convert.ToInt32(this.dltData.DataKeys[e.Item.ItemIndex].ToString());
                Session["info"] = i;
                Response.Redirect("showinfo.aspx");
            }
        }

        /// <summary>
        /// 将商品添加到购物车
        /// </summary>
        /// <param name="index"></param>
        private void AddCart(int index)
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
            obmod.OrderID = obll.SelsctOrders(umod.Id).Id;//订单id
            obmod.BookID = index;//书籍id
            obmod.Quantity = 1;
            obmod.UnitPrice = bookbll.GetUnitprice(index);
            obookbll.Add(obmod);
        }

        /// <summary>
        /// 添加到购物车按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btncart_Click(object sender, EventArgs e)
        {
            if(lbluser.Text == "")
            {
                Response.Redirect("login.aspx");
            }
        }

        /// <summary>
        /// 小说按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbxs_Click(object sender, EventArgs e)
        {
            this.lblpage.Text = 1.ToString();
            Response.Redirect("index.aspx?cid=1");
        }


        /// <summary>
        /// 历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbls_Click(object sender, EventArgs e)
        {
            this.lblpage.Text = 1.ToString();
            Response.Redirect("index.aspx?cid=2");
        }

        /// <summary>
        /// 科学技术按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbkx_Click(object sender, EventArgs e)
        {
            this.lblpage.Text = 1.ToString();
            Response.Redirect("index.aspx?cid=3");
        }

        /// <summary>
        /// 开发类按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lkbkf_Click(object sender, EventArgs e)
        {
            this.lblpage.Text = 1.ToString();
            Response.Redirect("index.aspx?cid=4");
        }
    }
}