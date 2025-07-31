// Pages/BasePage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MoGYSD.Selenium.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        protected readonly string BaseUrl;

        protected BasePage(IWebDriver driver, string baseUrl)
        {
            Driver = driver;
            BaseUrl = baseUrl.TrimEnd('/');
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void WaitForPageLoad()
        {
            Wait.Until(driver => 
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        protected void WaitForElement(By by)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}