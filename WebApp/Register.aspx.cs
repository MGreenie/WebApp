using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            /*
              Steps:
               1. Validate email as unique
               2. Make sure passwords match
               3. Encrypt password 
               4. Create Member object
               5. Insert data into database
            */


            if (txtPword.Text == txtCPword.Text)
            {
                Member newMember = new Member();

                newMember.firstName = txtFName.Text;
                newMember.lastName = txtLName.Text;
                newMember.email = txtEmail.Text;
                newMember.salt = CreateSalt(128 / 8);
                newMember.hash = GenerateSaltedHash(txtPword.Text, newMember.salt);

                Label1.Text = "Salt: " + newMember.salt;
                Label2.Text = "Hash: " + newMember.hash;

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