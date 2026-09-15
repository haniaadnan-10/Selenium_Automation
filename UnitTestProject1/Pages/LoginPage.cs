using OpenQA.Selenium;

namespace UnitTestProject1.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        // Locators
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By errorMessage = By.CssSelector("[data-test='error']");
        private By productsTitle = By.XPath("//*[@id='header_container']/div[1]/div[2]/div");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Actions
        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }

        // Getters
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }

        public string GetProductsTitle()
        {
            return driver.FindElement(productsTitle).Text;
        }
    }
}
