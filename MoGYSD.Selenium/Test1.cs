namespace MoGYSD.Selenium;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void Admin_Can_Login_Successfully()
    {
        try
        {
            // Arrange
            var loginPage = new LoginPage(Driver, BaseUrl);
            loginPage.Navigate();
            
            // Take screenshot before login
            TakeScreenshot("BeforeLogin");

            // Act
            var username = Configuration["AppSettings:AdminUsername"] ?? "admin";
            var password = Configuration["AppSettings:AdminPassword"] ?? "password";
            loginPage.Login(username, password);

            // Take screenshot after login
            TakeScreenshot("AfterLogin");

            // Assert
            var dashboardPage = new DashboardPage(Driver, BaseUrl);
            Assert.IsTrue(dashboardPage.IsDashboardDisplayed(), "Dashboard was not displayed after login");
        }
        catch (Exception ex)
        {
            TakeScreenshot("TestFailure");
            throw;
        }
    }
}
