using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Browser.Cookies)
                {
                    if (Request.QueryString["CheckCookie"] == null)
                    {
                        HttpCookie cookie = new HttpCookie("TestCookie", "1");
                        Response.Cookies.Add(cookie);
                        Response.Redirect("Login.aspx?CheckCookie=1");
                    }
                    else
                    {
                        HttpCookie cookie = Request.Cookies["TestCookie"];
                        if (cookie == null)
                        {
                            Label1.Text = "We have detected that, the cookies are disabled on your browser. Please enable cookies.";
                        }
                    }
                }
                else
                {
                    Label1.Text = "Browser doesn't support cookies. Please update to a newer version of a browser that supports cookies.";
                }
            }
        }

        protected void btnReister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsThisValid.IsValidEmail(txtEmail.Text) == true)
            {
                Member existingMember = new Member();
                existingMember.FindMemberByEmail(txtEmail.Text);
                if (existingMember.email != null)
                {
                    string saltedHash = Register.GenerateSaltedHash(txtPassword.Text, existingMember.salt);
                    if (existingMember.hash == saltedHash)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        txtPassword.Text = null;
                        Label1.Text = "Incorrect Password";
                    }
                }
                else
                {
                    Label1.Text = "No member associated with this email, please register!";
                }
            }
            else
            {
                txtEmail.Text = null;
                Label1.Text = "Invalid email"; 
            }
        }
    }
}