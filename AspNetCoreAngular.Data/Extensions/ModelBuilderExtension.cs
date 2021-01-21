using AspNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("d6de30c5-d2c1-40eb-a11c-d5a526f34862"), Name = "User Default", Email = "userdefaul@AspNetCoreAngular.com" }
                );
            return builder;
        }
    }
}
