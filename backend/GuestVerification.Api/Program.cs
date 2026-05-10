using Microsoft.EntityFrameworkCore;
using GuestVerification.Data;
using GuestVerification.Core.Services;
using GuestVerification.Core.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<GuestVerificationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Services
builder.Services.AddScoped<IVerificationService, VerificationService>();
builder.Services.AddScoped<IWhitelistService, WhitelistService>();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GuestVerificationDbContext>();
    dbContext.Database.Migrate();
    SeedData(dbContext);
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();

static void SeedData(GuestVerificationDbContext context)
{
    if (!context.WhitelistEntries.Any())
    {
        var entries = new[]
        {
            new { MobileNumber = "9876543210" },
            new { MobileNumber = "9123456789" },
            new { MobileNumber = "9988776655" },
            new { MobileNumber = "9112345678" },
        };

        foreach (var entry in entries)
        {
            if (!context.WhitelistEntries.Any(w => w.MobileNumber == entry.MobileNumber))
            {
                context.WhitelistEntries.Add(new GuestWhitelist
                {
                    MobileNumber = entry.MobileNumber,
                    CreatedAt = DateTime.UtcNow
                });
            }
        }

        context.SaveChanges();
    }
}
