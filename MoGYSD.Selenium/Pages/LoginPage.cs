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
                
                // Select system from dropdown
                var systemSelect = new SelectElement(WaitForElement(_systemSelect, 10));
                Console.WriteLine("Found system dropdown");
                systemSelect.SelectByValue(system);
                
                // Fill in email
                var emailField = WaitForElement(_emailField, 10);
                Console.WriteLine("Found email field");
                emailField.Clear();
                emailField.SendKeys(email);
                
                // Fill in password
                var passwordField = WaitForElement(_passwordField, 10);
                Console.WriteLine("Found password field");
                passwordField.Clear();
                passwordField.SendKeys(password);
                
                // Fill in captcha
                var captchaField = WaitForElement(_captchaField, 10);
                Console.WriteLine("Found captcha field");
                captchaField.Clear();
                captchaField.SendKeys(captcha);
                
                // Click login button
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