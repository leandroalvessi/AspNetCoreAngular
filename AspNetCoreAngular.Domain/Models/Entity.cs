using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Domain.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
