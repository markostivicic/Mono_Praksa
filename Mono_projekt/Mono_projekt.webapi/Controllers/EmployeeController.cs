using Mono_projekt.webapi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using Mono_projekt.Models;
using Mono_projekt.Service;

namespace Mono_projekt.webapi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService service = new EmployeeService();
        [HttpPost]
        public HttpResponseMessage InsertEmployee([FromBody] CreateEmployeeRest createEmployeeRest)
        {
            try
            {
                Guid employeeId = Guid.NewGuid();
                Employee newCusromer = new Employee(employeeId, createEmployeeRest.FirstName, createEmployeeRest.LastName);
                Employee employee = service.Create(newCusromer);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Didnt Create");

            }

        }

        [HttpDelete]
        [Route("api/employee/{employeeId}")]
        public HttpResponseMessage DeleteEmployee(Guid employeeId)
        {
            try
            {
                bool delete = service.Delete(employeeId);
                if (delete)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee deleted");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to delete employee");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpPut]
        [Route("api/employee/{id}")]
        public HttpResponseMessage Update(Guid id, [FromBody] UpdateEmployeeRest updateEmployeeRest)
        {
            try
            {
                Employee newEmployee = new Employee(id, updateEmployeeRest.FirstName, updateEmployeeRest.LastName);
                Employee employee = service.Update(id, newEmployee);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee updated");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to update employee");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/{id}")]
        public HttpResponseMessage GetEmployee(Guid id)
        {
            try
            {
                Employee employee = service.GetById(id);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllEmployees()
        {
            try
            {
                List<Employee> employees = service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, employees);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}