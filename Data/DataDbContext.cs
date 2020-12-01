using Data.Entity;
using System.Data.Entity;


namespace Data
{
    internal sealed class DataDbContext : DbContext
    {
        public DataDbContext(string connectionString) : base(connectionString)
        {
            var config = new DataDbConfig();
            DbConfiguration.SetConfiguration(config);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Writing>().ToTable(nameof(Writing));
            modelBuilder.Entity<Comment>().ToTable(nameof(Comment));
            modelBuilder.Entity<Rating>().ToTable(nameof(Rating));
        }
    }
}