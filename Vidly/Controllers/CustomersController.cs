using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer{ Id = 1, Name="John Smith"},
                new Customer{ Id = 2, Name="Mary Williams"}
            };
            return customers;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}