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
        public TestContext? TestContext { get; set; }

        protected TestBase()
        {
            // TestContext will be set by MSTest after constructor but before test methods
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
            
            // Set up logging directory
            string logDirectory;
            try
            {
                logDirectory = TestContext?.TestRunResultsDirectory ?? 
                             Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
                Directory.CreateDirectory(logDirectory);
                
                service.LogPath = Path.Combine(logDirectory, $"chromedriver_{DateTime.Now:yyyyMMddHHmmss}.log");
                service.EnableAppendLog = false; // Use separate log files for each test run
                Console.WriteLine($"ChromeDriver log will be written to: {service.LogPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not set up logging directory: {ex.Message}");
                service.LogPath = Path.Combine(Path.GetTempPath(), $"chromedriver_{Guid.NewGuid()}.log");
                service.EnableAppendLog = false;
            }
            
            // Add environment variables if needed
            try {
                Environment.SetEnvironmentVariable("DISPLAY", ":99");
                Environment.SetEnvironmentVariable("DBUS_SESSION_BUS_ADDRESS", "/dev/null");
                
                // Additional environment variables for Chrome stability
                Environment.SetEnvironmentVariable("CHROME_DRIVER_LOG_LEVEL", "INFO");
                Environment.SetEnvironmentVariable("CHROME_DRIVER_LOG_PATH", service.LogPath);
                
                Console.WriteLine("Environment variables set for ChromeDriver");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not set environment variables: {ex.Message}");
            }

            try
            {
                // Initialize ChromeDriver with retry logic
                int maxRetries = 3;
                int retryCount = 0;
                bool success = false;
                Exception lastException = null;

                while (!success && retryCount < maxRetries)
                {
                    try
                    {
                        Console.WriteLine($"Initializing ChromeDriver (attempt {retryCount + 1}/{maxRetries})...");
                        Driver = new ChromeDriver(service, options);
                        
                        // Verify the driver is working
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        Driver.Navigate().GoToUrl("about:blank");
                        
                        success = true;
                        Console.WriteLine("ChromeDriver initialized successfully");
                    }
                    catch (Exception ex) when (retryCount < maxRetries - 1)
                    {
                        lastException = ex;
                        retryCount++;
                        Console.WriteLine($"WebDriver initialization failed: {ex.Message}");
                        Console.WriteLine($"Retrying in 2 seconds... (attempt {retryCount + 1}/{maxRetries})");
                        Thread.Sleep(2000); // Wait before retry
                        
                        // Clean up any remaining Chrome processes
                        try { Driver?.Quit(); } catch { }
                        try { Driver?.Dispose(); } catch { }
                        Driver = null;
                    }
                }

                if (!success)
                {
                    throw new InvalidOperationException("Failed to initialize ChromeDriver after multiple attempts", lastException);
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