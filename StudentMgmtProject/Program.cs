using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Data;
using StudentMgmtProject.Repository;
using StudentMgmtProject.Services.FacultyService;
using StudentMgmtProject.Services.IServices;
using StudentMgmtProject.Services.ProgramService;
using StudentMgmtProject.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IProgramRepository, ProgramRepository>();

builder.Services.AddScoped<IFacultyServices, FacultyServices>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IUserServices, UserServices>();

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
