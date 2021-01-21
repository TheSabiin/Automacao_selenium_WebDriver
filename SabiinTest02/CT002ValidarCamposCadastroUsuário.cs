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
    public class CT002ValidarCamposCadastroUsuario
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
            baseURL = "https://google.com.br/";
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
        public void TheCT002ValidarCamposCadastroUsuarioTest()
        {
            driver.Navigate().GoToUrl("https://inoveteste.com.br/");
            driver.FindElement(By.XPath("//i[@class='menu_icon fa-lock fa']")).Click();
            driver.FindElement(By.LinkText("Cadastrar")).Click();
            driver.FindElement(By.Id("um-submit-btn")).Click();
            Assert.AreEqual("Usuário é obrigatório", driver.FindElement(By.XPath("//div[@id='um_field_5742_user_login']/div[3]")).Text);
            Assert.AreEqual("Você deve fornecer seu email", driver.FindElement(By.XPath("//div[@id='um_field_5742_user_email']/div[3]")).Text);
            Assert.AreEqual("Senha é obrigatório", driver.FindElement(By.XPath("//div[@id='um_field_5742_user_password']/div[3]")).Text);
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
