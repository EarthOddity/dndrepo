using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddSingleton<IModeratorService, ModeratorService>();
builder.Services.AddSingleton<ISubjectService, SubjectService>();
builder.Services.AddSingleton<IBachelorService, BachelorService>();
builder.Services.AddSingleton<ISBCalendarService, SBCalendarService>();
builder.Services.AddSingleton<ISBEventService, SBEventService>();
builder.Services.AddSingleton<FileContext>();
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
