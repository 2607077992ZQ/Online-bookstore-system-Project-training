using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class login : System.Web.UI.Page
    {
        public string str = "";
        BLL.Users ubll = new BLL.Users();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string name = floatingInput.Text.Trim();
            string pwd = floatingPassword.Text.Trim();

            if (name != "" && pwd != "")
            {
                if (ubll.SelectName(name, pwd) == null)
                {
                    //密码错误
                    str = "密码错误";
                    this.DataBind();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");
                }
                else
                {
                    Model.Users mod = ubll.SelectName(name, pwd);
                    if (mod.UserStateId == 1)
                    {
                        //允许登录
                        //Response.Write("<script>alert('111')</script>");
                        Session["user"] = mod;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        //无法登录
                        str = "当前用户无法登录";
                        this.DataBind();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");

                    }

                }

            }
            else
            {
                //用户名或密码有空
                str = "密码不能为空";
                this.DataBind();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), null, "<script>test();</script>");

            }


        }
    }
}