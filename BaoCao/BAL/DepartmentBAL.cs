using BaoCao.DAL;
using BaoCao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.BAL
{
   public class DepartmentBAL
    {
        DepartmentDAL Depm = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstdep = Depm.ReadDepartmentList();
            return lstdep;
        }
    }
}
