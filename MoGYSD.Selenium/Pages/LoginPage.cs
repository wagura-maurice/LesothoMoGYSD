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
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.ClassName("error-message");

        public LoginPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl) { }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/login");
            WaitForPageLoad();
        }

        public void Login(string username, string password)
        {
            var usernameField = WaitForElement(_usernameField);
            var passwordField = WaitForElement(_passwordField);
            var loginButton = WaitForElement(_loginButton);
            
            usernameField.Clear();
            usernameField.SendKeys(username);
            passwordField.Clear();
            passwordField.SendKeys(password);
            loginButton.Click();
            
            WaitForPageLoad();
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                return Driver.FindElement(_errorMessage).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}