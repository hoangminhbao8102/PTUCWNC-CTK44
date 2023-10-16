using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Mappings
{
    public class SubscriberMap : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("Subscribers");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Email).IsRequired();

            builder.Property(s => s.RegistrationDate)
                .HasColumnType("datetime");

            builder.Property(s => s.UnsubscribeDate)
                .HasColumnType("datetime");

            builder.Property(s => s.UnsubscribeReason)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(s => s.IsUserInitiated)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(s => s.AdminNote)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
