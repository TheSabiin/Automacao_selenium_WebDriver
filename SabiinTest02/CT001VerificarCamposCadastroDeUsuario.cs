using System;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SabiinTest02;
using SabiinTest02.PageObjects;
using NUnit.Framework;

namespace SabiinTest02
{
    [TestFixture]
    public class CT001VerificarCamposCadastroDeUsuario
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = Comandos.GetBrowserMobile(driver, ConfigurationManager.AppSettings["platform"], "Celular Sabino", ConfigurationManager.AppSettings["browser"], "http://localhost:4723/wd/hub");
            //driver = Comandos.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCT001VerificarCamposCadastroDeUsuarioTest()
        {
            driver.Navigate().GoToUrl("https://inoveteste.com.br/");
            driver.FindElement(By.XPath("//li[@id='nav-menu-item-6026']/a/span/span/span[2]")).Click();
            driver.FindElement(By.LinkText("Cadastrar")).Click();
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("user_login-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("first_name-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("last_name-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("user_email-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("user_password-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("confirm_user_password-5742")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Cadastrar", driver.FindElement(By.Id("um-submit-btn")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
