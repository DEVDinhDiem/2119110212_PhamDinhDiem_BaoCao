using BaoCao.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DAL
{
   public class DepartmentDAL:DBConnection
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectAllDepartment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentBEL> lstArea = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL area = new DepartmentBEL
                {
                    IdDepartment = reader["IdDepartment"].ToString(),
                    Name = reader["Name"].ToString()
                };
                lstArea.Add(area);
            }
            conn.Close();
            return lstArea;
        }
        public DepartmentBEL ReadDepartment(string IdDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectDepartment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@IdDepartment", SqlDbType.NVarChar).Value = IdDepartment;
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL dep = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.Name = reader["Name"].ToString();
            }
            conn.Close();
            return dep;
        }
    }
}
