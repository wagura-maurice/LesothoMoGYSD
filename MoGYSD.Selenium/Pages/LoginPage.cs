// Pages/LoginPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MoGYSD.Selenium.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.CssSelector("button[type='submit'], input[type='submit'], #login-button");
        private readonly By _errorMessage = By.CssSelector(".error-message, .alert-danger, .text-danger, [role='alert']");
        private readonly By _pageTitle = By.CssSelector("h1, h2, h3, .login-title");

        public LoginPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl) 
        {
            Console.WriteLine($"LoginPage initialized with URL: {baseUrl}");
        }

        public void Navigate()
        {
            var loginUrl = $"{BaseUrl.TrimEnd('/')}/login";
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

        public void Login(string username, string password)
        {
            try
            {
                Console.WriteLine($"Attempting login with username: {username}");
                
                // Wait for and interact with username field
                var usernameField = WaitForElement(_usernameField, 10);
                Console.WriteLine("Found username field");
                usernameField.Clear();
                usernameField.SendKeys(username);
                
                // Wait for and interact with password field
                var passwordField = WaitForElement(_passwordField, 10);
                Console.WriteLine("Found password field");
                passwordField.Clear();
                passwordField.SendKeys(password);
                
                // Wait for and click login button
                var loginButton = WaitForElement(_loginButton, 10);
                Console.WriteLine("Found login button");
                
                // Scroll to element and click using JavaScript
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
                Thread.Sleep(500); // Small delay for any animations
                
                // Try clicking with JavaScript if regular click fails
                try
                {
                    loginButton.Click();
                }
                catch
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", loginButton);
                }
                
                Console.WriteLine("Login button clicked, waiting for page load...");
                WaitForPageLoad(20); // Give more time for login to complete
            }
            catch (Exception ex)
            {
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