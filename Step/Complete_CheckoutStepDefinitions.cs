using BoDi;
using CornerstoneDemo.Pages;
using OpenQA.Selenium;


namespace CornerstoneDemo
{
    [Binding]
    public class Complete_CheckoutStepDefinitions
    {

        HomePage homepage;
        CustomerPage customerpage;
        ShippingPage shippingPage;
        PaymentPage paymentPage;
        ConfirmationPage confirmationPage;
        IWebDriver driver;
        public Complete_CheckoutStepDefinitions(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            homepage = container.Resolve<HomePage>();
            customerpage = container.Resolve<CustomerPage>();
            shippingPage = container.Resolve<ShippingPage>();
            paymentPage = container.Resolve<PaymentPage>();
            confirmationPage = container.Resolve<ConfirmationPage>();
        }

        [Given(@"I navigate to cornerstone-light-demo\.mybigcommerce\.com website")]
        public void GivenINavigateToCornerstone_Light_Demo_Mybigcommerce_ComWebsite()
        {
            homepage.navigateToUrl();
        }

        [Given(@"I Searches product Openhouse and click add to cart button")]
        public void GivenISearchesProductOpenhouseAndClickAddToCartButton()
        {
            homepage.scrollToOpenhouse();
        }

        [Given(@"I click on view or edit your cart")]
        public void GivenIClickOnViewOrEditYourCart()
        {
            homepage.clickCheckOut();
        }

        [Given(@"User Enter valid email '(.*)' click yes and continue")]
        public void GivenUserEnterValidEmailClickYesAndContinue(string email)
        {
            customerpage.enterCustomerInfo(string.Format(email, new Random().Next(0, 100)));
        }

        [Given(@"I enter the following Shipping Address")]
        public void GivenIEnterTheFollowingShippingAddress(Table table)
        {
            shippingPage.EnterShippingDetails(table.Rows[0]["Country"], table.Rows[0]["FirstName"], 
                table.Rows[0]["LastName"], table.Rows[0]["Address"], table.Rows[0]["City"], 
                table.Rows[0]["PostalCode"], table.Rows[0]["PhoneNumber"]);
        }

        [When(@"I enter Payment details")]
        public void WhenIEnterPaymentDetails(Table table)
        {
            paymentPage.EnterShippingDetails(table.Rows[0]["CreditCardNumber"], table.Rows[0]["Expiration"],
                table.Rows[0]["NameonCard"], table.Rows[0]["CVV"]);
        }

        [Then(@"I am presented with a purchase confirmation page for my order")]
        public void ThenIAmPresentedWithAPurchaseConfirmationPageForMyOrder()
        {
            confirmationPage.IsConfirmationPageDisplayed();
            confirmationPage.continueToShopping();
        }
    }
}
