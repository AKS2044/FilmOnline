using FilmOnline.Data.Constants;
using FilmOnline.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmOnline.Data.Configurations
{
    /// <summary>
    /// EF Configuration for StageManager entity.
    /// </summary>
    public class StageManagersConfiguration : IEntityTypeConfiguration<StageManager>
    {
        public void Configure(EntityTypeBuilder<StageManager> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.StageManagers, Schema.Film)
                .HasKey(stageManager => stageManager.Id);

            builder.Property(stageManager => stageManager.Id)
                .UseIdentityColumn();
        }
    }
}