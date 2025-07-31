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
            
            // Basic arguments
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--remote-debugging-port=0"); // Use random port
            options.AddArgument("--disable-software-rasterizer");
            options.AddArgument("--disable-features=VizDisplayCompositor");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-background-networking");
            options.AddArgument("--disable-background-timer-throttling");
            options.AddArgument("--disable-backgrounding-occluded-windows");
            options.AddArgument("--disable-breakpad");
            options.AddArgument("--disable-client-side-phishing-detection");
            options.AddArgument("--disable-default-apps");
            options.AddArgument("--disable-hang-monitor");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-prompt-on-repost");
            options.AddArgument("--disable-sync");
            options.AddArgument("--disable-web-resources");
            options.AddArgument("--enable-automation");
            options.AddArgument("--metrics-recording-only");
            options.AddArgument("--no-first-run");
            options.AddArgument("--password-store=basic");
            options.AddArgument("--use-mock-keychain");
            options.AddArgument("--single-process");
            options.AddArgument("--disable-renderer-backgrounding");
            options.AddArgument("--disable-renderer-throttling");
            options.AddArgument("--remote-allow-origins=*");

            // Headless mode configuration
            if (bool.Parse(Configuration["AppSettings:Headless"] ?? "true"))
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--disable-gpu-sandbox");
                options.AddArgument("--no-zygote");
            }

            // Set up ChromeDriver service
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            service.EnableVerboseLogging = true;
            service.EnableAppendLog = true;

            try
            {
                // Initialize ChromeDriver with retry logic
                int maxRetries = 3;
                int retryCount = 0;
                bool success = false;

                while (!success && retryCount < maxRetries)
                {
                    try
                    {
                        Driver = new ChromeDriver(service, options);
                        success = true;
                    }
                    catch (WebDriverException ex) when (ex.Message.Contains("session not created") && retryCount < maxRetries - 1)
                    {
                        retryCount++;
                        Console.WriteLine($"WebDriver initialization failed, retry {retryCount}/{maxRetries}");
                        Thread.Sleep(1000); // Wait before retry
                    }
                }

                if (!success)
                {
                    throw new InvalidOperationException("Failed to initialize ChromeDriver after multiple attempts");
                }

                // Configure timeouts
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing WebDriver: {ex}");
                throw;
            }
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