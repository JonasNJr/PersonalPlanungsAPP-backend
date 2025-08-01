using System.Text.Json.Serialization;     
using Microsoft.EntityFrameworkCore;
using PersonalPlanungsAPP.Data;           // unser Data‐Namespace
using PersonalPlanungsAPP.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) Connection‐String aus config
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// 2) DbContext hinzufügen
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conn));

// 2.1) neuen Kapazitäts-Service registrieren
builder.Services
       .AddScoped<IMitarbeiterKapazitaetsService, MitarbeiterKapazitaetsService>();

// 3) alle übrigen Services
builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        // erlaubt das Binden von Enum‐Werten als Strings
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 4) (optional) Seed‐Daten beim Start
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ctx.Database.Migrate(); // führt Migrationen aus
    // if (!ctx.Mitarbeiter.Any()) { … }
}

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
