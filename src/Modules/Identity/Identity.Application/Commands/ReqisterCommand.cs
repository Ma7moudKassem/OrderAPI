namespace Identity.Application;

public record ReqisterCommand(RegisterModel registerModel) : IRequest<AuthenticationModel>;
