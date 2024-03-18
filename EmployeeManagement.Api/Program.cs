using EmployeeManagement.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddFluentValidationConfig();

builder.Services.AddAutoMapperConfig();

builder.Services.AddServices();

builder.Services.AddCorsConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationSwagger();

builder.Services.AddResponseConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddCorsConfig();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.AddRoutes();

app.AddErrorHandler();

app.Run();