using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    public class tblPositionMap : EntityTypeConfiguration<tblPositionModel>
    {
        public tblPositionMap()
        {
            HasKey(i => i.postID);  //place primary key here (i.primarykeyname)
            ToTable("tblpositions"); //name ng table sa database

        }
    }
}