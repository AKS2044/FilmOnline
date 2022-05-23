using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for UserFilm entity.
    /// </summary>
    public class UserFilmConfiguration : IEntityTypeConfiguration<UserFilm>
    {
        public void Configure(EntityTypeBuilder<UserFilm> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.UserFilms, Schema.User)
                .HasKey(userFilm => userFilm.Id);

            builder.Property(userFilm => userFilm.Id)
                .UseIdentityColumn();

            builder.HasOne(userFilm => userFilm.Film)
                .WithMany(film => film.UserFilms)
                .HasForeignKey(userFilm => userFilm.FilmId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(userFilm => userFilm.User)
                .WithMany(user => user.UserFilms)
                .HasForeignKey(userFilm => userFilm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}