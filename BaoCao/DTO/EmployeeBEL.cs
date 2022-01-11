using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DTO
{
   public class EmployeeBEL
    {
        public string IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Gender { get; set; }
        public string PlaceBirth { get; set; }
        public DepartmentBEL Department { get; set; }
        public string NameDepartment
        {
            get { return Department.Name; }
        }
    }
}
