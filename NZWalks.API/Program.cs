using DAL.Data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with connection string
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging());

// Register Repositories for Dependency Injection
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IMovieRepository, SQLMovieRepository>();
builder.Services.AddScoped<IPostalCodeRepository, SQLPostalCodeRepository>();
builder.Services.AddScoped<IGenreRepository, SQLGenreRepository>();
builder.Services.AddScoped<ICinemaHallRepository, SQLCinemaHallRepository>(); // Added for CinemaHalls

// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
