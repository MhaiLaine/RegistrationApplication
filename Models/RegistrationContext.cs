using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace RegistrationApplication.Models
{
    //by default, visual studio reads sql, but here we need mysql so we need to declare the ff:
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RegistrationContext : DbContext
    //context = connection to database
    {
        static RegistrationContext()
        {
            //in projects, all databases need to be SET
            Database.SetInitializer<RegistrationContext>(null);
        }

        public RegistrationContext() : base("Name-companydb") { } //insert name ng database
                                                                  //name-companydb here is 

        public virtual DbSet<tblEmployeesModel> tblemployees { get; set; }
        public virtual DbSet<tblDepartmentModel> tbldepartments { get; set; }
        public virtual DbSet<tblPositionModel> tblpositions { get; set; }
        public virtual DbSet<tblStatusModel> tblstatuses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { //override the function to cater sa created models natin
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new tblEmployeesMap());
            modelBuilder.Configurations.Add(new tblDepartmentMap());
            modelBuilder.Configurations.Add(new tblPositionMap());
            modelBuilder.Configurations.Add(new tblStatusMap());
        }


    }
}