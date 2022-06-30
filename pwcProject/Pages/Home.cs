using System.Collections.Generic;
using OpenQA.Selenium;
using System;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods which are applicable on the Home page of the website.
    /// </summary>
    public class Home : Browser
    {
       private IWebElement subscribeLink   => driver.FindElement(By.CssSelector("a[aria-controls = 'subscribe-subnav-4']"));
        /// <summary>
        /// A generalized method to count the number of articles based on the input columnname provided by the user in the test class
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>int</returns>
        public int CountArticlesInColumns(string columnName)
        {
                return (_articlesColumns(columnName)).Count;
        }

        /// <summary>
        /// Method to perform a click on the Subscribe link on the top header menu of the Home page
        /// </summary>
        public void ClickSubscribe()
        {
            subscribeLink.Click();
        }

        #region Private methods
        /// <summary>
        /// This is a generalized method to inspect the column elements on the webpage based on the input columnname in the test class. 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>IList</returns>
        private IList<IWebElement> _articlesColumns(string columnName)
        {
            try
            {
                return driver.FindElements(By.CssSelector($"div.collectionv2__content > div.headline_{columnName} > article"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
