using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for FilmGenre entity.
    /// </summary>
    public class FilmGenresConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.FilmGenres, Schema.Film)
                .HasKey(filmGenre => filmGenre.Id);

            builder.Property(filmGenre => filmGenre.Id)
                .UseIdentityColumn();

            builder.HasOne(filmGenre => filmGenre.Film)
               .WithMany(film => film.FilmGenres)
               .HasForeignKey(filmGenre => filmGenre.FilmId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(filmGenre => filmGenre.Genre)
                .WithMany(genre => genre.FilmGenres)
                .HasForeignKey(filmGenre => filmGenre.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}