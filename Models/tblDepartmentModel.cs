using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    public class tblDepartmentModel
    {
        public int deptID { get; set; }
        public string deptName { get; set; }
        public int isActive { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

    }
}