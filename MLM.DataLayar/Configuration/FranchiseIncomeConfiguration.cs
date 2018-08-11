using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLM.DataLayer.EntityModel;

namespace MLM.DataLayer.Configuration
{
    internal class FranchiseIncomeConfiguration : IEntityTypeConfiguration<FranchiseIncome>
    {
        public FranchiseIncomeConfiguration(EntityTypeBuilder<FranchiseIncome> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<FranchiseIncome> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.UserID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.FranchiseIncomeTypeID).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.Income).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.FrenchiseIncomes).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.FranchiseIncomeType).WithMany(x => x.FranchiseIncomes).HasForeignKey(x => x.FranchiseIncomeTypeID);
            builder.HasOne(x => x.UserPin).WithOne(x => x.FranchiseIncome);
        }
    }

    internal class FranchiseIncomeTypeConfiguration : IEntityTypeConfiguration<FranchiseIncomeType>
    {
        public FranchiseIncomeTypeConfiguration(EntityTypeBuilder<FranchiseIncomeType> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<FranchiseIncomeType> builder)
        {
            builder.HasKey(x => x.FranchiseIncomeTypeID);
            builder.Property(x => x.Pins).IsRequired();
            builder.Property(x => x.FreePins).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasMany(x => x.FranchiseIncomes).WithOne(x => x.FranchiseIncomeType);
        }
    }
}
