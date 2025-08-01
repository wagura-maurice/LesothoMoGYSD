// Pages/LoginPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace MoGYSD.Selenium.Pages
{
    public class LoginPage : BasePage
    {
        // Form elements from Login.razor
        private readonly By _systemSelect = By.Id("optionSelect");
        private readonly By _emailField = By.Id("Input.Email");
        private readonly By _passwordField = By.Id("Input.Password");
        private readonly By _captchaField = By.Id("Input.Captcha");
        private readonly By _loginButton = By.CssSelector("button[type='submit']");
        private readonly By _errorMessage = By.CssSelector(".error-message, .alert-danger, .text-danger, [role='alert']");
        private readonly By _pageTitle = By.CssSelector("h1, h2, h3, .login-title");

        public LoginPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl) 
        {
            Console.WriteLine($"LoginPage initialized with URL: {baseUrl}");
        }

        public void Navigate()
        {
            var loginUrl = $"{BaseUrl.TrimEnd('/')}/Account/Login";
            Console.WriteLine($"Navigating to: {loginUrl}");
            
            try
            {
                Driver.Navigate().GoToUrl(loginUrl);
                WaitForPageLoad();
                
                // Verify we're on the login page
                var title = GetPageTitle();
                Console.WriteLine($"Page loaded successfully. Title: '{title}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error navigating to login page: {ex}");
                throw;
            }
        }

        public string GetPageTitle()
        {
            try
            {
                var titleElement = WaitForElement(_pageTitle, 5);
                return titleElement?.Text ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void Login(string email, string password, string captcha = "7544", string system = "MISSA")
        {
            try
            {
                Console.WriteLine($"Attempting login with system: {system}, email: {email}");
                
                // Wait for page to be fully interactive
                WaitForPageLoad();
                
                // Wait for and select system from dropdown
                try
                {
                    var systemElement = WaitForElement(_systemSelect, 15);
                    Console.WriteLine("Found system dropdown");
                    var systemSelect = new SelectElement(systemElement);
                    systemSelect.SelectByValue(system);
                    Console.WriteLine($"Selected system: {system}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to select system '{system}': {ex.Message}", ex);
                }
                
                // Fill in email
                try
                {
                    var emailElement = WaitForElement(_emailField, 10);
                    Console.WriteLine("Found email field");
                    emailElement.Clear();
                    emailElement.SendKeys(email);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to enter email: {ex.Message}", ex);
                }
                
                // Fill in password
                try
                {
                    var passwordElement = WaitForElement(_passwordField, 10);
                    Console.WriteLine("Found password field");
                    passwordElement.Clear();
                    passwordElement.SendKeys(password);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to enter password: {ex.Message}", ex);
                }
                
                // Fill in captcha
                try
                {
                    var captchaElement = WaitForElement(_captchaField, 10);
                    Console.WriteLine("Found captcha field");
                    captchaElement.Clear();
                    captchaElement.SendKeys(captcha);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to enter captcha: {ex.Message}", ex);
                }
                
                // Click login button
                try
                {
                    var loginButton = WaitForElement(_loginButton, 10);
                    Console.WriteLine("Found login button");
                    
                    // Scroll to element
                    try
                    {
                        ((IJavaScriptExecutor)Driver).ExecuteScript(
                            "arguments[0].scrollIntoView({behavior: 'smooth', block: 'center', inline: 'nearest'}});", 
                            loginButton);
                    }
                    catch (Exception scrollEx)
                    {
                        Console.WriteLine($"Warning: Could not scroll to element: {scrollEx.Message}");
                        // Fallback to simple scroll
                        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
                    }
                    
                    // Wait for element to be clickable
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_loginButton));
                    
                    // Try direct click first, then fall back to JavaScript
                    try
                    {
                        loginButton.Click();
                    }
                    catch
                    {
                        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", loginButton);
                    }
                    
                    Console.WriteLine("Login button clicked, waiting for page load...");
                    
                    // Wait for navigation to complete
                    WaitForPageLoad(30);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to click login button: {ex.Message}", ex);
                }
            }
            catch (Exception ex)
            {
                // Take screenshot on error
                try
                {
                    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    var screenshotPath = Path.Combine(Path.GetTempPath(), $"login_error_{DateTime.Now:yyyyMMddHHmmss}.png");
                    screenshot.SaveAsFile(screenshotPath);
                    Console.WriteLine($"Screenshot saved to: {screenshotPath}");
                }
                catch (Exception screenshotEx)
                {
                    Console.WriteLine($"Failed to take screenshot: {screenshotEx.Message}");
                }
                
                Console.WriteLine($"Error during login: {ex}");
                throw;
            }
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                var errorElement = WaitForElement(_errorMessage, 5);
                if (errorElement != null && errorElement.Displayed)
                {
                    Console.WriteLine($"Error message found: {errorElement.Text}");
                    return true;
                }
                return false;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                Console.WriteLine("No error message found");
                return false;
            }
        }
    }
}