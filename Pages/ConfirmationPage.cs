using OpenQA.Selenium;


namespace CornerstoneDemo.Pages
{
    public class ConfirmationPage
    {
        private readonly IWebDriver driver;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By OrderConfirmation => By.XPath("//div[@class='orderConfirmation']");
        private By ContinueToShopping => By.XPath("//button[@type='submit'][.='Continue Shopping »']");



        public bool IsConfirmationPageDisplayed() => driver.WaitForElement(OrderConfirmation).Displayed;
        public void continueToShopping()
        {
            driver.WaitForElementClickable((ContinueToShopping)).Click();
        }
    }
}
