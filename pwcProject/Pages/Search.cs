using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods applicable on the Search page of the website
    /// </summary>
    public class Search : Browser
    {
        private IWebElement _searchMagnifierIcon    => driver.FindElement(By.CssSelector("div.nav-search > button.search-hide"));
        private IWebElement _searchBar              => driver.FindElement(By.CssSelector("input#slimSearch"));
        private By _loader                          => By.CssSelector("div.search-loading");
        private IList<IWebElement> _searchResults   => driver.FindElements(By.CssSelector("div.search-item-body"));

        /// <summary>
        /// Method to Perform a click on the Search Magnifier icon on the top right side of the Home page
        /// </summary>
        public void PerformSearch()
        {
            _searchMagnifierIcon.Click();         
        }

        /// <summary>
        /// Method to search the specific text value provided in the search bar and return true/false if search results display more than 1 article.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>bool</returns>
        public bool CountSearchResults(string searchText)
        {
            _searchBar.SendKeys(searchText);
             WebDriverExtensions.WaitForPageLoad(_loader, 260);       // The search operation is slow which takes apprx time to search from 150-200 sec. So the wait time is higher here. 
            if (_searchResults.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
