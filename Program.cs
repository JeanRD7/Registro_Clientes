using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Registro_Clientes.DAL;
using Registro_Clientes.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//ConStr que se usara en el contexto Ticket
var ConStr = builder.Configuration.GetConnectionString("ConStr");

//agregarmos el contexto tickets con el ConStr
builder.Services.AddDbContext<TicketContext>(Op => Op.UseSqlite(ConStr));

//agregamos el TicketBLL
builder.Services.AddScoped<TicketsBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
