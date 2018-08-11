using Microsoft.EntityFrameworkCore;
using MLM.DataLayer.Configuration;
using MLM.DataLayer.EntityModel;
using System;

namespace MLM.DataLayer
{
    public class MLMDbContext : DbContext
    {
        public MLMDbContext(DbContextOptions<MLMDbContext> options) : base(options) { }

        #region Entity DBSets Properties
        public DbSet<User> Users { get; set; }
        public DbSet<SingleLegIncome> SingleLegIncomes { get; set; }
        public DbSet<LevelIncome> LevelIncomes { get; set; }
        public DbSet<FranchiseIncome> FranchiseIncomes { get; set; }
        public DbSet<UserPin> UserPins { get; set; }
        public DbSet<SingleLegIncomeType> SingleLegIncomeTypes { get; set; }
        public DbSet<LevelIncomeType> LevelIncomeTypes { get; set; }
        public DbSet<FranchiseIncomeType> FranchiseIncomeTypes { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        #region Enity Model Configuration Event
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration(modelBuilder.Entity<User>());
            new UserPinConfiguration(modelBuilder.Entity<UserPin>());
            new FranchiseIncomeConfiguration(modelBuilder.Entity<FranchiseIncome>());
            new FranchiseIncomeTypeConfiguration(modelBuilder.Entity<FranchiseIncomeType>());
            new SingleLegIncomeConfiguration(modelBuilder.Entity<SingleLegIncome>());
            new SingleLegIncomeTypeConfiguration(modelBuilder.Entity<SingleLegIncomeType>());
            new LevelIncomeConfiguration(modelBuilder.Entity<LevelIncome>());
            new LevelIncomeTypeConfiguration(modelBuilder.Entity<LevelIncomeType>());
        }
        #endregion
    }
}
