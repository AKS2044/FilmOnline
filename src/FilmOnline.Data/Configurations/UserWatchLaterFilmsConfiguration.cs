using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for UserWatchLaterFilm entity.
    /// </summary>
    public class UserWatchLaterFilmsConfiguration : IEntityTypeConfiguration<UserWatchLaterFilm>
    {
        public void Configure(EntityTypeBuilder<UserWatchLaterFilm> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.UserWatchLaterFilms, Schema.User)
                .HasKey(userWatchLaterFilm => userWatchLaterFilm.Id);

            builder.Property(userWatchLaterFilm => userWatchLaterFilm.Id)
                .UseIdentityColumn();

            builder.HasOne(userWatchLaterFilm => userWatchLaterFilm.Film)
                .WithMany(film => film.UserWatchLaterFilms)
                .HasForeignKey(userWatchLaterFilm => userWatchLaterFilm.FilmId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(userWatchLaterFilm => userWatchLaterFilm.User)
                .WithMany(user => user.UserWatchLaterFilms)
                .HasForeignKey(userWatchLaterFilm => userWatchLaterFilm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
