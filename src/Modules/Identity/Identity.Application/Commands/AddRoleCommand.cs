namespace Identity.Application;

public record AddRoleCommand(RoleModel RoleModel) : IRequest<string>;
