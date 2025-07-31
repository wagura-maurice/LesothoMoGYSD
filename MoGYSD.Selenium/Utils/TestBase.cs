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
            
            // Basic stability arguments
            options.AddArguments(new List<string>
            {
                "--no-sandbox",
                "--disable-dev-shm-usage",
                "--disable-gpu",
                "--disable-extensions",
                "--disable-notifications",
                "--remote-debugging-port=0",
                "--disable-software-rasterizer",
                "--disable-blink-features=AutomationControlled",
                "--disable-background-networking",
                "--disable-background-timer-throttling",
                "--disable-backgrounding-occluded-windows",
                "--disable-breakpad",
                "--disable-client-side-phishing-detection",
                "--disable-default-apps",
                "--disable-hang-monitor",
                "--disable-popup-blocking",
                "--disable-prompt-on-repost",
                "--disable-sync",
                "--metrics-recording-only",
                "--no-first-run",
                "--password-store=basic",
                "--use-mock-keychain",
                "--disable-renderer-backgrounding",
                "--disable-renderer-throttling",
                "--remote-allow-origins=*",
                "--disable-features=IsolateOrigins,site-per-process",
                "--disable-ipc-flooding-protection",
                "--disable-logging",
                "--log-level=3",
                "--output=/dev/null"
            });

            // Headless mode configuration
            if (bool.Parse(Configuration["AppSettings:Headless"] ?? "true"))
            {
                options.AddArguments(new List<string>
                {
                    "--headless=new",
                    "--window-size=1920,1080",
                    "--disable-gpu-sandbox",
                    "--no-zygote",
                    "--no-sandbox-and-elevated"
                });
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            // Set up ChromeDriver service with logging
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            service.EnableVerboseLogging = true;
            service.LogPath = "chromedriver.log";
            service.EnableAppendLog = true;
            
            // Add environment variables if needed
            var envVars = new System.Collections.Generic.Dictionary<string, object>
            {
                ["DISPLAY"] = ":99",
                ["DBUS_SESSION_BUS_ADDRESS"] = "/dev/null"
            };

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
                
                // Set window size instead of maximize which can be flaky in CI
                try 
                {
                    Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning: Could not set window size: {ex.Message}");
                }
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