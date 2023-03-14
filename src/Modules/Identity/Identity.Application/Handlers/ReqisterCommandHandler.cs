namespace Identity.Application;

public class ReqisterCommandHandler : IRequestHandler<ReqisterCommand, AuthenticationModel>
{
    IIdentityService _userService;
    public ReqisterCommandHandler(IIdentityService userServices) => _userService = userServices;

    public async Task<AuthenticationModel> Handle(ReqisterCommand request, CancellationToken cancellationToken)
    {
        AuthenticationModel authModel = await _userService.RegisterAsync(request.registerModel);

        return authModel;
    }
}