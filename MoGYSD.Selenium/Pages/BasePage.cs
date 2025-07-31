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
        protected TestContext TestContext { get; set; }

        protected BasePage(IWebDriver driver, string baseUrl)
        {
            Driver = driver;
            BaseUrl = baseUrl.TrimEnd('/');
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        
        protected void WaitForPageLoad(int timeoutInSeconds = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            
            // Wait for document.readyState
            wait.Until(driver => 
            {
                var result = ((IJavaScriptExecutor)driver)
                    .ExecuteScript("return document.readyState")
                    .ToString()
                    .Equals("complete", StringComparison.OrdinalIgnoreCase);
                
                if (!result)
                {
                    Console.WriteLine($"Document not ready. Ready state: {((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState")}");
                }
                
                return result;
            });
            
            // Additional wait for dynamic content
            Thread.Sleep(1000);
            
            // Additional wait for jQuery if it's used
            try 
            {
                wait.Until(driver => 
                {
                    var jqueryActive = (bool)((IJavaScriptExecutor)driver)
                        .ExecuteScript("return (window.jQuery != null) && (jQuery.active === 0)");
                        
                    if (!jqueryActive)
                    {
                        Console.WriteLine("Waiting for jQuery to be idle...");
                    }
                    
                    return jqueryActive;
                });
            }
            catch (Exception ex) when (ex is WebDriverTimeoutException || ex is WebDriverException)
            {
                Console.WriteLine($"jQuery wait warning: {ex.Message}");
                // Continue if jQuery is not available or times out
            }
        }

        protected IWebElement WaitForElement(By by, int timeoutInSeconds = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            
            try
            {
                // First wait for the element to be present in the DOM
                var element = wait.Until(driver => 
                {
                    try 
                    {
                        var el = driver.FindElement(by);
                        return el.Displayed && el.Enabled ? el : null;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                });

                // Scroll the element into view
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'})", element);
                
                // Small delay to ensure scrolling is complete
                Thread.Sleep(200);
                
                // Take a screenshot for debugging
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotPath = Path.Combine(TestContext.TestRunResultsDirectory, $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);
                TestContext.AddResultFile(screenshotPath);
                
                return element;
            }
            catch (WebDriverTimeoutException ex)
            {
                // Log the current page source for debugging
                var pageSourcePath = Path.Combine(TestContext.TestRunResultsDirectory, $"pagesource_{DateTime.Now:yyyyMMddHHmmss}.html");
                File.WriteAllText(pageSourcePath, Driver.PageSource);
                TestContext.AddResultFile(pageSourcePath);
                
                throw new WebDriverTimeoutException($"Element not found: {by}. Page title: {Driver.Title}", ex);
            }
        }
        
        protected IWebElement WaitForAnyElement(IEnumerable<By> locators, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            
            try
            {
                return wait.Until(driver =>
                {
                    foreach (var locator in locators)
                    {
                        try
                        {
                            var element = driver.FindElement(locator);
                            if (element != null && element.Displayed && element.Enabled)
                            {
                                Console.WriteLine($"Found element with locator: {locator}");
                                return element;
                            }
                        }
                        catch (Exception ex) when (ex is NoSuchElementException || ex is StaleElementReferenceException)
                        {
                            // Continue to next locator
                            continue;
                        }
                    }
                    return null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"None of the elements were found with locators: {string.Join(", ", locators.Select(l => l.ToString()))}");
                return null;
            }
        }
    }
}