using System;
using OpenQA.Selenium;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods applicable on the Subscribe form of the website
    /// </summary>
    public class Subscribe : Browser
    {
        private IWebElement _iframeElementSubscribeForm      => driver.FindElement(By.CssSelector("iframe#sfmcform"));
        private IWebElement _recaptchaFrame                  => driver.FindElement(By.CssSelector("iframe[title = 'reCAPTCHA']"));
        private By _recaptchaFrameLocator                    => By.CssSelector("iframe[title = 'reCAPTCHA']");
        private IWebElement _recaptchaLogo                   => driver.FindElement(By.CssSelector("div.rc-anchor-logo-img"));
        private IWebElement _recaptchaStatusCheckbox         => driver.FindElement(By.CssSelector("span.recaptcha-checkbox"));
        private string _recaptchaStatusMsg = "You are verified";
        private string _recaptchaErrorMsg = "Verification failed";

        /// <summary>
        /// This generalized method inspects the Label WebElements on the Subscribe form up to the required property and returns it.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>IWebElement</returns>
        private IWebElement _inputRequiredField(string fieldName)
        {
            try
            {
                return driver.FindElement(By.CssSelector($"label[for= {fieldName}] span.required"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This generalized method inspects the Label WebElements on the Subscribe form and returns them.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>IWebElement</returns>
        private IWebElement _fieldName(string fieldName)
        {
            try
            {
                return driver.FindElement(By.CssSelector($"label[for= {fieldName}]"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This generalized method inspects the input WebElements on the Subscribe form and returns them.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private IWebElement _inputFieldType(string fieldName)
        {
            try
            {
                return driver.FindElement(By.CssSelector($"input[name = {fieldName}]"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This generalized method inspects the dropdown fields on the Subscribe form and returns them.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>IWebElement</returns>
        private IWebElement _dropdownFieldType(string fieldName)
        {
            try
            {
                return driver.FindElement(By.Id($"{fieldName}"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to get the Title of the Subscribe Page
        /// </summary>
        /// <returns>string</returns>
        public string GetPageTitle()
        {
            return driver.Title;
        }

        /// <summary>
        /// This method switches to the iFrame element present on the top of the Subscribe form
        /// </summary>
        public void SwitchToiFrame()
        {
            driver.SwitchTo().Frame(_iframeElementSubscribeForm);
        }

        /// <summary>
        /// Generalized Method to fetch the inner text of all the fields of Subscribe form
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        public string GetFieldName(string fieldName)
        {
            WebDriverExtensions.ElementToBeClickable(_inputFieldType(fieldName));
            WebElementExtensions.ScrollToElement(_inputFieldType(fieldName));
            return _fieldName(fieldName).Text;
        }

        /// <summary>
        /// Method to get the type of the all the input fields on the Subscribe form
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        public string GetFieldType(string fieldName)
        {
            return _inputFieldType(fieldName).GetAttribute("Type");
        }

        /// <summary>
        /// Method to fetch the is displayed property of the required webelements. 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>bool</returns>
        public bool GetRequiredField(string fieldName)
        {
            return _inputRequiredField(fieldName).Displayed;
        }
         
        /// <summary>
        /// Generalized method to fetch the inner text of the dropdown fields state and country
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        public string GetDropdownFieldNames(string fieldName)
        {
            WebDriverExtensions.ElementToBeClickable(_dropdownFieldType(fieldName));
            WebElementExtensions.ScrollToElement(_dropdownFieldType(fieldName));
            return _fieldName(fieldName).Text;
        }
        
        /// <summary>
        /// Method to fetch the select tagname and returns true if it is fetches the select tag and we declare it as a dropdown field for State and country
        /// </summary>
        /// <param name="fieldName">Accepts the feild name</param>
        /// <returns>returns the boolean type of dropdown</returns>
        public bool GetDropdownType(string fieldName)
        {
            bool fieldType = false;
            WebDriverExtensions.ElementToBeClickable(_dropdownFieldType(fieldName));
            if (_dropdownFieldType(fieldName).TagName == "select")
            {
                fieldType = true;
            }
            return fieldType;
        }

        /// <summary>
        /// Method to click on the Google Recaptcha logo by switching into the Recaptcha frame and applying wait. 
        /// </summary>
        public void ClickReCapcha()
        {
            WebDriverExtensions.FrameToBeAvailableToSwitch(_recaptchaFrameLocator, 40);
            WebDriverExtensions.ElementToBeClickable(_recaptchaLogo, 40);
            System.Threading.Thread.Sleep(4000);
            _recaptchaLogo.Click();
        }

        /// <summary>
        /// After clicking on Recaptcha logo, fetching the checkbox status to confirm if captcha has been verified. 
        /// </summary>
        /// <returns>string</returns>
        public string FetchRecaptchaStatus()
        {
            ClickReCapcha();
            System.Threading.Thread.Sleep(2000);
            if(_recaptchaStatusCheckbox.GetAttribute("aria-checked") == "true")
            {
                return _recaptchaStatusMsg;
            }
            else 
            {
                return _recaptchaErrorMsg;
            }
        }
    }
}
