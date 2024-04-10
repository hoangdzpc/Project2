using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppRating1.Controllers.Models;

namespace AppRating1.Data
{
    public class AppRating1Context : DbContext
    {
        public AppRating1Context (DbContextOptions<AppRating1Context> options)
            : base(options)
        {
        }

        public DbSet<AppRating1.Controllers.Models.Rating> Rating { get; set; } = default!;
        public DbSet<AppRating1.Controllers.Models.RatedEntity> RatedEntity { get; set; } = default!;
        public DbSet<AppRating1.Controllers.Models.ServiceType> ServiceType { get; set; } = default!;
        public DbSet<AppRating1.Controllers.Models.SuggestComment> SuggestComment { get; set; } = default!;
        public DbSet<AppRating1.Controllers.Models.User> User { get; set; } = default!;
    }
}
