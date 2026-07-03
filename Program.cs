using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

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

builder.Services.AddSingleton<SecretClient>(sc =>
new SecretClient(new Uri("https://az-key-vault-mishraba1.vault.azure.net/"),new DefaultAzureCredential()));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://login.microsoftonline.com/1a9ec484-0c9d-4a8a-b059-c72c67325fe5/v2.0";
    options.ClaimsIssuer = "https://login.microsoftonline.com/1a9ec484-0c9d-4a8a-b059-c72c67325fe5/v2.0";
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = "63e24b96-c8ee-4ad5-8aed-779c66ccdd35",
        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddRazorPages(); // Or AddControllersWithViews()

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<EmployeeService>();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "First CI/CD Pipeline API is running successfully");

app.MapControllers();
app.MapGraphQL();

app.Run();
