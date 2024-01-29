using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.BLL;
using RegistroPrioridades.Components;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(op => op.UseSqlite(ConStr));
builder.Services.AddScoped<PrioridadServices>();
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<SistemaServices>();
builder.Services.AddScoped<TicketServices>();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
