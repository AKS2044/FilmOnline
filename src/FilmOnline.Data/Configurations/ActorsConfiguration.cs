using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Actor entity.
    /// </summary>
    public class ActorsConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Actors, Schema.Film)
                .HasKey(actor => actor.Id);

            builder.Property(actor => actor.Id)
                .UseIdentityColumn();

            builder.Property(actor => actor.FirstName)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(actor => actor.LastName)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(actor => actor.SecondName)
               .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);
        }
    }
}