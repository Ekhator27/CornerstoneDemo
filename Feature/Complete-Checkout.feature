Feature: Complete-Checkout

As A User I should being able to Searches for a product Adds that product to the cart
Completes the checkout process

Background: 
      Given I navigate to cornerstone-light-demo.mybigcommerce.com website

@cornerstonedemo
Scenario: Searches for a product and Completes the checkout
    And I Searches product Openhouse and click add to cart button
	And I click on view or edit your cart
	And User Enter valid email 'ekhatordestiny9@gmail.com' click yes and continue
	And I enter the following Shipping Address
	| Country        | FirstName | LastName | Address        | City        | PostalCode | PhoneNumber |
	| United Kingdom | Destiny   | Barry    | 69 Bath street | Southampton | SO14 0DG   | 07708481599 |
	When I enter Payment details
	| CreditCardNumber    | Expiration | NameonCard | CVV |
	| 4111 1111 1111 1111 | 10/25      | D Sam      | 123 |
	Then I am presented with a purchase confirmation page for my order

