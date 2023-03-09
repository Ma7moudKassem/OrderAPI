namespace Identity.Infrastructure;

public class UserServices : IUserServices
{
    private readonly JwtModel _jwt;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    public UserServices(IOptions<JwtModel> jwt, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _jwt = jwt.Value;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<AuthenticationModel> RegisterAsync(RegisterModel registerModel)
    {
        try
        {
            if (await _userManager.FindByEmailAsync(registerModel.Email) is not null)
                return new AuthenticationModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(registerModel.UserName) is not null)
                return new AuthenticationModel { Message = "User name is already registered!" };

            ApplicationUser user = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                string errors = string.Empty;

                foreach (IdentityError error in result.Errors)
                {
                    errors += $"{error.Description},";
                }

                return new AuthenticationModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

            return new AuthenticationModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }
        catch (Exception exception)
        {
            Log.Error(exception.Message);
            throw;
        };
    }
   
    public async Task<AuthenticationModel> LogInAsync(LogInModel model)
    {
        AuthenticationModel AuthenticationModel = new AuthenticationModel();

        ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

        if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            AuthenticationModel.Message = "User Name or Password is incorrect!";
            return AuthenticationModel;
        }

        JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
        IList<string> rolesList = await _userManager.GetRolesAsync(user);

        AuthenticationModel.IsAuthenticated = true;
        AuthenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        AuthenticationModel.Email = user.Email;
        AuthenticationModel.UserName = user.UserName;
        AuthenticationModel.ExpiresOn = jwtSecurityToken.ValidTo;
        AuthenticationModel.Roles = rolesList.ToList();

        return AuthenticationModel;
    }

    public async Task<string> AddRoleAsync(RoleModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());

        if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
            return "Invalid user ID or Role";

        if (await _userManager.IsInRoleAsync(user, model.Role))
            return "User already assigned to this role";

        var result = await _userManager.AddToRoleAsync(user, model.Role);

        return result.Succeeded ? string.Empty : "Sonething went wrong";
    }
    
    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        try
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);

            List<Claim> roleClaims = new List<Claim>();

            foreach (string role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        catch (Exception exception)
        {
            Log.Error(exception.Message);
            throw;
        }
    }
}
