// Pages/DashboardPage.cs
using OpenQA.Selenium;

namespace MoGYSD.Selenium.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly By _welcomeMessage = By.Id("welcome-message");
        private readonly By _dashboardTitle = By.CssSelector("h1.dashboard-title");

        public DashboardPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl) { }

        public bool IsDashboardDisplayed()
        {
            try
            {
                return Driver.FindElement(_dashboardTitle).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetWelcomeMessage()
        {
            return Driver.FindElement(_welcomeMessage).Text;
        }
    }
}