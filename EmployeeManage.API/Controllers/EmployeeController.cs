using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain.Requests;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private readonly ILogger<DepartmentController> _logger;
        private readonly IEmployeeService employeeService;

        public EmployeeController(ILogger<DepartmentController> logger,
                                    IEmployeeService employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
        }

        /// <summary>
        /// Get employees by DepartmentId
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/employee/gets/{departId}")]
        public async Task<IEnumerable<EmployeeView>> Gets(int departId)
        {
            return await employeeService.Gets(departId);
        }

        /// <summary>
        /// Get department by departmentid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/employee/get/{id}")]
        public async Task<Employee> Get(int id)
        {
            return await employeeService.Get(id);
        }

        [HttpPost]
        [Route("/api/employee/save")]
        public async Task<SaveEmployeeResult> Save(SaveEmployeeRequest request)
        {
            return await employeeService.Save(request);
        }

        [HttpDelete]
        [Route("/api/employee/delete/{id}")]
        public async Task<DeleteEmployeeResult> Delete(int id)
        {
            return await employeeService.Delete(id);
        }

        //[HttpGet("/api/department/search")]
        //public async Task<IEnumerable<Department>> Search(string keyword)
        //{
        //    //keyword = string.IsNullOrEmpty(keyword) ? string.Empty : keyword;
        //    return  await departmentService.Search(keyword);
        //}
    }
}
