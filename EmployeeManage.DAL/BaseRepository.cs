using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManage.DAL
{
    public class BaseRepository
    {
        protected  IDbConnection conn;
        public BaseRepository()
        {
            string connectionString = @"Data Source=DESKTOP-RT5NF5I\sqlexpress;Initial Catalog=EmployeeManage1;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
    }
}
