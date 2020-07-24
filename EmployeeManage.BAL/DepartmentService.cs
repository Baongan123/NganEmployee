using EmployeeManage.BAL.Interface;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManage.BAL
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<DeleteEmployeeResult> Delete(int departmentId)
        {
            return await departmentRepository.Delete(departmentId);
        }

        public async Task<Department> Get(int departmentId)
        {
            return await departmentRepository.Get(departmentId);
        }

        public async Task<IEnumerable<Department>> Gets()
        {
            return await departmentRepository.Gets();
        }

        public async Task<SaveDepartmentResult> Save(Department request)
        {
            return await departmentRepository.Save(request);
        }

        public async Task<IEnumerable<Department>> Search(string keyword)
        {
            return await departmentRepository.Search(keyword);
        }
    }
}
