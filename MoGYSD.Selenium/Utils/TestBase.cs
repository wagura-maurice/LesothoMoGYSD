// Utils/TestBase.cs
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MoGYSD.Selenium.Utils
{
    public class TestBase : IDisposable
    {
        protected IWebDriver Driver { get; private set; }
        protected IConfiguration Configuration { get; }
        protected string BaseUrl => Configuration["AppSettings:BaseUrl"];

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

        protected void TakeScreenshot(string testName)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{testName}.png";
            var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            screenshot.SaveAsFile(filePath);
            TestContext.AddTestAttachment(filePath);
        }
    }
}