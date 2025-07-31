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
            // Wait for document.readyState
            Wait.Until(driver => 
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            
            // Additional wait for jQuery if it's used
            try 
            {
                Wait.Until(driver => (bool)((IJavaScriptExecutor)driver)
                    .ExecuteScript("return (window.jQuery != null) && (jQuery.active === 0)"));
            }
            catch (Exception)
            {
                // jQuery not available, continue
            }
        }

        protected IWebElement WaitForElement(By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(driver => 
            {
                var element = driver.FindElement(by);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
        }
    }
}