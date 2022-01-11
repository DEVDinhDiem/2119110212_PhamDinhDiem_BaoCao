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
   public class EmployeeDAL:DBConnection
    {
        public List<EmployeeBEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectAllEmployee", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeBEL> lstemp = new List<EmployeeBEL>();
            DepartmentDAL dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeBEL emp = new EmployeeBEL();

                emp.IdEmployee = reader["IdEmployee"].ToString();
                emp.Name = reader["Name"].ToString();
                emp.DateBirth = (DateTime)reader["DateBirth"];
                int flag = (int)reader["Gender"];
                if (flag == 1)
                {
                    emp.Gender = true;
                }
                else
                {
                    emp.Gender = false;

                }
                emp.PlaceBirth = reader["PlaceBirth"].ToString();
                emp.Department = dep.ReadDepartment(reader["IdDepartment"].ToString());
                lstemp.Add(emp);
            }
            conn.Close();
            return lstemp;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = emp.Department.IdDepartment;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();
                //thông báo
                Console.WriteLine("Them Sinh Viên thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.VarChar).Value = emp.Department.IdDepartment;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();
                //thông báo
                Console.WriteLine("Sửa Sinh Viên Thành Công !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = emp.IdEmployee;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xoá Sinh Viên Thành Công !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
 
    }
}

