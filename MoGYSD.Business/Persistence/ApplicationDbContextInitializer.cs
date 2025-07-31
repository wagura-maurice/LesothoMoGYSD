using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Persistence;
/// <summary>
/// Initializes the application database with seed data and ensures proper database migration.
/// </summary>
/// <remarks>
/// This class handles:
/// <list type="bullet">
/// <item>Automatic database migrations</item>
/// <item>Core system role creation</item>
/// <item>Default administrator account setup</item>
/// <item>Reference data population</item>
/// </list>
/// </remarks>
/// <param name="context">The application database context</param>
/// <param name="userManager">ASP.NET Core Identity user manager</param>
/// <param name="roleManager">ASP.NET Core Identity role manager</param>
/// <param name="logger">Logger for tracking initialization progress</param>
public class ApplicationDbContextInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager, ILogger<ApplicationDbContextInitializer> logger)
{
    private readonly ApplicationDbContext _context = context;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;

    /// <summary>
    /// Initializes the database asynchronously by applying pending migrations and seeding data.
    /// </summary>
    /// <returns>A task representing the asynchronous operation</returns>
    /// <exception cref="Exception">Thrown when database initialization fails</exception>

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsRelational())
                await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }
    public async Task SeedAsync()
    {
        try
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
            _context.ChangeTracker.Clear();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }
    private async Task SeedRolesAsync()
    {
        const string adminRoleName = "SystemAdministrator";

        if (await _roleManager.RoleExistsAsync(adminRoleName)) return;

        _logger.LogInformation("Seeding role: {Role}", adminRoleName);

        var adminRole = new ApplicationRole(adminRoleName)
        {
            IsActive = true,
            CreatedOn = DateTime.UtcNow
        };

        var result = await _roleManager.CreateAsync(adminRole);
        if (!result.Succeeded)
        {
            _logger.LogError("Role creation failed: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
            return;
        }

    }
    private async Task SeedUsersAsync()
    {
        if (await _userManager.Users.AnyAsync()) return;

        _logger.LogInformation("Seeding users...");
        var adminUser = new ApplicationUser
        {
            UserName = "admin@example.com",
            IsActive = true,
            Email = "admin@example.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            StatusId = 5,
            FirstName = "Admin",
            MiddleName = "Admin",
            Surname = "Admin",
            CreatedOn = DateTime.Now,
            TwoFactorEnabled = false
        };

        await _userManager.CreateAsync(adminUser, "Admin@789");
        await _userManager.AddToRoleAsync(adminUser, "SystemAdministrator");
    }
}
