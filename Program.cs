using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register controller support for attribute-routed APIs.
builder.Services.AddControllers();

// Register Swagger services so the API can be tested in the browser.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development for easy API testing.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Log basic request details for every incoming HTTP request.
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
