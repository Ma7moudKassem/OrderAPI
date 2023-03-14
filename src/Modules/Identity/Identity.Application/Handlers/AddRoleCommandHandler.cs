namespace Identity.Application;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, string>
{
    IIdentityService _userService;
    public AddRoleCommandHandler(IIdentityService userServices) => _userService = userServices;

    public async Task<string> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.AddRoleAsync(request.RoleModel);

        return result;
    }
}