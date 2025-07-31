// Utils/TestHelper.cs
using OpenQA.Selenium;

namespace MoGYSD.Selenium.Utils
{
    public static class TestHelper
    {
        public static bool IsElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver)
                .ExecuteScript("return jQuery.active == 0"));
        }
    }
}