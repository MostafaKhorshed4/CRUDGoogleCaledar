
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

using System.Threading.Tasks;


namespace Persistence
{
   public class AlMithaliDbContext: DbContext
    {
       

        public AlMithaliDbContext(DbContextOptions<AlMithaliDbContext> options)
              : base(options)
        {
            
        }



        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlMithaliDbContext).Assembly);



        }

    }
}

