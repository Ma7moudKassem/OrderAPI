namespace Identity.Infrastructure;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = Roles.SuperAdmin.ToString(),
                NormalizedName = Roles.SuperAdmin.ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = Roles.User.ToString(),
                NormalizedName = Roles.User.ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }); ;
    }
}