namespace Identity.Domain;

public enum Roles
{
    [Description("User")] User = 0,
    [Description("Admin")] Admin = 1,
    [Description("Super Admin")] SuperAdmin = 2
}