using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApp.Models
{
    class MemberAddress
    {
        public int AddressID { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public int CityID { get; set; }
        public int CountyID { get; set; }
        public int StateID { get; set; }
        public string Zipcode { get; set; }
        public int CountryID { get; set; }
    }
}