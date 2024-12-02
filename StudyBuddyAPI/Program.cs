using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IModeratorService, ModeratorService>();
builder.Services.AddSingleton<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeachingMaterialService, TeachingMaterialService>();
builder.Services.AddScoped<IBachelorService, BachelorService>();
builder.Services.AddSingleton<ISBCalendarService, SBCalendarService>();
builder.Services.AddSingleton<ISBEventService, SBEventService>();
builder.Services.AddSingleton<FileContext>();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthServiceAPI, AuthService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "")),
        ClockSkew = TimeSpan.Zero,
    };
});


AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", builder =>
        builder.WithOrigins("http://localhost:5044") // Blazor app URL
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazorClient"); // Apply CORS policy
app.UseAuthorization();

app.MapControllers();
app.Run();
