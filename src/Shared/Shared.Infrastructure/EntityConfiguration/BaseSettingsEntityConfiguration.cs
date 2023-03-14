namespace Shared.Infrastructure;

public class BaseSettingsEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : BaseSettingsEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        base.Configure(builder);
    }
}
