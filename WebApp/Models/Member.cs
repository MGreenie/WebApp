using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Member
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public string salt { get; set; }
    }
}