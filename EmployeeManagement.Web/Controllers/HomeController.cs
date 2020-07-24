using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement.Web.Models;
using EmployeeManage.Domain.Responses;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using EmployeeManage.Web.Ultilities;

namespace EmployeeManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Department List";
            return View();
        }

        public JsonResult Gets()
        {
            var departments = new List<Department>();
            departments = ApiHelper<List<Department>>.HttpGetAsync($"{Helper.ApiUrl}api/department/gets");
            return Json(new { departments });
        }

        [Route("/Home/Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = new DeleteEmployeeResult();
            result = ApiHelper<DeleteEmployeeResult>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/department/delete/{id}",
                                                    "DELETE"
                                                );
            return Json(new { result });
        }

        [Route("/Home/Get/{id}")]
        public JsonResult Get(int id)
        {
            var result = new Department();
            result = ApiHelper<Department>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/department/get/{id}"
                                                );
            return Json(new { result });
        }
        public JsonResult Save([FromBody] Department model)
        {
            var result = new SaveDepartmentResult();
            result = ApiHelper<SaveDepartmentResult>.HttpPostAsync(
                                                    $"{Helper.ApiUrl}api/department/save",
                                                    model
                                                );
            return Json(new { result });
        }
    }
}
