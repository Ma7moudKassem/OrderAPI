namespace Identity.API;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator) =>
        _mediator = mediator;

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        var responceModel = await _mediator.Send(new ReqisterCommand(registerModel));

        if (ModelState.IsValid)
            return Ok(responceModel);

        return BadRequest();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LogInModel logInModel)
    {
        var responceModel = await _mediator.Send(new LogInCommand(logInModel));

        if (ModelState.IsValid)
            return Ok(responceModel);

        return BadRequest();
    }

    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole(RoleModel roleModel)
    {
        var responceModel = await _mediator.Send(new AddRoleCommand(roleModel));

        if (ModelState.IsValid)
            return Ok(responceModel);

        return BadRequest();
    }
}
