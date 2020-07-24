using EmployeeManage.Domain.Requests;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using EmployeeManage.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        //private static int departId = 0;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult List(int departId)
        {
            ViewBag.Title = "Employee List";
            var department = new Department();
            department = ApiHelper<Department>.HttpGetAsync($"{Helper.ApiUrl}api/department/get/{departId}");
            if(department != null)
            {
                //departId = id;
                ViewBag.Department = department;
            }
            ViewBag.Departments = ApiHelper<List<Department>>.HttpGetAsync($"{Helper.ApiUrl}api/department/gets");
            return View();
        }

        public JsonResult Gets(int departId)
        {
            var employees = new List<EmployeeView>();
            employees = ApiHelper<List<EmployeeView>>.HttpGetAsync($"{Helper.ApiUrl}api/employee/gets/{departId}");
            return Json(new { employees });
        }
        [Route("/Employee/Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = new DeleteEmployeeResult();
            result = ApiHelper<DeleteEmployeeResult>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/employee/delete/{id}",
                                                    "DELETE"
                                                );
            return Json(new { result });
        }
        [Route("/Employee/Get/{id}")]
        public JsonResult Get(int id)
        {
            var result = new Employee();
            result = ApiHelper<Employee>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/employee/get/{id}"
                                                );
            return Json(new { result });
        }
        [Route("/Employee/Save")]
        public JsonResult Save([FromBody] SaveEmployeeRequest model)
        {
            var result = new SaveEmployeeResult();
            result = ApiHelper<SaveEmployeeResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/employee/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
