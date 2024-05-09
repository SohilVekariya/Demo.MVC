
using Business_Logic.Interface;
using HelloDoc.BAL.Interface;
using HelloDoc.BAL.Repo;
using HelloDoc.DAL.DataContext;
using HelloDoc.DAL.Repo;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDbContext")));
builder.Services.AddScoped<IPatientReqRepo, PatientReqRepo>();
builder.Services.AddScoped<IPatientDashRepo,PatientDashRepo>();
builder.Services.AddScoped<IRegisterRepo, RegisterRepo>();
builder.Services.AddScoped<IAdminDashRepo, AdminDashRepo>();
builder.Services.AddScoped<IJwtServiceRepo, JwtServiceRepo>();
builder.Services.AddScoped<IEncounterRepo, EncounterRepo>();
builder.Services.AddScoped<IAdminProfileRepo, AdminProfileRepo>();
builder.Services.AddScoped<IProviderDetailsRepo, ProviderDetailsRepo>();
builder.Services.AddScoped<ISchedulingRepo, SchedulingRepo>();
builder.Services.AddScoped<IPartnersRepo, PartnersRepo>();
builder.Services.AddScoped<IRecordsRepo, RecordsRepo>();
builder.Services.AddScoped<IProviderDashRepo, ProviderDashRepo>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


//adding session
builder.Services.AddSession();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/PatientSide/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//clear cache
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
    });


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseRotativa();
app.UseAuthorization();

//use session
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PatientSide}/{action=LandingPage}/{id?}");

app.Run();
