using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManage.DAL
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public async Task<DeleteEmployeeResult> Delete(int departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteEmployeeResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_DeleteDepartment",
                            commandType: CommandType.StoredProcedure);
        }

        public async Task<Department> Get(int departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<Department>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetDepartment", 
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Department>> Gets()
        {
            //string sql = @"SELECT [DepartmentId] ,[DepartmentName]  FROM [dbo].[Department]";
            //return SqlMapper.Query<Department>(conn, sql, CommandType.Text);
            return await SqlMapper.QueryAsync<Department>(conn, "sp_GetDepartments", CommandType.StoredProcedure);
        }

        public async Task<SaveDepartmentResult> Save(Department request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentId", request.DepartmentId);
                parameters.Add("@DepartmentName", request.DepartmentName);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveDepartmentResult>(cnn: conn, 
                                            sql: "sp_SaveDepartment",
                                            param: parameters, 
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                return new SaveDepartmentResult()
                {
                    DepartmentId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }

        public async Task<IEnumerable<Department>> Search(string keyword)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@keyword", keyword);
            return await SqlMapper.QueryAsync<Department>(cnn: conn, sql: "sp_SearchDepartment",
                                               param: parameters,
                                               commandType: CommandType.StoredProcedure);
        }
    }
}
