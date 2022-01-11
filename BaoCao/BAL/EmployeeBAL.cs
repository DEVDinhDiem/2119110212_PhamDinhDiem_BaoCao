using BaoCao.DAL;
using BaoCao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.BAL
{
   public class EmployeeBAL
    {
        EmployeeDAL Depm = new EmployeeDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> lstCus = Depm.ReadEmployee();
            return lstCus;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            Depm.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            Depm.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            Depm.EditEmployee(emp);
        }
    }
}
