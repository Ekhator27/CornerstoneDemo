using OpenQA.Selenium;


namespace CornerstoneDemo.Pages
{
    public class PaymentPage
    {
        private readonly IWebDriver driver;
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By CardNumber = By.XPath("//input[@id='ccNumber']");
        private By Expiration = By.XPath("//input[@id='ccExpiry']");
        private By NameonCard = By.XPath("//input[@id='ccName']");
        private By CVV = By.XPath("//input[@id='ccCvv']");
        private By PlaceOrder = By.CssSelector("#checkout-payment-continue");


        public void EnterShippingDetails(string creditCardNumber, string expiration, string nameonCard, string cvv)
        {
            driver.WaitForElement(CardNumber);
            driver.FindElement(CardNumber).SendKeys(creditCardNumber);
            driver.FindElement(Expiration).SendKeys(expiration);
            driver.FindElement(NameonCard).SendKeys(nameonCard);
            driver.FindElement(CVV).SendKeys(cvv);
            try
            {
                driver.ScrollToElement(driver.WaitForElement(PlaceOrder),
                "true");
                driver.WaitForElementClickable(PlaceOrder).Click();
            }
            catch (Exception){throw;}
        }

    }
}
