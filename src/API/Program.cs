WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSharedInfrastructure();
builder.Services.AddIdentityModule(builder.Configuration);

Log.Logger = new LoggerConfiguration().WriteTo
    .File(string.Concat(Directory
    .GetCurrentDirectory(), "\\Logs\\Error.log"),
    rollingInterval: RollingInterval.Hour).CreateLogger();

builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderAPI");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();