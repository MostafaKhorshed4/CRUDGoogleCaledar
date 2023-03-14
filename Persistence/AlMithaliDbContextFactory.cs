using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    class AlMithaliDbContextFactory : DesignTimeDbContextFactoryBase<AlMithaliDbContext>
    {
        protected override AlMithaliDbContext CreateNewInstance(DbContextOptions<AlMithaliDbContext> options)
        {
            return new AlMithaliDbContext(options);
        }
    }
}

