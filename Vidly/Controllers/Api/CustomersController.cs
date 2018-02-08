using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }


        //api/customers
        [HttpGet]
        public IEnumerable<Customer> Customers()
        {
            var customers = context.Customers.ToList();

            return customers;
        }
        //api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(i => i.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        // POST api/customers
        [HttpPost]
        public Customer CreateCustomers(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            context.Customers.Add(customer);
            context.SaveChanges();


            return customer;
        }

        //UPDATE api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerInDb.Name = customerDto.Name;
            customerInDb.IsSubscribedToNewsLatter = customerDto.IsSubscribedToNewsLatter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            customerInDb.MembershipType = customerDto.MembershipType;
            customerInDb.BirthDate = customerDto.BirthDate;

            this.context.SaveChanges();
        }

        //Delete api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer =  this.context.Customers.SingleOrDefault(c => c.Id == id);


            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this.context.Customers.Remove(customer);
            this.context.SaveChanges();
        }
    }
}
