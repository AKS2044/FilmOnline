using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Comment entity.
    /// </summary>
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Comments, Schema.Film)
                .HasKey(commnet => commnet.Id);

            builder.Property(commnet => commnet.Id)
                .UseIdentityColumn();

            builder.Property(commnet => commnet.Comments)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthFull);
        }
    }
}