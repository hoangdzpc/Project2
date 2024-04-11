using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppRating1.Models;

namespace AppRating1.Data
{
    public class AppRating1Context : DbContext
    {
        public AppRating1Context (DbContextOptions<AppRating1Context> options)
            : base(options)
        {
        }
      
        public DbSet<RatingTable> Rating { get; set; } = default!;
        public DbSet<RatedEntityTable> RatedEntity { get; set; } = default!;
        public DbSet<ServiceTypeTable> ServiceType { get; set; } = default!;
        public DbSet<SuggestCommentTable> SuggestComment { get; set; } = default!;
        public DbSet<UserTable> User { get; set; } = default!;
    }
}
