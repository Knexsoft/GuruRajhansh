using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Configuration
{
    internal class SingleLegIncomeConfiguration : IEntityTypeConfiguration<SingleLegIncome>
    {
        public SingleLegIncomeConfiguration(EntityTypeBuilder<SingleLegIncome> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<SingleLegIncome> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.UserID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.SingleLegIncomeID).IsRequired();
            builder.Property(x => x.TotalDirects).IsRequired();
            builder.Property(x => x.TotalTeams).IsRequired();
            builder.Property(x => x.LevelCompleteDate).IsRequired();
            builder.Property(x => x.SingleLegIncomeAmount).IsRequired();
            builder.Property(x => x.LevelIncomeAmount).IsRequired();
            builder.Property(x => x.TotalIncome).IsRequired();

            //Relationship
            builder.HasOne(x => x.User).WithMany(x => x.SingleLegIncomes).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.SingleLegIncomeType).WithMany(x => x.SingleLegIncomes).HasForeignKey(x => x.SingleLegIncomeID);
        }
    }

    internal class SingleLegIncomeTypeConfiguration : IEntityTypeConfiguration<SingleLegIncomeType>
    {
        public SingleLegIncomeTypeConfiguration(EntityTypeBuilder<SingleLegIncomeType> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<SingleLegIncomeType> builder)
        {
            builder.HasKey(x => x.SingleLegIncomeID);
            builder.HasIndex(x => x.LevelNo).IsUnique();
            builder.Property(x => x.LevelNo).IsRequired();
            builder.Property(x => x.Directs).IsRequired();
            builder.Property(x => x.Teams).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.UpgradeCharge).IsRequired();

            //Relationship
            builder.HasMany(x => x.SingleLegIncomes).WithOne(x => x.SingleLegIncomeType);
        }
    }
}
