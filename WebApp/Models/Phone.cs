
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApp.Models
{
    class Phone
    {
        public int PhoneID { get; set; }
        public int MemberID { get; set; }
        public int PhoneNumber { get; set; }
        public int PhoneTypeID { get; set; }
        public DateTime TimeToCallStart { get; set; }
        public DateTime TimeToCallEnd { get; set; }
    }
}