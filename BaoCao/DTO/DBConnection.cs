using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DTO
{
   public class DBConnection
    {
        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DINHDIEM\SQLEXPRESS;Initial Catalog=HR;User Id=sa;Password=sa"
            };
            return conn;
        }
    }
}
