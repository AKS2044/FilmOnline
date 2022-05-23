using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for FilmCountry entity.
    /// </summary>
    public class FilmCountriesConfiguration : IEntityTypeConfiguration<FilmCountry>
    {
        public void Configure(EntityTypeBuilder<FilmCountry> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.FilmCountries, Schema.Film)
                .HasKey(filmCountry => filmCountry.Id);

            builder.Property(filmCountry => filmCountry.Id)
                .UseIdentityColumn();

            builder.HasOne(filmCountry => filmCountry.Film)
                .WithMany(film => film.FilmCountries)
                .HasForeignKey(filmCountry => filmCountry.FilmId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(filmCountry => filmCountry.State)
                .WithMany(country => country.FilmCountries)
                .HasForeignKey(filmCountry => filmCountry.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}