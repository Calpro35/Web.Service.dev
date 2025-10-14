using Web.Service.Cap7.Extensions;
using Web.Service.Cap7.IoC;
using Web.Service.Cap7.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddMapper(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddMediatr(configuration);
builder.Services.AddInfra(configuration);
builder.Services.AddJwt(configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();