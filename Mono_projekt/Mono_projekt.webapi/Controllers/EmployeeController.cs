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
using System.Threading.Tasks;

namespace Mono_projekt.webapi.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> InsertEmployeeAsync([FromBody] CreateEmployeeRest createEmployeeRest)
        {
            try
            {
                Guid employeeId = Guid.NewGuid();
                Employee newCusromer = new Employee(employeeId, createEmployeeRest.FirstName, createEmployeeRest.LastName);
                Employee employee = await _service.CreateAsync(newCusromer);
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
        public async Task<HttpResponseMessage> DeleteEmployeeAsync(Guid employeeId)
        {
            try
            {
                bool isDelete = await _service.DeleteAsync(employeeId);
                if (isDelete)
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
        public async Task<HttpResponseMessage> UpdateAsync(Guid id, [FromBody] UpdateEmployeeRest updateEmployeeRest)
        {
            try
            {
                Employee currentEmployee = await _service.GetByIdAsync(id);
                if (currentEmployee == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Bad request");
                }
                if (updateEmployeeRest.FirstName != null) currentEmployee.FirstName = updateEmployeeRest.FirstName;
                if (updateEmployeeRest.LastName != null) currentEmployee.LastName = updateEmployeeRest.LastName;
                Employee updateEmployee = await _service.UpdateAsync(id, currentEmployee);
                if (updateEmployee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updateEmployee);
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
        public async Task<HttpResponseMessage> GetEmployeeAsync(Guid id)
        {
            try
            {
                Employee getEmployee = await _service.GetByIdAsync(id);
                if (getEmployee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, getEmployee);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllEmployees()
        {
            try
            {
                List<Employee> getAllEmployees = await _service.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, getAllEmployees);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}