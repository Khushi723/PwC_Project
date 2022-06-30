using OpenQA.Selenium;

namespace PwCProject
{
    /// <summary>
    /// This class provides methods that can be applied to WebElements. 
    /// </summary>
    public class WebElementExtensions : Browser
    {
        /// <summary>
        /// The method makes use of the JavaScriptExecutor to scroll up/down to a particular element on the webpage to view. 
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
