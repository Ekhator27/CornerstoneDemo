﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace CornerstoneDemo
{
    public static class CustomExtensions
    {
        public static bool WaitForDisplay(this IWebDriver driver, IWebElement element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(30)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(x => element).Displayed;
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(30)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public static IWebElement WaitForElementClickable(this IWebDriver driver, By element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(30)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void ClickElement(this IWebDriver Driver, IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public static void ScrollToElement(this IWebDriver Driver, IWebElement element, string option)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"arguments[0].scrollIntoView({option.ToLower()});", element);
        }

        public static void ClickByJs(this IWebDriver Driver, IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"arguments[0].click()", element);
            element.Click();
        }

        public static void SelectFromDropdownByText(this IWebElement? element, string value)
        {
            SelectElement selectCountry = new SelectElement(element);
            selectCountry.SelectByText(value);
        }

    }
}
