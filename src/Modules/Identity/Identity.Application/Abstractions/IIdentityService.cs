namespace Identity.Application;

public interface IIdentityService
{
    Task<AuthenticationModel> LogInAsync(LogInModel logInModel);
    Task<AuthenticationModel> RegisterAsync(RegisterModel registerModel);
    
    Task<string> AddRoleAsync(RoleModel role);
}
