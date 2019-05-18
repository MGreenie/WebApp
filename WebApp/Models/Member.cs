using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Member : IEntity
    {
        #region IEntity Members

        public int id { get; set; }

        #endregion
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public string salt { get; set; }

        public bool CreateNewMember()
        {
            int result = 0;
            try
            {
                var cnnString = ConfigurationManager.ConnectionStrings["WahlgrenWebAppDBConnectionString"].ConnectionString;
                string query = "INSERT INTO Member (firstName, lastName, userName, email, memberSalt, memberHash) " +
                                "VALUES (@fName, @lName, @Username, @Email, @Salt, @Hash)";
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@fName", firstName);
                        cmd.Parameters.AddWithValue("@lName", lastName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        cmd.Parameters.AddWithValue("@Hash", hash);

                        cnn.Open();
                        result = cmd.ExecuteNonQuery();
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
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool SearchMemberEmail(string Email)
        {
            int result = 0;
            var cnnString = ConfigurationManager.ConnectionStrings["WahlgrenWebAppDBConnectionString"].ConnectionString;
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

        public void FindMemberByEmail(string emailInput)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["WahlgrenWebAppDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Member WHERE email LIKE @Email";
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@Email", emailInput);

                    cnn.Open();

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            firstName = reader.GetString(1);
                            lastName = reader.GetString(2);
                            email = reader.GetString(3);
                            username = reader.GetString(4);
                            salt = reader.GetString(5);
                            hash = reader.GetString(6);
                            break;
                        }
                    }
                }
            }
        }
    }
}