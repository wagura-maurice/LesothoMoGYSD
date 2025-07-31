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
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument("--disable-software-rasterizer");
            options.AddArgument("--disable-features=VizDisplayCompositor");
            options.AddArgument("--disable-blink-features=AutomationControlled");

            if (bool.Parse(Configuration["AppSettings:Headless"] ?? "true"))
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }

            // Set up ChromeDriver service
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            Driver = new ChromeDriver(service, options);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
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

        protected void TakeScreenshot(string fileName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var filePath = Path.Combine(TestContext.TestRunResultsDirectory, $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}.png");
                screenshot.SaveAsFile(filePath);
                TestContext.AddResultFile(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}