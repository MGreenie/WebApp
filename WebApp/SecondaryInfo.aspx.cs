using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp
{
    public partial class SecondaryInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            //Maybe make methods to make objects if the checkboxes arent checked
            //then based off of checkboxes insert data into DB
            //Also need to add checks on each input value

            if (checkPhoneOption.Checked == false)
            {
                Phone phone = new Phone();

                //phone.MemberID = (get member information that is passed by either cookies or session data)
                phone.PhoneNumber = Int32.Parse(txtPhoneNum.Text);
                //phone.PhoneTypeID = (enum collection of phone types with id coded)
                phone.TimeToCallStart = DateTime.Parse(txtTimeToCallStart.Text);
                phone.TimeToCallEnd = DateTime.Parse(txtTimeToCallEnd.Text);
            }
            if (checkAddressOption.Checked == false)
            {
                MemberAddress address = new MemberAddress();

                address.AddressLineOne = txtAddressLineOne.Text;
                address.AddressLineTwo = txtAddressLineTwo.Text;

                /*  Find city information more than likely an api call to google to check data before inserting to DB
                address.CityID =;
                address.CountryID =;
                address.CountyID =;
                address.StateID =;
                */

                address.Zipcode = txtZip.Text;
            }
        }
    }
}