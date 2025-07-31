using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Persistence;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MoGYSD.Services;
public interface IDBService
{
    string GeneratePassword(int maxSize);
    Task AuditTrail(AuditTrail auditTrail, bool? save = false);
    Task<bool> IsGlobal();
    string DBConnection();
}
public class DBService : IDBService
{
    private readonly ApplicationDbContext _context;
    //  private readonly IHttpContextAccessor _http;
    private ApplicationUser _applicationUser;
    private readonly UserManager<ApplicationUser> _userManager;
    public static IConfigurationRoot Configuration;
    private readonly IConfiguration _configuration;

    public DBService(ApplicationDbContext context, IConfiguration configuration) //IHttpContextAccessor http,
    {
        _context = context;
        _configuration = configuration;
    }

    public string GetUserDisplayName()
        {
            return _applicationUser?.FullName;
        }
    public string GetUserEmail()
    {
        return _applicationUser?.Email;
    }
    public async Task<bool> IsGlobal()
    {
        return await _userManager.IsInRoleAsync(_applicationUser, "Admin");
    }
    public async Task AuditTrail(AuditTrail auditTrail, bool? save = false)
    {
        ////  _applicationUser = _userManager.GetUserAsync(_http.HttpContext.User).Result;

        //if (_applicationUser != null && string.IsNullOrEmpty(auditTrail.UserId))
        //     auditTrail.UserId = _applicationUser.Id;
    // auditTrail.UserAgent = _http.HttpContext.Request.Headers["User-Agent"];
        auditTrail.Date = DateTime.Now;
        auditTrail.RequestIpAddress = await GetExternalIP();
        await _context.AuditTrail.AddAsync(auditTrail);
        if (save == true)
            await _context.SaveChangesAsync();
    }
    private string GetComputerName(string clientIP)
    {
        try
        {
            var hostEntry = Dns.GetHostEntry(clientIP);
            return hostEntry.HostName;
        }
        catch
        {
            return string.Empty;
        }
    }
    private static async Task<string?> GetExternalIP()
    {
        //try
        //{
        //    string externalIP;
        //    externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
        //    externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
        //        .Matches(externalIP)[0].ToString();
        //    return externalIP;
        //}
        //catch { return null; }
        try
        {
            using var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            var response = await httpClient.GetStringAsync("https://checkip.amazonaws.com");
            var ip = response?.Trim();

            // Optional: Validate IP format
            if (Regex.IsMatch(ip, @"^\d{1,3}(\.\d{1,3}){3}$"))
            {
                return ip;
            }

            return null;
        }
        catch (Exception ex)
        {
            // Optional: Log or handle error
            return null;
        }
    
    }       
    public string GeneratePassword(int maxSize)
    {
        var passwords = string.Empty;
        var chArray1 = new char[52];
        var chArray2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^*()_+".ToCharArray();
        var data1 = new byte[1];
        using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            cryptoServiceProvider.GetNonZeroBytes(data1);
            var data2 = new byte[maxSize];
            cryptoServiceProvider.GetNonZeroBytes(data2);
            var stringBuilder = new StringBuilder(maxSize);
            foreach (var num in data2)
                stringBuilder.Append(chArray2[(int)num % chArray2.Length]);
            passwords = stringBuilder.ToString();
            var number = Random("N");
            var upper = Random("S");
            var lower = Random("l");
            passwords += number + upper + lower;
            return passwords;
        }
    }
    public string Random(string type)
    {
        var data2 = new byte[1];
        var passwords = string.Empty;
        switch (type)
        {
            case "N":
                {
                    var charArray = "0123456789";
                    var stringBuilder = new StringBuilder(2);
                    foreach (var num in data2)
                        stringBuilder.Append(charArray[(int)num % charArray.Length]);
                    passwords = stringBuilder.ToString();
                    return passwords;
                }

            case "l":
                {
                    var charArray = "abcdefghijklmnopqrstuvwxyz";

                    var stringBuilder = new StringBuilder(2);
                    foreach (var num in data2)
                        stringBuilder.Append(charArray[(int)num % charArray.Length]);
                    passwords = stringBuilder.ToString();
                    return passwords;
                }

            case "C":
                {
                    var charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                    var stringBuilder = new StringBuilder(2);
                    foreach (var num in data2)
                        stringBuilder.Append(charArray[(int)num % charArray.Length]);
                    passwords = stringBuilder.ToString();
                    return passwords;
                }

            case "S":
                {
                    var charArray = "!@#$%^&*()_+-={}|[]:;<>?,./";
                    var stringBuilder = new StringBuilder(2);
                    foreach (var num in data2)
                        stringBuilder.Append(charArray[(int)num % charArray.Length]);
                    passwords = stringBuilder.ToString();
                    return passwords;
                }
        }

        return string.Empty;
    }
    public string DBConnection()
    {

        try
        {


        string connectionstring = _configuration["ConnectionStrings:DefaultConnection"];
            return connectionstring;
        }
        catch
        {
            return "";
        }
    }
}

