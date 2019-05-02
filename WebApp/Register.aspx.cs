using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            if (SearchMemberEmail(txtEmail.Text) != true && txtEmail.Text != null)
            {
                if (txtPWord.Text == txtCPword.Text && txtPWord.Text != null)
                {
                    Member newMember = new Member();

                    newMember.firstName = txtFName.Text;
                    newMember.lastName = txtLName.Text;
                    newMember.email = txtEmail.Text;
                    newMember.salt = CreateSalt(128 / 8);
                    newMember.hash = GenerateSaltedHash(txtPWord.Text, newMember.salt);

                    CreateNewMember(newMember);
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

        private bool SearchMemberEmail(string Email)
        {
            int result = 0;
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Member WHERE email LIKE @Email";
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cnn.Open();
                    result = (int)cmd.ExecuteScalar();
                    cnn.Close();
                }
            }
            if (result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CreateNewMember(Member aMember)
        {
            int result = 0;
            try
            {
                var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string query = "INSERT INTO Member (firstName, lastName, email, salt, hash) VALUES (@fName, @lName, @Email, @Salt, @Hash)";
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@fName", aMember.firstName);
                        cmd.Parameters.AddWithValue("@lName", aMember.lastName);
                        cmd.Parameters.AddWithValue("@Email", aMember.email);
                        cmd.Parameters.AddWithValue("@Salt", aMember.salt);
                        cmd.Parameters.AddWithValue("@Hash", aMember.hash);

                        cnn.Open();
                        result = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (result == 0)
                {
                    //Not inserted
                }
                else
                {
                    //inserted
                }
            }
            catch (Exception)
            {
                //not inserted
                throw;
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