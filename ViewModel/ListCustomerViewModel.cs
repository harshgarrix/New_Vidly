using New_Vidly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace New_Vidly.ViewModel
{
    public class ListCustomerViewModel
    {
        public List<Customer> Customers { get; set; }
    }
}