using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace SeleniumPractice
{
    public class Tests
    {
 IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
        
        }
        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");



            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Thread.Sleep(3000);


            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Thread.Sleep(3000);


            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(3000);

            Assert.That(driver.Url, Does.Contain("inventory"));
            Console.WriteLine("Login Succesfull");
        }
        [Test]
        public void Loginfail()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");



            driver.FindElement(By.Id("user-name")).SendKeys("wrong_user");
            Thread.Sleep(3000);


            driver.FindElement(By.Id("password")).SendKeys("wrong_password");

            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(3000);

            var errorMessage = driver.FindElement(By.ClassName("error-message-container"));

            Assert.That(errorMessage.Text, Does.Contain("Username and password do not match"));
        }
        [Test]
        public void EmptyLogin()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            
            driver.FindElement(By.Id("login-button")).Click();

            Thread.Sleep(2000);

            var errorMessage = driver.FindElement(By.ClassName("error-message-container"));

            Assert.That(errorMessage.Text, Does.Contain("Username is required"));

            Console.WriteLine("Empty login validation passed");
        }
        [Test]
        public void LoginWithOnlyUsername()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");

    
            driver.FindElement(By.Id("login-button")).Click();

            Thread.Sleep(2000);

            var errorMessage = driver.FindElement(By.ClassName("error-message-container"));

            Assert.That(errorMessage.Text, Does.Contain("Password is required"));

            Console.WriteLine("Only username validation passed");
        }
        [Test]
        public void LoginWithOnlyPassword()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");

     
            driver.FindElement(By.Id("login-button")).Click();

            Thread.Sleep(2000);

            var errorMessage = driver.FindElement(By.ClassName("error-message-container"));

            Assert.That(errorMessage.Text, Does.Contain("Username is required"));

            Console.WriteLine("Only password validation passed");
        }
        [TearDown]
        public void closeweb()
        {
            driver.Quit();
            driver.Dispose();


        }


    }
}