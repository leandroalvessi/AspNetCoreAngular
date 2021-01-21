 using AspNetCoreAngular.Data.Extensions;
using AspNetCoreAngular.Data.Mappings;
using AspNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Data.Context
{
    public class AspNetCoreAngularContext : DbContext
    {
        public AspNetCoreAngularContext(DbContextOptions<AspNetCoreAngularContext> option)
            : base(option) { }

        #region "DBSets"
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            modeBuilder.ApplyConfiguration(new UserMap());

            modeBuilder.ApplyGlobalConfigurations();

            modeBuilder.SeedData();

            base.OnModelCreating(modeBuilder);
        }    
    }
}
