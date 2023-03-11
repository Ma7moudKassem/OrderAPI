namespace Identity.Application;

public record LogInCommand(LogInModel LogInModel) : IRequest<AuthenticationModel>;