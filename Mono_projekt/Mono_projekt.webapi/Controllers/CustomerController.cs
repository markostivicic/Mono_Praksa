﻿using Npgsql;
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
using System.Threading.Tasks;

namespace Mono_projekt.webapi.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerService service = new CustomerService();  
        [HttpPost]
        public async Task<HttpResponseMessage> InsertCustomerAsync([FromBody] CreateCustomerRest createCustomerRest)
        {
            try
            {
                Guid customerId = Guid.NewGuid();
                Customer newCusromer = new Customer(customerId, createCustomerRest.FirstName, createCustomerRest.LastName);
                Customer customer = await service.CreateAsync(newCusromer);
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
        public async Task<HttpResponseMessage> DeleteCustomerAsync(Guid customerId)
        {
            try
            {
                bool isDelete = await service.DeleteAsync(customerId);
                if (isDelete)
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
        public async Task<HttpResponseMessage> UpdateAsync(Guid id, [FromBody] UpdateCustomerRest updateCustomerRest)
        {
            try
            {
                Customer currentCusromer = await service.GetByIdAsync(id);
                if (currentCusromer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Bad request");
                }
                Customer updateCustomer = await service.UpdateAsync(id,currentCusromer);
                if(updateCustomer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updateCustomer);
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
        public async Task<HttpResponseMessage> GetCustomer(Guid id)
        {
            try
            {
                Customer getCustomer = await service.GetByIdAsync(id);
                if(getCustomer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, getCustomer);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }   
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCustomersAsync()
        {
            try
            {
                List<Customer> getAllCustomers = await service.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, getAllCustomers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}