namespace Identity.Application.Handlers;

public class ReqisterCommandHandler : IRequestHandler<ReqisterCommand, AuthenticationModel>
{
    IIdentityService _userService;
    public ReqisterCommandHandler(IIdentityService userServices) => _userService = userServices;

    public async Task<AuthenticationModel> Handle(ReqisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            AuthenticationModel authModel = await _userService.RegisterAsync(request.registerModel);

            return authModel;
        }
        catch (Exception exception)
        {
            await Console.Out.WriteLineAsync(exception.GetExceptionErrorSimplified());
            throw;
        }
    }
}
