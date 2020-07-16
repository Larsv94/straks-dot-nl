using Microsoft.AspNet.Identity.EntityFramework;
using straks_nl.Data.Entities;
using straks_nl.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace straks_nl.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategorie> ArticleCategories { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            setCreatedDate();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            setCreatedDate();
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            setCreatedDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void setCreatedDate()
        {
            var addedEntities = ChangeTracker.Entries()
            .Where(E => E.State == EntityState.Added);

            var addedTrackedEntities = addedEntities.Where(e=>e.Entity.GetType().IsSubclassOf(typeof(TimeTrackedEntity)));

            foreach (var timeTrackedEntity in addedTrackedEntities)
            {
                if(timeTrackedEntity.Property("CreatedAt").OriginalValue==null){
                    timeTrackedEntity.Property("CreatedAt").CurrentValue = DateTime.Now;
                }
                
            }

        }
    }
}
