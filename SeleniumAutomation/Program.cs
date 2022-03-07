using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Automation
{
    internal class Program
    {

        IWebDriver webDriver = new ChromeDriver();

        static void Main(string[] args)
        {
            

        }

        [SetUp]
        public void Initialize()
        {
            webDriver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [Test]
        public void executeTest()
        {
            webDriver.Manage().Window.Maximize();

            IWebElement CreateNewAccount = webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[5]/a"));

            CreateNewAccount.Click();

            Thread.Sleep(2000);

            IWebElement firstName = webDriver.FindElement(By.Name("firstname"));
            firstName.SendKeys("John");

            IWebElement lastName = webDriver.FindElement(By.Name("lastname"));
            lastName.SendKeys("Wick");

            IWebElement email = webDriver.FindElement(By.Name("reg_email__"));
            email.SendKeys("asdafasdaf@bfg.bvg");

            IWebElement confirmEmail = webDriver.FindElement(By.Name("reg_email_confirmation__"));
            confirmEmail.SendKeys("asdafasdaf@bfg.bvg");

            IWebElement password = webDriver.FindElement(By.Name("reg_passwd__"));
            password.SendKeys("myawesomepassword");

            IWebElement day = webDriver.FindElement(By.Id("day"));
            var SelectElementDay = new SelectElement(day);
            SelectElementDay.SelectByValue("20");

            IWebElement month = webDriver.FindElement(By.Id("month"));
            var SelectElementMonth = new SelectElement(month);
            SelectElementMonth.SelectByValue("1");

            IWebElement year = webDriver.FindElement(By.Id("year"));
            var SelectElementYear = new SelectElement(year);
            SelectElementYear.SelectByValue("2000");

            IWebElement genderButton = webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[7]/span/span[2]/input"));
            genderButton.Click();

            IWebElement SignUpButton = webDriver.FindElement(By.Name("websubmit"));
            SignUpButton.Click();

            Thread.Sleep(5000);

            IWebElement ErrorMessage = webDriver.FindElement(By.Id("reg_error_inner"));
            Assert.That(ErrorMessage.Text.Contains("It looks like you may have entered an incorrect email address. Please correct it if necessary, then click to continue."));

            Thread.Sleep(2000);

        }


        [TearDown]
        public void closeTest()
        {
            webDriver.Close();
        }
    }
}
