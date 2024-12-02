using StudyBuddyWebApp;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5044/") });



// Register the app's services
builder.Services.AddScoped<IAcademicService, AcademicService>();
builder.Services.AddScoped<ISBCalendarService, SBCalendarService>();
builder.Services.AddScoped<ISBEventService, SBEventService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<FileContext>();
builder.Services.AddAuthentication().AddCookie(options =>
{
    options.LoginPath = "/login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
