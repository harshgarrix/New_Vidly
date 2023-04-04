using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using New_Vidly.Models;
using New_Vidly.ViewModel;
using Newtonsoft.Json.Serialization;

namespace New_Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Customer/List
        public ViewResult List() 
        {
            //var cust_list = _context.Customers.Include(c => c.MembershipType).ToList();
            //var viewModel = new ListCustomerViewModel()
            //{
            //    Customers = cust_list
            //};
            //return View(viewModel);
            return View();
        }

        // Customer/details/id
        //[Route("Customer/Detsils/Id")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer ==  null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult EditDetails(int id)
        {
            if (id == 0)
            {
                var membershipType = _context.MembershipTypes.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    Customer = new Customer(),
                    membershipTypes = membershipType
                };
                return View(viewModel);
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var membershiptype = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                membershipTypes = membershiptype,
                Customer = customer
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("EditDetails", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                if(customerInDb.Id == customer.Id)
                {
                    Console.Beep();
                }
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
    }
}