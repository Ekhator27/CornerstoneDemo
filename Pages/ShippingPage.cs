using OpenQA.Selenium;


namespace CornerstoneDemo.Pages
{
    public class ShippingPage
    {
        private readonly IWebDriver driver;
        public ShippingPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By Selectcountry = By.XPath("//select[@id='countryCodeInput']");
        private By Firstname => By.XPath("//input[@id='firstNameInput']");
        private By Lastname => By.XPath("//input[@id='lastNameInput']");
        private By Address => By.XPath("//input[@id='addressLine1Input']");
        private By City => By.XPath("//input[@id='cityInput']");
        private By Postalcode => By.XPath("//input[@id='postCodeInput']");
        private By Phonenumber => By.XPath("//input[@id='phoneInput']");
        private By Ordercomments => By.XPath("//input[@name='orderComment']");
        private By Continue => By.CssSelector("#checkout-shipping-continue");
        private By FlatRate => By.XPath("//*[@class = 'shippingOption-price']");

        public void EnterShippingDetails(string country, string fristname, string lastname, string address, string city, string postalcode , string phonenumber)
        {
            driver.WaitForElement(Selectcountry);
            var Country = driver.FindElement(Selectcountry);
            Country.SelectFromDropdownByText(country);
            driver.FindElement(Firstname).SendKeys(fristname);
            driver.FindElement(Lastname).SendKeys(lastname);
            driver.FindElement(Address).SendKeys(address);
            driver.FindElement(City).SendKeys(city);
            driver.FindElement(Postalcode).SendKeys(postalcode);
            driver.FindElement(Phonenumber).SendKeys(phonenumber);
            driver.WaitForElement(FlatRate).Text.Equals(10);
            driver.ScrollToElement(driver.FindElement(Continue),
                "true");
            driver.WaitForElementClickable(Continue).Click();
            //driver.ClickByJs(driver.FindElement(Continue));
        }
        
    }
}

