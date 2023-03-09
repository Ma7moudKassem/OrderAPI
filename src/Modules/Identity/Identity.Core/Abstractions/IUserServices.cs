namespace Identity.Core;

public interface IUserServices
{
    Task<AuthenticationModel> LogInAsync(LogInModel logInModel);
    Task<AuthenticationModel> RegisterAsync(RegisterModel registerModel);
    
    Task<string> AddRoleAsync(RoleModel role);
}
