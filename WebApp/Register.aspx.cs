using System;
using System.Security.Cryptography;
using System.Text;
using WebApp.Models;

namespace WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();
            string passwordInvalidReason = "";

            if (newMember.SearchMemberEmail(txtEmail.Text) != true && IsThisValid.IsValidEmail(txtEmail.Text) == true)
            {
                if (txtPWord.Text == txtCPword.Text && IsThisValid.IsValidPassword(txtPWord.Text, ref passwordInvalidReason) == true)
                {
                    newMember.firstName = txtFName.Text;
                    newMember.lastName = txtLName.Text;
                    newMember.username = txtUsername.Text;
                    newMember.email = txtEmail.Text;
                    newMember.salt = CreateSalt(128 / 8);
                    newMember.hash = GenerateSaltedHash(txtPWord.Text, newMember.salt);

                    if(newMember.CreateNewMember() == true)
                    {
                        //This should transfer to a secondary information collection page not login
                        Response.Redirect("SecondaryInfo.aspx");
                    }
                    else
                    {
                        txtFName.Text = null;
                        txtLName.Text = null;
                        txtUsername.Text = null;
                        txtEmail.Text = null;
                        txtPWord.Text = null;
                        txtCPword.Text = null;
                        lblError.Text = "Error when creating member account, please try again or contanct...";
                    }
                }
                else
                {
                    if (txtPWord.Text != txtCPword.Text)
                    {
                        lblPWord.Text = "Password: Passwords do not match!";
                    }
                    else
                    {
                        lblPWord.Text = "Password: " + passwordInvalidReason;
                    }
                    
                    txtPWord.Text = null;
                    txtCPword.Text = null;
                }
            }
            else
            {
                lblEmail.Text = "Email: Email already in use!";
                txtEmail.Text = null;
            }
        }

        public static string GenerateSaltedHash(string input, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            byte[] hash = algorithm.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }
    }
}