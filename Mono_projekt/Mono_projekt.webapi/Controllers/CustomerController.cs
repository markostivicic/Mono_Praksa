using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using Mono_projekt.webapi.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using Mono_projekt.Service;
using Mono_projekt.Models;

namespace Mono_projekt.webapi.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerService service = new CustomerService();  
        [HttpPost]
        public HttpResponseMessage InsertCustomer([FromBody] CreateCustomerRest createCustomerRest)
        {
            try
            {
                Guid customerId = Guid.NewGuid();
                Customer newCusromer = new Customer(customerId, createCustomerRest.FirstName, createCustomerRest.LastName);
                Customer customer = service.Create(newCusromer);
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer Didnt Create");

            }
            
        }

        [HttpDelete]
        [Route("api/customer/{customerId}")]
        public HttpResponseMessage DeleteCustomer(Guid customerId)
        {
            try
            {
                bool delete = service.Delete(customerId);
                if (delete)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to delete customer");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpPut]
        [Route("api/customer/{id}")]
        public HttpResponseMessage Update(Guid id, [FromBody] UpdateCustomerRest updateCustomerRest)
        {
            try
            {
                Customer newCusromer = new Customer(id, updateCustomerRest.FirstName, updateCustomerRest.LastName);
                Customer customer = service.Update(id,newCusromer);
                if(customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer updated");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to update customer");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }  
        }

        [HttpGet]
        [Route("api/customer/{id}")]
        public HttpResponseMessage GetCustomer(Guid id)
        {
            try
            {
                Customer customer = service.GetById(id);
                if(customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }   
        }
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            try
            {
                List<Customer> customers = service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}