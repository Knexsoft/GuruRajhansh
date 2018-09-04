using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration(EntityTypeBuilder<User> builder)
        {
            Configure(builder);
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.SponserID).IsUnique();
            builder.Property(x => x.SponserID).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(80);
            builder.Property(x => x.ContactNumber).HasMaxLength(10).IsRequired();
            builder.Property(x => x.EmailID).HasMaxLength(100);
            builder.Property(x => x.Gender).HasMaxLength(10).IsRequired();
            builder.Property(x => x.City).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UserRole).HasMaxLength(10).IsRequired();
            builder.Property(x => x.PasswordSalt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.HashPassword).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ParentSponserID).IsRequired();
            builder.Property(x => x.ActiveToken).HasMaxLength(8);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.ModifiedOn).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            //Relationship
            builder.HasMany(x => x.SingleLegIncomes).WithOne(x => x.User);
            builder.HasMany(x => x.FrenchiseIncomes).WithOne(x => x.User);
            //builder.HasOne(x => x.UserPin).WithOne(x => x.User);
        }
    }
}
