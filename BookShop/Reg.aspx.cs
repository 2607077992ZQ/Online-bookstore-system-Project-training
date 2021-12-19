using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Reg : System.Web.UI.Page
    {
        BLL.UserStates usbll = new BLL.UserStates();
        BLL.Users ubll = new BLL.Users();

        public string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {
            string user = this.floatinguser.Text.Trim();
            string pwd = this.floatingPassword.Text.Trim();
            string name = this.floatingname.Text.Trim();
            string address = this.floatingAddress.Text.Trim();
            string phone = this.floatingphone.Text.Trim();
            string email = this.floatingemail.Text.Trim();

            if(user!="" && pwd != "" && name != "" && address != "" && phone != "" && email != "")
            {
                //判断用户是否存在
                if (ubll.SelectName(user,"")==null)
                {
                    Model.Users umodel = new Model.Users();

                    umodel.LoginId = user;
                    umodel.LoginPwd = pwd;
                    umodel.Name = name;
                    umodel.Address = address;
                    umodel.Phone = phone;
                    umodel.Mail = email;

                    umodel.UserRoleId = 1;
                    umodel.UserStateId = 1;
                    ubll.Add(umodel);

                    Response.Write("<script>window.close();</script>");
                }
                else
                {
                    str = "用户已存在";
                    this.DataBind();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
                }
                
            }
            else
            {
                str = "内容不能有空!";
                this.DataBind();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
            }

        }
    }
}