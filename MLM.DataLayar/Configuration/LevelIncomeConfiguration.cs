using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Configuration
{
    internal class LevelIncomeConfiguration : IEntityTypeConfiguration<LevelIncome>
    {
        public LevelIncomeConfiguration(EntityTypeBuilder<LevelIncome> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<LevelIncome> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.Income).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();

            //Relationship
            //builder.HasOne(x => x.User).WithMany(x => x.LevelIncomes).HasForeignKey(x => x.UserID);

        }
    }

    internal class LevelIncomeTypeConfiguration : IEntityTypeConfiguration<LevelIncomeType>
    {
        public LevelIncomeTypeConfiguration(EntityTypeBuilder<LevelIncomeType> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<LevelIncomeType> builder)
        {
            builder.HasKey(x => x.LevelIncomeTypeID);
            builder.HasIndex(x => x.LevelNo).IsUnique();
            builder.Property(x => x.LevelNo).IsRequired();
            builder.Property(x => x.IncomePercentage).IsRequired();

            //Relationship
        }
    }
}
