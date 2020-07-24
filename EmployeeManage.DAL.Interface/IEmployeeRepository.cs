using EmployeeManage.Domain.Requests;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.DAL.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeView>> Gets(int departId);
        Task<SaveEmployeeResult> Save(SaveEmployeeRequest request);
        Task<Employee> Get(int employeeId);
        Task<DeleteEmployeeResult> Delete(int departmentId);       
        //Task<IEnumerable<Department>> Search(string keyword);
    }
}
