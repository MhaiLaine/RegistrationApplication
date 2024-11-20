using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    //each table in the database should have separate maps
    public class tblDepartmentMap : EntityTypeConfiguration<tblDepartmentModel>
    {
        public tblDepartmentMap()
        {
            HasKey(i => i.deptID);  //place primary key here (i.primarykeyname)
            ToTable("tbldepartments"); //name ng table sa database

        }
    }
}