using NUnit.Framework;

namespace PwCProject
{
    /// <summary>
    /// This class is the base of the Test Classes as this class contains OneTimeSetUp and OneTimeTearDown methods to be called every time once after each TestClass. 
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// This method is called at the start of every testclass, to call the Browser class methods Initialization (to initialize the webdriver instance and open the browser) and GoToURL method to pass the URL 
        /// </summary>
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Browser.Initialization((ConfigSettings.InitConfig().GetSection("Configuration"))["BrowserName"]);
            Browser.GoToUrl((ConfigSettings.InitConfig().GetSection("Configuration"))["URL"]);
        }

        /// <summary>
        /// This method is called at the end of each Test Class and closes the driver instance. 
        /// </summary>

        [OneTimeTearDown]
        public static void Close()
        {
            Browser.driver.Quit();
        }
    } 
}

