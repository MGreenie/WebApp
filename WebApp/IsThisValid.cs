using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApp
{
    public static class IsThisValid
    {
        public static bool IsValidEmail(string email)
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

        public static bool IsValidPassword(string input, ref string result)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasLower = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLower.IsMatch(input))
            {
                result = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                result = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMinimum8Chars.IsMatch(input))
            {
                result = "Password should be greater than 8 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                result = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                result = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}