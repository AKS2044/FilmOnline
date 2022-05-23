using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Genre entity.
    /// </summary>
    public class GenresConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Genres, Schema.Film)
                .HasKey(genre => genre.Id);

            builder.Property(genre => genre.Id)
                .UseIdentityColumn();

            builder.Property(genre => genre.Genres)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);
        }
    }
}