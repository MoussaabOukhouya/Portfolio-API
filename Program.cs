using Microsoft.EntityFrameworkCore;
using portfolio.data;
using portfolio.Services.CertificatService;
using portfolio.Services.ExperienceService;
using portfolio.Services.PersonService;
using portfolio.Services.ProjectService;
using portfolio.Services.SkillService;
using portfolio.Services.SocialMediaService;
using portfolio.Services.ToolService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICertificatService, CertificatService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
