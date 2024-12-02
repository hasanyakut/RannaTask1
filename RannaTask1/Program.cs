using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RannaTask1.Data;
using RannaTask1.Repositories;
using RannaTask1.Requests;
using RannaTask1.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupportFormRepository, SupportFormRepository>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISupportFormService, SupportFormService>();

var key = Encoding.UTF8.GetBytes("JHLKJHsdkfjhLKJAHsdfkfDHLKsjdhfkljfhaDJKHSADFaskdhjASJHDFCKSAFasdASDAAdsADS");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = "issuer",
			ValidAudience = "audience",
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};
	});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header,
			},
			new List<string>()
		}
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/api/login", ([FromBody] LoginRequest request, AppDbContext dbContext) =>
{
	var customer = dbContext.Customers.FirstOrDefault(c => c.Username == request.Username && c.Password == request.Password);
	var admin = dbContext.Admins.FirstOrDefault(a => a.Username == request.Username && a.Password == request.Password);

	if (customer == null && admin == null)
		return Results.Unauthorized();

	var tokenHandler = new JwtSecurityTokenHandler();
	var tokenDescriptor = new SecurityTokenDescriptor
	{
		Subject = new ClaimsIdentity(new[]
		{
			new Claim(ClaimTypes.Name, customer?.Username ?? admin.Username),
			new Claim(ClaimTypes.Role, customer != null ? "Customer" : "Admin")
		}),
		Expires = DateTime.UtcNow.AddHours(1),
		SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JHLKJHsdkfjhLKJAHsdfkfDHLKsjdhfkljfhaDJKHSADFaskdhjASJHDFCKSAFasdASDAAdsADS")), SecurityAlgorithms.HmacSha256Signature),
		Issuer = "issuer",
		Audience = "audience"
	};
	var token = tokenHandler.CreateToken(tokenDescriptor);

	return Results.Ok(new { Token = tokenHandler.WriteToken(token) });
})
.AllowAnonymous()
.WithName("Login");

app.MapControllers();

app.Run();
