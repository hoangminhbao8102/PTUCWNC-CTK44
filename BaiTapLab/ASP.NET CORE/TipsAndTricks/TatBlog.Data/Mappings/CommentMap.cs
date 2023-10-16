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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Content)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .HasColumnType("datetime");

            builder.Property(c => c.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.AuthorName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.AuthorEmail)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
