using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<DeleteEmployeeResult> Delete(int employeeId)
        {
            return await employeeRepository.Delete(employeeId);
        }

        public async Task<Employee> Get(int employeeId)
        {
            return await employeeRepository.Get(employeeId);
        }

        public async Task<IEnumerable<EmployeeView>> Gets(int departId)
        {
            return await employeeRepository.Gets(departId);
        }

        public async Task<SaveEmployeeResult> Save(SaveEmployeeRequest request)
        {
            return await employeeRepository.Save(request);
        }

        //public async Task<IEnumerable<Department>> Search(string keyword)
        //{
        //    return await departmentRepository.Search(keyword);
        //}
    }
}
