
using Api.Services;
using Api.Services.IService;
using Api.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICouncilEvaluationService, CouncilEvaluationService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISubmitService, SubmitService>();
builder.Services.AddScoped<ITeacherEvaluationService, TeacherEvaluationService>();
builder.Services.AddScoped<IAccountGroupService, AccountGroupService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Report Management API",
            Description = "Report Management ASP.NET Core Web API",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Nguyen Duy Dat",
                Email = string.Empty,
                Url = new Uri("https://twitter.com"),
            },
            License = new OpenApiLicense
            {
                Name = "Use under LICX",
                Url = new Uri("https://example.com/license"),
            }
        });
    });


builder.Services.AddDbContext<Api.Data.QlreportContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("QLReportDB"));
    }
    );
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        builder =>
        {
            builder.WithOrigins("https://swp391.azurewebsites.net/",
                                "https://swp391.azurewebsites.net/");
        });

    options.AddPolicy("AnotherPolicy",
        builder =>
        {
            builder.WithOrigins("https://swp391.azurewebsites.net/",
                "https://swp391.azurewebsites.net/")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Report Management System V1");
            c.RoutePrefix = string.Empty;
        });


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
