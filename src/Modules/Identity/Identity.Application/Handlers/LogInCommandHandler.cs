namespace Identity.Application;

public class LogInCommandHandler : IRequestHandler<LogInCommand, AuthenticationModel>
{
    IIdentityService _userService;
    public LogInCommandHandler(IIdentityService userServices) => _userService = userServices;

    public async Task<AuthenticationModel> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        AuthenticationModel authModel = await _userService.LogInAsync(request.LogInModel);

        return authModel;
    }
}