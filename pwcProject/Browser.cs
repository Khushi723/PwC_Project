using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Firefox;

namespace PwCProject
{
    /// <summary>
    /// As per the name, this class contains the methods to initilize the browser and other settings and navigates the user to the specified URL. 
    /// </summary>
    public class Browser
    {
        public static IWebDriver driver;
        /// <summary>
        /// This this class contains the method to initilize the browser, maximizes and deletes the cookies based on the choice of browser provided by user in the configuration file. 
        /// </summary>
        /// <param name="browserName"></param>
        public static void Initialization(string browserName)
        {
            switch (browserName)
            {
                case "ChromeHeadless":
                    BrowserOptionsManager.ChromeOptions(browserName);
                    break;
                case "Chrome":
                    BrowserOptionsManager.ChromeOptions(browserName);
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                    driver.Manage().Cookies.DeleteAllCookies();
                    break;
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    driver.Manage().Cookies.DeleteAllCookies();
                    break;
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                    driver.Manage().Cookies.DeleteAllCookies();
                    break;
            }
        }
        /// <summary>
        /// Helps user to navigate to the URL specified in the configuration file. 
        /// </summary>
        /// <param name="_url"></param>
        public static void GoToUrl(String _url)
        {
            driver.Navigate().GoToUrl(_url);
        }
    }
}
