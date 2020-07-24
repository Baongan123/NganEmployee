using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService departmentService;

        public DepartmentController(ILogger<DepartmentController> logger,
                                    IDepartmentService departmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
        }

        /// <summary>
        /// Get all department in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/department/gets")]
        public async Task<IEnumerable<Department>> Gets()
        {
            return await departmentService.Gets();
        }

        /// <summary>
        /// Get department by departmentid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/department/get/{id}")]
        public async Task<Department> Get(int id)
        {
            return await departmentService.Get(id);
        }

        [HttpPost]
        [Route("/api/department/save")]
        public async Task<SaveDepartmentResult> Save(Department request)
        {
            return await departmentService.Save(request);
        }

        [HttpDelete]
        [Route("/api/department/delete/{id}")]
        public async Task<DeleteEmployeeResult> Delete(int id)
        {
            return await departmentService.Delete(id);
        }

        [HttpGet("/api/department/search")]
        public async Task<IEnumerable<Department>> Search(string keyword)
        {
            //keyword = string.IsNullOrEmpty(keyword) ? string.Empty : keyword;
            return  await departmentService.Search(keyword);
        }
    }
}
