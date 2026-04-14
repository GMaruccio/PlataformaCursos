using PlataformaCursosOnline.Factories;
using PlataformaCursosOnline.Services;

var builder = WebApplication.CreateBuilder(args);

// ─── MVC ──────────────────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ─── Factories (Princípio DIP: injetar abstrações) ────────────────────────────
builder.Services.AddSingleton<ICursoFactory, VideoFactory>();   // padrão p/ vídeo
builder.Services.AddSingleton<AoVivoFactory>();                 // factory ao vivo
builder.Services.AddSingleton<ITrilhaFactory, TrilhaIniciante>();
builder.Services.AddSingleton<ITrilhaFactory, TrilhaAvancada>();

// ─── Services ─────────────────────────────────────────────────────────────────
builder.Services.AddSingleton<ICursoService>(sp =>
    new CursoService(
        sp.GetRequiredService<ICursoFactory>(),
        sp.GetRequiredService<AoVivoFactory>()
    ));

builder.Services.AddSingleton<ITrilhaService, TrilhaService>();
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();

// ─── Build ────────────────────────────────────────────────────────────────────
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
