using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SabiinTest02.PageObjects
{
    class Cadastro
    {
        private IWebDriver driver;
        //Mapeando elementos da aba Cadastro para serem usados no teste principal

        [FindsBy(How = How.XPath, Using = "//li[@id='nav-menu-item-6026']/a/span/span/span[2]")] //Botão cadastrar
        public IWebElement botao { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cadastrar")]
        public IWebElement cadastrar { get; set; }

        [FindsBy(How = How.Id, Using = "user_login-5742")]
        public IWebElement usuario { get; set; }

        [FindsBy(How = How.Id, Using = "first_name-5742")]
        public IWebElement firstName;

        [FindsBy(How = How.Id, Using = "last_name-5742")]
        public IWebElement lastName;

        [FindsBy(How = How.Id, Using = "user_email-5742")]
        public IWebElement email;

        [FindsBy(How = How.Id, Using = "user_password-5742")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "confirm_user_password-5742")]
        public IWebElement confirmPassword;

        [FindsBy(How = How.Id, Using = "um-submit-btn")]
        public IWebElement botaoCadastrar;

        public void BotaoConfirmarCadastroClick()
        {
            botaoCadastrar.Click();
        }

        public void BotaoCadastrar()
        {
            driver.FindElement(By.LinkText("Cadastrar")).GetAttribute("value");
        }

        public void CampoUsuario()
        {
            usuario.Clear();
        }

    }
}
