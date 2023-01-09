using OpenQA.Selenium;


namespace CornerstoneDemo.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Openhouse => driver.FindElement(By.XPath("//a[@href='https://cornerstone-light-demo.mybigcommerce.com/cart.php?action=add&product_id=110']"));
        private By AcceptAllCookies => By.XPath("//button[@class='css-a0j149'][.='Accept All Cookies']");
        private IWebElement CheckoutBtn => driver.FindElement(By.XPath("//a[@href='/checkout']"));                 




        public void navigateToUrl() => driver.Navigate().GoToUrl(Environments.cornerstone_url);

        public void scrollToOpenhouse()
        {
            driver.FindElement(AcceptAllCookies).Click();
            driver.ClickElement(Openhouse);
        }

        public void clickCheckOut() => driver.ClickElement(CheckoutBtn);
    }
}
