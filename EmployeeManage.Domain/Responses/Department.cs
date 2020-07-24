using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManage.Domain.Responses
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Employees { get; set; }
    }
}
