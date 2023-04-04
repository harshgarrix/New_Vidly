using New_Vidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}