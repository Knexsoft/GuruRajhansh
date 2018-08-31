using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Configuration
{
    internal class UserPinConfiguration : IEntityTypeConfiguration<UserPin>
    {
        public UserPinConfiguration(EntityTypeBuilder<UserPin> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<UserPin> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Pin).IsRequired();
            builder.Property(x => x.IsUsed).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();

            //builder.HasOne(x => x.FranchiseIncome).WithOne(x => x.UserPin);
            //builder.HasOne(x => x.User).WithOne(x => x.UserPin).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
