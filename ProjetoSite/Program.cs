using ProjetoSite.Class;
using ProjetoSite.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var app = builder.Build();
{
    //SQLHandler sql = new SQLHandler("data source=Eduardo\\MSSQLSERVER01;initial catalog=SiteTeste;user id=Eduardo;Password=3!*$4&*$sd24@#0");
    SQLHandler sql = new SQLHandler("data source=Eduardo\\MSSQLSERVER01;initial catalog=SiteTeste;Integrated Security=SSPI;TrustServerCertificate=True");
    //Integrated Security=SSPI;TrustServerCertificate=True
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
