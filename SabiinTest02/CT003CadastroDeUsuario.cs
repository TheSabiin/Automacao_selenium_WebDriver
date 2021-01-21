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
    public class CT003CadastroDeUsuario
    {
        private IWebDriver driver;
        //private WebDriverWait wait;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private CT002ValidarCamposCadastroUsuario cT02;
         

        [SetUp]
        public void SetupTest()
        {
            driver = Comandos.GetBrowserMobile(driver, ConfigurationManager.AppSettings["platform"], "Celular Sabino", ConfigurationManager.AppSettings["browser"], "http://localhost:4723/wd/hub");
            //driver = Comandos.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            baseURL = "https://www.google.com.br";
            verificationErrors = new StringBuilder();
            CT002ValidarCamposCadastroUsuario cT02 = new CT002ValidarCamposCadastroUsuario();
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
        public void TheCT003CadastroDeUsuarioTest()
        {
            //Pré-Requisito: Validade layout da pagina
            


            //Cadastro de usuário
            driver.Navigate().GoToUrl("https://inoveteste.com.br/");
            driver.FindElement(By.XPath("//li[@id='nav-menu-item-6026']/a/span/span/span[2]")).Click();
            driver.FindElement(By.LinkText("Cadastrar")).Click();
            driver.FindElement(By.Id("user_login-5742")).Clear();
            driver.FindElement(By.Id("user_login-5742")).SendKeys(ConfigurationManager.AppSettings["usuário"]);
            driver.FindElement(By.Id("first_name-5742")).Clear();
            driver.FindElement(By.Id("first_name-5742")).SendKeys(ConfigurationManager.AppSettings["nome"]);
            driver.FindElement(By.Id("last_name-5742")).Clear();
            driver.FindElement(By.Id("last_name-5742")).SendKeys(ConfigurationManager.AppSettings["sobrenome"]);
            driver.FindElement(By.Id("user_email-5742")).Clear();
            driver.FindElement(By.Id("user_email-5742")).SendKeys(ConfigurationManager.AppSettings["email"]);
            driver.FindElement(By.Id("user_password-5742")).Clear();
            driver.FindElement(By.Id("user_password-5742")).SendKeys(ConfigurationManager.AppSettings["senha"]);
            driver.FindElement(By.Id("confirm_user_password-5742")).Clear();
            driver.FindElement(By.Id("confirm_user_password-5742")).SendKeys(ConfigurationManager.AppSettings["confirmaSenha"]);
            driver.FindElement(By.XPath("//input[@id='um-submit-btn']")).Click();
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
