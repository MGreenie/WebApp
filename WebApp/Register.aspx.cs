using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            Server.Transfer("Home.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();
             
            if (newMember.SearchMemberEmail(txtEmail.Text) != true && IsValidEmail(txtEmail.Text) == true)
            {
                if (txtPWord.Text == txtCPword.Text && IsValidPassword(txtPWord.Text) == true)
                {
                    newMember.firstName = txtFName.Text;
                    newMember.lastName = txtLName.Text;
                    newMember.email = txtEmail.Text;
                    newMember.salt = CreateSalt(128 / 8);
                    newMember.hash = GenerateSaltedHash(txtPWord.Text, newMember.salt);

                    if(newMember.CreateNewMember() == true)
                    {
                        Server.Transfer("Home.aspx");
                    }
                    else
                    {
                        txtFName.Text = null;
                        txtLName.Text = null;
                        txtEmail.Text = null;
                        txtPWord.Text = null;
                        txtCPword.Text = null;
                        lblError.Text = "Error when creating member account, please try again or contanct...";
                    }
                }
                else
                {
                    lblPWord.Text = lblPWord.Text + "Passwords do not match!";
                    txtPWord.Text = null;
                    txtCPword.Text = null;
                }
            }
            else
            {
                lblEmail.Text = lblEmail.Text + "Email already in use!";
                txtEmail.Text = null;
            }
        }

        private bool IsValidPassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasLower = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLower.IsMatch(input))
            {
                lblError.Text = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                lblError.Text = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMinimum8Chars.IsMatch(input))
            {
                lblError.Text = "Password should be greater than 8 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                lblError.Text = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                lblError.Text = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        static string GenerateSaltedHash(string input, string salt)
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