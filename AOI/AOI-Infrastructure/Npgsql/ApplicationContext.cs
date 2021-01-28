using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOI_Infrastructure.Npgsql
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions options) : base(options)
        {
        }

        protected ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
