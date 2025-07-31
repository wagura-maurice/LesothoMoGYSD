// Pages/DashboardPage.cs
using OpenQA.Selenium;

namespace MoGYSD.Selenium.Pages
{
    public class DashboardPage : BasePage
    {
        // Common dashboard element selectors
        private readonly By _welcomeMessage = By.CssSelector("#welcome-message, .welcome-message, [data-test='welcome-message']");
        private readonly By _dashboardTitle = By.CssSelector("h1.dashboard-title, h1, .page-title, [data-test='dashboard-title']");
        private readonly By _dashboardContent = By.CssSelector(".dashboard, [data-test='dashboard'], #main-content");
        private readonly By _userMenu = By.CssSelector(".user-menu, [data-test='user-menu'], .dropdown-toggle");

        public DashboardPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl) 
        {
            Console.WriteLine("DashboardPage initialized");
        }

        public bool IsDashboardDisplayed(int timeoutInSeconds = 15)
        {
            try
            {
                Console.WriteLine("Checking if dashboard is displayed...");
                
                // Wait for any of the dashboard indicators to be present
                var dashboardElement = WaitForAnyElement(
                    new[] { _dashboardTitle, _dashboardContent, _userMenu },
                    timeoutInSeconds);
                
                if (dashboardElement == null)
                {
                    Console.WriteLine("No dashboard elements found");
                    return false;
                }

                Console.WriteLine($"Found dashboard element: {dashboardElement.TagName} with classes: {dashboardElement.GetAttribute("class")}");
                
                // Take a screenshot for debugging
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotPath = Path.Combine(TestContext.TestRunResultsDirectory, $"dashboard_{DateTime.Now:yyyyMMddHHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);
                TestContext.AddResultFile(screenshotPath);
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if dashboard is displayed: {ex}");
                return false;
            }
        }

        public string GetWelcomeMessage()
        {
            try
            {
                var element = WaitForElement(_welcomeMessage, 10);
                return element?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting welcome message: {ex}");
                return string.Empty;
            }
        }
        
        public string GetPageTitle()
        {
            try
            {
                var titleElement = WaitForElement(_dashboardTitle, 5);
                return titleElement?.Text ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        
        public bool IsUserMenuDisplayed()
        {
            try
            {
                var element = WaitForElement(_userMenu, 5);
                return element?.Displayed ?? false;
            }
            catch
            {
                return false;
            }
        }
    }
}