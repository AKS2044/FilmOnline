using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for FilmRating entity.
    /// </summary>
    public class FilmRatingsConfiguration : IEntityTypeConfiguration<FilmRating>
    {
        public void Configure(EntityTypeBuilder<FilmRating> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.FilmRatings, Schema.Film)
                .HasKey(filmRating => filmRating.Id);

            builder.Property(filmRating => filmRating.Id)
                .UseIdentityColumn();

            builder.HasOne(filmRating => filmRating.Film)
               .WithMany(film => film.FilmRatings)
               .HasForeignKey(filmRating => filmRating.FilmId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(filmRating => filmRating.Rating)
                .WithMany(rating => rating.FilmRatings)
                .HasForeignKey(filmRating => filmRating.RatingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}