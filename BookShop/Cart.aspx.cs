using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Cart : System.Web.UI.Page
    {
        Model.Users umod = new Model.Users();
        public string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //找到当前用户,如果未登录，转到登录
            umod = Session["user"] as Model.Users;
            if (umod == null)
            {
                Response.Redirect("login.aspx");
            }
            this.lbluser.Text = "欢迎您:" + umod.LoginId;
            this.lkbsign.Visible = true;

            if (!Page.IsPostBack)
                FillData();

        }

        /// <summary>
        /// 找到当前用户添加过购物车的商品
        /// </summary>
        private void FillData()
        {
            Model.Users mod = Session["user"] as Model.Users;
            int uid = mod.Id;
            DataSet ds = DAL.DbHelperSQL.Query($"select * from ShopCart where uid = '{uid}' and TotalPrice = 0");
            dltData.DataSource = ds.Tables[0];
            this.DataBind();
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
        /// 触发DateList内部元素
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dltData_ItemCommand(object source, DataListCommandEventArgs e)
        {
            

        }

        /// <summary>
        /// 全选按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cboall_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0; //计数
            CheckBox cbo = sender as CheckBox;
            foreach (DataListItem item in this.dltData.Items)
            {
                CheckBox chk = item.FindControl("cbowho") as CheckBox;
                if (chk != null)
                {
                    chk.Checked = cbo.Checked;
                    count++;
                }
            }

        }

        /// <summary>
        /// 触发结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSettlement_Click(object sender, EventArgs e)
        {
            Model.Orders omod = new Model.Orders();
            BLL.Orders obll = new BLL.Orders();
            bool flag = false;

            foreach (DataListItem item in this.dltData.Items)
            {
                CheckBox chk = item.FindControl("cbowho") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    string i = this.dltData.DataKeys[item.ItemIndex].ToString();
                    omod = obll.GetModel(int.Parse(i));

                    //获取书籍的单价
                    Model.OrderBook bookmod = new Model.OrderBook();
                    BLL.OrderBook bookbll = new BLL.OrderBook();
                    bookmod = bookbll.Select(int.Parse(i));
                    //修改购买后的单价
                    omod.TotalPrice = Convert.ToDecimal(Convert.ToDouble(bookmod.Quantity) * Convert.ToDouble(bookmod.UnitPrice));
                    flag = obll.Update(omod);
                }
            }

            if (flag)
            {
                str = "购买成功!";
                this.DataBind();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
            }
            FillData();
            

        }

        /// <summary>
        /// 触发删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.OrderBook obookbll = new BLL.OrderBook();
            BLL.Orders obll = new BLL.Orders();

            foreach (DataListItem item in this.dltData.Items)
            {
                CheckBox chk = item.FindControl("cbowho") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    string i = this.dltData.DataKeys[item.ItemIndex].ToString();
                    if (obookbll.OrederDel(i))
                    {
                        obll.Delete(int.Parse(i));
                    }
                    else
                    {
                        str = "删除失败！请稍后在试";
                        this.DataBind();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
                    }
                }
            }
            FillData();

        }

    }
}