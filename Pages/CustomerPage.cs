using OpenQA.Selenium;


namespace CornerstoneDemo.Pages
{
    public class CustomerPage
    {
        private readonly IWebDriver driver;
        public CustomerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By Customeremail => By.XPath("//input[@id='email']");
        private By PrivacyPolicy => By.XPath("//label[@for='privacyPolicy']");
        private By CustomerContinue => By.XPath("//button[@id='checkout-customer-continue']");

        public void enterCustomerInfo(string value)
        {
            try
            {
                driver.WaitForElement(Customeremail);
                driver.WaitForElement(Customeremail).SendKeys(value);
                //driver.EntertextViaJs(Customeremail, value + new Random().Next(1, 1000));
                driver.ClickByJs(driver.FindElement(PrivacyPolicy));
                Console.WriteLine(driver.WindowHandles);
                var count = driver.WindowHandles.Count;
                if (count.Equals(2))
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                driver.ClickByJs(driver.FindElement(CustomerContinue));
            }
            catch (Exception){throw;}
        }

    }
}
