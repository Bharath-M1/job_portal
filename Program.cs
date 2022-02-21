using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Data;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
{
  var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
  var services = builder.Services;
  services.AddCors(options =>
    {
      options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
        {
          builder.WithOrigins("http://localhost:5000/", "https://localhost:5001/");
        });
    });
  services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
  services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
  services.AddTransient<IMailService, MailService>();
  services.AddDbContext<jobPortalDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("defaultServer")));
  services.AddEndpointsApiExplorer();
  services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "Jobs API",
        Version = "v1",
        Description = "An API to perform job portal operations"
      });
      var securitySchema = new OpenApiSecurityScheme
      {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
        }
      };
      c.AddSecurityDefinition("Bearer", securitySchema);
      c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              { securitySchema, new[] { "Bearer" } }
          });
    });
  // configure strongly typed settings object
  services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
  // configure DI for application services
  services.AddScoped<IUserService, UserService>();

  var app = builder.Build();
  // global cors policy
  app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());
  if (app.Environment.IsDevelopment())
  {
    app.UseDeveloperExceptionPage();
  }
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
  app.UseMiddleware<JwtMiddleware>();
  app.UseHttpsRedirection();
  app.UseDeveloperExceptionPage();
  app.UseAuthentication();
  app.UseAuthorization();
  app.MapControllers();
  app.Run("http://localhost:5000");
}