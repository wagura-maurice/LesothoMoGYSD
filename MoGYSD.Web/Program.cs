using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Persistence;
using MoGYSD.Services;
using MoGYSD.Services.Extensions;
using MoGYSD.Services.Interfaces;
using MoGYSD.Services.Repository;
using MoGYSD.ViewModels;
using MoGYSD.Web.Components;
using MoGYSD.Web.Components.Account;
using MudBlazor.Services;
using MudExtensions.Services;

namespace MoGYSD.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<LoadingService>();
            builder.Services.AddScoped<IDBService, DBService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ApplicationDbContextInitializer>();
            builder.Services.AddScoped<IGenericRepository, GenericRepository<ApplicationDbContext>>();
            builder.Services.AddScoped<IGenericService, GenericService>();
            builder.Services.AddScoped(typeof(ISearchService<>), typeof(SearchService<>));
            builder.Services.AddScoped<ISearchServiceFactory, SearchServiceFactory>();
            builder.Services.AddScoped(typeof(ISystemCodeSearchService), typeof(SystemCodeSearchService));
            builder.Services.AddTransient<GenericService>();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddServerSideBlazor()
                    .AddCircuitOptions(options => options.DetailedErrors = true);
            builder.Services.AddScoped<IApprovalService, ApprovalService>();
            builder.Services.AddMudServices();
            builder.Services.AddMudExtensions();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUploadService, UploadService>();
            builder.Services.AddScoped<ISentenceCaseService, SentenceCaseService>();
            builder.Services.AddScoped<IStringProcessingService, StringProcessingService>();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
            builder.Services.AddScoped<UserProfileService>();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                // Password settings
                //options.Password.RequireDigit = true;
                //options.Password.RequiredLength = 8;
                //options.Password.RequireNonAlphanumeric = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // or from constant
                options.Lockout.MaxFailedAccessAttempts = 5; // or from constant
                options.Lockout.AllowedForNewUsers = true;

                // Sign-in settings
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false; // true when go live.

                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
            builder.Services.AddScoped<RoleManager<ApplicationRole>>();

            // Register your custom claims principal factory
            builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomUserClaimsPrincipalFactory>();

            // Register authentication and Identity cookies
            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
                })
                .AddIdentityCookies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles(); 

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllers();

            app.UseAntiforgery();
            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();
            //await app.InitializeDatabaseAsync().ConfigureAwait(false);
            app.Run();
        }
    }

}
