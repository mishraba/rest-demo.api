var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAngular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => "First CI/CD Pipeline API is running successfully");

app.MapControllers();

app.Run();
