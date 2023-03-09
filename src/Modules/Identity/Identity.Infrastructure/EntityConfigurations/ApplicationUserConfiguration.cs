namespace Identity.Infrastructure;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    const int maxLength = 100;
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.FirstName).IsRequired()
            .HasMaxLength(maxLength);

        builder.Property(e => e.LastName).IsRequired()
            .HasMaxLength(maxLength);
    }
}
