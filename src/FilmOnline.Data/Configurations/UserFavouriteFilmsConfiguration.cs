using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for UserFavouriteFilm entity.
    /// </summary>
    public class UserFavouriteFilmsConfiguration : IEntityTypeConfiguration<UserFavouriteFilm>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteFilm> builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));

        builder.ToTable(Table.UserFavouriteFilms, Schema.User)
            .HasKey(userFavouriteFilm => userFavouriteFilm.Id);

        builder.Property(userFavouriteFilm => userFavouriteFilm.Id)
            .UseIdentityColumn();

        builder.HasOne(userFavouriteFilm => userFavouriteFilm.Film)
            .WithMany(film => film.UserFavouriteFilms)
            .HasForeignKey(userFavouriteFilm => userFavouriteFilm.FilmId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(userFavouriteFilm => userFavouriteFilm.User)
            .WithMany(user => user.UserFavouriteFilms)
            .HasForeignKey(userFavouriteFilm => userFavouriteFilm.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
}
