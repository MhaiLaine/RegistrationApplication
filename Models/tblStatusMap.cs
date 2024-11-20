using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    public class tblStatusMap : EntityTypeConfiguration<tblStatusModel>
    {
        public tblStatusMap()
        {
            HasKey(i => i.statID);  //place primary key here (i.primarykeyname)
            ToTable("tblstatuss"); //name ng table sa database

        }
    }
}