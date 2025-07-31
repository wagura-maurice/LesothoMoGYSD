// Tests/LoginTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoGYSD.Selenium.Pages;
using MoGYSD.Selenium.Utils;

namespace MoGYSD.Selenium.Tests
{
    [TestClass]
    public class LoginTests : TestBase
    {
        [TestMethod]
        public void Admin_Can_Login_Successfully()
        {
            // Arrange
            var loginPage = new LoginPage(Driver, BaseUrl);
            loginPage.Navigate();

            // Act
            loginPage.Login(
                Configuration["AppSettings:AdminUsername"],
                Configuration["AppSettings:AdminPassword"]);

            // Assert
            var dashboardPage = new DashboardPage(Driver, BaseUrl);
            Assert.IsTrue(dashboardPage.IsDashboardDisplayed(), "Dashboard was not displayed after login");
        }

        [TestMethod]
        public void Login_Fails_With_Invalid_Credentials()
        {
            // Arrange
            var loginPage = new LoginPage(Driver, BaseUrl);
            loginPage.Navigate();

            // Act
            loginPage.Login("wrong@example.com", "wrongpassword");

            // Assert
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message was not displayed for invalid login");
        }
    }
}