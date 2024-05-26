namespace HexalithApp.Server;

using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

using HexalithApp.Server.Components;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = ServerSideClientAppHelper.CreateServerSideClientApplication(
            "HexalithApp",
            "Hexalith",
            "1.0.0",
            registerActors: _ => { },
            args);

        //// Add services to the container.
        // _ = builder.Services.AddRazorComponents()
        //    .AddInteractiveServerComponents()
        //    .AddInteractiveWebAssemblyComponents();
        // _ = builder.Services.AddFluentUIComponents();

        // _ = builder.Services.AddCascadingAuthenticationState();
        // _ = builder.Services.AddScoped<IdentityUserAccessor>();
        // _ = builder.Services.AddScoped<IdentityRedirectManager>();
        // _ = builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

        // _ = builder.Services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        //        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        //    })
        //    .AddIdentityCookies();

        // string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        // _ = builder.Services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(connectionString));
        // _ = builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // _ = builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddSignInManager()
        //    .AddDefaultTokenProviders();

        // _ = builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
        WebApplication app = builder.Build();
        _ = app.UseHexalithWebApplication<_Imports>();

        //// Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //    app.UseWebAssemblyDebugging();
        //    _ = app.UseMigrationsEndPoint();
        // }
        // else
        // {
        //    _ = app.UseExceptionHandler("/Error");

        // // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    _ = app.UseHsts();
        // }

        // _ = app.MapSwagger();

        // _ = app.UseHttpsRedirection();

        // _ = app.UseStaticFiles();
        // _ = app.UseAntiforgery();

        // _ = app.MapRazorComponents<App>()
        //    .AddInteractiveServerRenderMode()
        //    .AddInteractiveWebAssemblyRenderMode()
        //    .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        //// Add additional endpoints required by the Identity /Account Razor components.
        // _ = app.MapAdditionalIdentityEndpoints();
        app.Run();
    }
}