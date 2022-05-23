using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Film entity.
    /// </summary>
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Films, Schema.Film)
                .HasKey(film => film.Id);

            builder.Property(film => film.Id)
                .UseIdentityColumn();

            builder.Property(film => film.RatingSite)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(film => film.RatingKinopoisk)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(film => film.RatingImdb)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);
        }
    }
}