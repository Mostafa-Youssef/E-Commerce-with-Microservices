using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Order> orders { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "mostafa";
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        entry.Entity.UpdatedBy = "mostafa 2";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
