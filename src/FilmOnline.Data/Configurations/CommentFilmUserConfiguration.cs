using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for CommentFilmUser entity.
    /// </summary>
    public class CommentFilmUserConfiguration : IEntityTypeConfiguration<CommentFilmUser>
    {
        public void Configure(EntityTypeBuilder<CommentFilmUser> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.CommentFilmUsers, Schema.Film)
                .HasKey(commentFilmUser => commentFilmUser.Id);

            builder.Property(commentFilmUser => commentFilmUser.Id)
                .UseIdentityColumn();

            builder.HasOne(commentFilmUser => commentFilmUser.Film)
               .WithMany(film => film.CommentFilmUsers)
               .HasForeignKey(commentFilmUser => commentFilmUser.FilmId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(commentFilmUser => commentFilmUser.Comment)
                .WithMany(comment => comment.CommentFilmUsers)
                .HasForeignKey(commentFilmUser => commentFilmUser.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(commentFilmUser => commentFilmUser.User)
                .WithMany(user => user.CommentFilmUsers)
                .HasForeignKey(commentFilmUser => commentFilmUser.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}