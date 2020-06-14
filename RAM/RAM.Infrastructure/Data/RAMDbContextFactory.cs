using System;
using Microsoft.EntityFrameworkCore;

namespace RAM.Infrastructure.Data
{
    public class RAMDbContextFactory : DesignTimeDbContextFactoryBase<RAMDbContext>
    {
        protected override RAMDbContext CreateNewInstance(DbContextOptions<RAMDbContext> options)
        {
            return new RAMDbContext(options);
        }
    }
}
