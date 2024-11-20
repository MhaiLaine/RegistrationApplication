using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    public class tblEmployeesModel
    {
        public int empID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string address { get; set; }
        public int deptID { get; set; }
        public int postID { get; set; }
        public int statID { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }




    }
}