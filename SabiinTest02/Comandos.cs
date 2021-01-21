using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;


namespace SabiinTest02
{
    class Comandos
    {
        #region Browser
        public static IWebDriver GetBrowserLocal(IWebDriver driver, String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();

                    break;

                case "Edge":
                    driver = new EdgeDriver();

                    break;

                case "Internet Explorer":
                    driver = new InternetExplorerDriver();

                    break;

                default:
                    driver = new FirefoxDriver();

                    break;
            }

            return driver;
        }
        public static IWebDriver GetBrowserRemote(IWebDriver driver, String browser, String uri)
        {
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions cap_chrome = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_chrome);

                    break;

                case "Edge":
                    EdgeOptions cap_edge = new EdgeOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_edge);

                    break;

                case "Internet Explorer":
                    InternetExplorerOptions cap_IE = new InternetExplorerOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_IE);

                    break;

                default:
                    FirefoxOptions cap_firefox = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_firefox);

                    break;
            }

            return driver;
        }

        public static IWebDriver GetBrowserMobile(IWebDriver driver, String platform, String deviceName, String browserName, String uri)
        {
            switch (platform)
            {
                case "Android":

                    var cap_android = new ChromeOptions();
                    cap_android.AddAdditionalCapability("browserName", browserName, true);
                    cap_android.AddAdditionalCapability("deviceName", deviceName, true);
                    driver = new AndroidDriver<IWebElement>(new Uri(uri), cap_android);
                    break;

                default:
                    var cap_default = new ChromeOptions();
                    cap_default.AddAdditionalCapability("browserName", browserName, true);
                    cap_default.AddAdditionalCapability("deviceName", deviceName, true);
                    driver = new AndroidDriver<IWebElement>(new Uri(uri), cap_default);
                    break;
            }

            return driver;
        }

        #endregion

        #region Javascript
        public static void ExecuteJavascript(IWebDriver driver, String script)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        #endregion


    }

}
