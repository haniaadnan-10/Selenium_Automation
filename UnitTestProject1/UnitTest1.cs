using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Pages;

namespace TestProject2
{
    [TestClass]
        public class UnitTest1
        {
            public TestContext TestContext { get; set; }

            // Positive Test Case
            [TestMethod]
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                "Data.xml",
                "LoginWithValidUserValidPass",
                DataAccessMethod.Sequential)]

            public void LoginTestcase_With_ValidUsers()
            {
                string url = TestContext.DataRow["url"].ToString();
                string username = TestContext.DataRow["username"].ToString();
                string password = TestContext.DataRow["password"].ToString();

                IWebDriver driver = new ChromeDriver();

                driver.Manage().Window.Maximize();
                driver.Url = url;

                LoginPage loginPage = new LoginPage(driver);

                loginPage.EnterUsername(username);
                loginPage.EnterPassword(password);
                loginPage.ClickLogin();

                string actualText = loginPage.GetProductsTitle();

                Assert.AreEqual("Swag Labs", actualText);

                driver.Quit();
            }


            // Negative Test Case
            [TestMethod]
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                "Data.xml",
                "LoginWithInvalidUserInvalidPass",
                DataAccessMethod.Sequential)]

            public void LoginTestcase_With_InvalidUsers()
            {
                string url = TestContext.DataRow["url"].ToString();
                string username = TestContext.DataRow["username"].ToString();
                string password = TestContext.DataRow["password"].ToString();

                IWebDriver driver = new ChromeDriver();

                driver.Manage().Window.Maximize();
                driver.Url = url;

                LoginPage loginPage = new LoginPage(driver);

                loginPage.EnterUsername(username);
                loginPage.EnterPassword(password);
                loginPage.ClickLogin();

                string actualError = loginPage.GetErrorMessage();

                Assert.AreEqual(
                    "Epic sadface: Username and password do not match any user in this service",
                    actualError
                );

                driver.Quit();
            }
        }
    }


