using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    //each table in the database should have separate maps
    public class tblEmployeesMap : EntityTypeConfiguration<tblEmployeesModel>
    {
        public tblEmployeesMap() {
            HasKey(i => i.empID);  //place primary key here (i.primarykeyname)
            ToTable("tblemployees"); //name ng table sa database
        
        }


    }
}