using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses.Employee
{
    public class EmployeeView
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string AvatarPath { get; set; }
        public string CreatedDate { get; set; }
    }
}
