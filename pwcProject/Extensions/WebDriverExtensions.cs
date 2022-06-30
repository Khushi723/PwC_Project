using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PwCProject
{
    /// <summary>
    /// WebDriverExtensions class contains all the Explicit wait methods that can be applied to a WebDriver to wait under the specified conditions. 
    /// </summary>
    public class WebDriverExtensions : Browser
    {   
        /// <summary>
        /// This method makes WebDriver explicitly wait for the specified time until a particular webElement is visible on the webpage
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement ElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        /// <summary>
        /// This method makes WebDriver explicitly wait for the specified time until a particular webElement is in a clickable position
        /// </summary>
        /// <param name="element"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement ElementToBeClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement elemnt = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return elemnt;
        }

        /// <summary>
        /// This is an overloaded method which takes an additional argument of timeinsec to be provided by user makes WebDriver explicitly wait for the specified time to be in a clickable position if takes more time to load than usual.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOutInSec"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement ElementToBeClickable(IWebElement element, int timeOutInSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSec));
            IWebElement elemnt = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return elemnt;
        }

        /// <summary>
        /// This method makes WebDriver wait until a particular webElement such as Loader gets invisible and WebPage gets fully loaded. 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOutInSec"></param>
        /// <returns>Boolean</returns>
        public static Boolean WaitForPageLoad(By locator, int timeOutInSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSec));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
            return element;
        }

        /// <summary>
        /// This method makes WebDriver wait until an iFrame is available to be switched to it. 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOutInSec"></param>
        /// <returns>IWebDriver</returns>
        public static IWebDriver FrameToBeAvailableToSwitch(By locator, int timeOutInSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSec));
            var drivr = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
            return drivr;
        }
    }
}
