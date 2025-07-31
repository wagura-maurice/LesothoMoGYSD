// Utils/TestBase.cs
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace MoGYSD.Selenium.Utils
{
    public class TestBase : IDisposable
    {
        protected IWebDriver Driver { get; private set; } = null!;
        protected IConfiguration Configuration { get; } = null!;
        protected string BaseUrl => Configuration["AppSettings:BaseUrl"] ?? throw new InvalidOperationException("BaseUrl is not configured in appsettings.json");

        public TestBase()
        {
            // Setup configuration
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Setup WebDriver
            // new DriverManager().SetUpDriver(new ChromeConfig());
            // In TestBase.cs constructor, update the Chrome options setup:
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-notifications");

            if (bool.Parse(Configuration["AppSettings:Headless"] ?? "true"))
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }
            
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            try
            {
                Driver.Quit();
                Driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if the driver was already closed
            }
        }

        public TestContext? TestContext { get; set; }

        protected void TakeScreenshot(string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{testName}.png";
                var directory = Path.Combine(AppContext.BaseDirectory, "Screenshots");
                Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, fileName);
screenshot.SaveAsFile(filePath);
                
                if (TestContext != null)
                {
                    TestContext.AddResultFile(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}