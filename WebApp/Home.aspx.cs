using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReister_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Member existingMember = new Member();
            existingMember.FindMemberByEmail(txtEmail.Text);

            string saltedHash = Register.GenerateSaltedHash(txtPassword.Text, existingMember.salt);
            if (existingMember.hash == saltedHash)
            {
                Label1.Text = "Yuh boi shit worked";
            }
            else
            {
                Label1.Text = "boi pword wrong as hell";
            }
        }
    }
}