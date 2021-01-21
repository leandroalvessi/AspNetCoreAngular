using AspNetCoreAngular.Domain.Entities;
using AspNetCoreAngular.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;

                        case nameof(Entity.DateUpdate):
                            property.IsNullable = true;
                            break;
                                
                        case nameof(Entity.DateCreate):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;

                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;

                        default:
                            break;
                    }
                }
            }
            return builder;
        }
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("d6de30c5-d2c1-40eb-a11c-d5a526f34862"), Name = "User Default", Email = "userdefaul@AspNetCoreAngular.com", DateCreate = new DateTime(2020, 2, 2), IsDeleted = false, DateUpdate = null }
                );
            return builder;
        }
    }
}
