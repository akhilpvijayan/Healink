using AutoMapper;
using Healink.Business.Services;
using Healink.Business.Services.Services;
using Healink.Data;
using Healink.Entities;
using Healink.Helper;
using Healink.MiddlewareServices;
using Healink.Xobjects.SeedScripts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection.Emit;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMemoryCache();
builder.Services.AddLazyCache();

builder.Services.AddSignalR();

//JWT Auth
var securityKey = builder.Configuration.GetValue<string>("Jwt:securityKey");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero, // To consider custom time
    };
});

//Here using this default cors policy
builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("http://localhost:4200", "https://healinkweb.vercel.app")
    .AllowAnyHeader().
    AllowAnyMethod()
    .AllowCredentials();
}));

var autoMapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
IMapper mapper = autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

string logPath = builder.Configuration.GetSection("Logging:LogPath").Value;
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(logPath)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var jwtSetting = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtSettings>(jwtSetting);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IConfigurationService, ConfigurationService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<IEducationService, EducationService>();
builder.Services.AddTransient<IExperienceService, ExperienceService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<ISearchService, SearchService>();


//builder.Services.AddTransient<CustomMiddleWare>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseClassWithNoImplementationMiddleWare();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("chatHub"); 
});

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<DataContext>();
        dbContext.Database.Migrate();
        SeedDataExtension.Seed(app.Services);
    }
    catch (Exception ex)
    {
        throw;
    }
}


app.Run();
