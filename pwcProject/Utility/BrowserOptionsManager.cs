using System;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace PwCProject
{
    /// <summary>
    /// The BrowserManager class sets the configuration of the different browsers.
    /// </summary>
    public class BrowserOptionsManager
    {
        /// <summary>
        /// The ChromeOptions methods sets the various parameters such as incognito mode, headless mode for Chrome Browser. This also makes use of WebDriver Manager to automatically update the Chromedriver to match with the Chrome Browser version. 
        /// </summary>
        /// <param name="browserMode"></param>
        public static void ChromeOptions(String browserMode)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            if (browserMode == "ChromeHeadless")
            {
                options.AddArgument("headless");
                Browser.driver = new ChromeDriver(options);
            }
            else if (browserMode == "Chrome")
            {
                Browser.driver = new ChromeDriver(options);
            }
        }
    }
}