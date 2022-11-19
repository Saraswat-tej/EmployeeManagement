using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public String EmpName { get; set; }

        public String Email { get; set; }

        public String Department { get; set; }

        public String Designation { get; set; }

        public int WorkingHours { get; set; }
    }
}
