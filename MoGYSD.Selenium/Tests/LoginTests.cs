// Tests/LoginTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoGYSD.Selenium.Pages;
using MoGYSD.Selenium.Utils;
using System;

namespace MoGYSD.Selenium.Tests
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginTests : TestBase
    {
        private LoginPage _loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _loginPage = new LoginPage(Driver, BaseUrl);
            _loginPage.Navigate();
        }

        [TestMethod]
        [TestProperty("TestType", "Smoke")]
        public void Admin_Can_Login_Successfully()
        {
            // Arrange
            var username = Configuration["AppSettings:AdminUsername"] ?? throw new InvalidOperationException("AdminUsername is not configured");
            var password = Configuration["AppSettings:AdminPassword"] ?? throw new InvalidOperationException("AdminPassword is not configured");
            var system = Configuration["AppSettings:AdminSystem"] ?? "MISSA";
            var captcha = Configuration["AppSettings:AdminCaptcha"] ?? "7544";
            
            // Act
            _loginPage.Login(username, password, captcha, system);

            // Assert
            var dashboardPage = new DashboardPage(Driver, BaseUrl);
            Assert.IsTrue(dashboardPage.IsDashboardDisplayed(), "Dashboard was not displayed after successful login");
        }

        [TestMethod]
        public void Login_Fails_With_Invalid_Credentials()
        {
            // Act - Using default system (MISSA) and captcha (7544) values
            _loginPage.Login("wrong@example.com", "wrongpassword");

            // Assert
            Assert.IsTrue(_loginPage.IsErrorMessageDisplayed(), "Error message was not displayed for invalid credentials");
        }

        [TestMethod]
        public void Login_Fails_With_Empty_Credentials()
        {
            // Act - Submit form with empty credentials
            _loginPage.Login(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_loginPage.IsErrorMessageDisplayed(), "Error message was not displayed for empty credentials");
        }

        [TestMethod]
        public void Login_Fails_With_Invalid_Captcha()
        {
            // Arrange
            var username = Configuration["AppSettings:AdminUsername"] ?? "test@example.com";
            var password = Configuration["AppSettings:AdminPassword"] ?? "password";
            
            // Act - Using invalid captcha
            _loginPage.Login(username, password, "WRONG");

            // Assert
            Assert.IsTrue(_loginPage.IsErrorMessageDisplayed(), "Error message was not displayed for invalid captcha");
        }

        [TestMethod]
        public void Login_With_Different_System_Selection()
        {
            // Arrange
            var username = Configuration["AppSettings:AdminUsername"] ?? "test@example.com";
            var password = Configuration["AppSettings:AdminPassword"] ?? "password";
            var captcha = Configuration["AppSettings:AdminCaptcha"] ?? "7544";
            
            // Act - Test with NISSA system
            _loginPage.Login(username, password, captcha, "NISSA");

            // Assert
            var dashboardPage = new DashboardPage(Driver, BaseUrl);
            Assert.IsTrue(dashboardPage.IsDashboardDisplayed(), "Dashboard was not displayed after login with NISSA system");
        }
}