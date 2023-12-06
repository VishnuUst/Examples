Feature: LoginAndAddToCartCheckout

This Feature is to test the Login And AddtoCartCheckouts

@End-To-End-Login-And-AddToCart-Checkout
Scenario: User Login And Add a product to the Cart and Checkout
	Given User is in the Swag Lab HomePage
	When User Enter a correct username in the input box '<UserName>'
	And  User Enter a correct password in the input box '<Password>'
	Then User redirect to the Inventory Page
	When User Click on The FirstProduct '<ProductNo>'
	And User Click on the basket icon
	Then User redirect cartPage
	When User click on the checkoutbutton
	Then Redirect to the checkout page
	When User Enter the First Name '<firstName>'
	And  User Enter the Last Name '<lastName>'
	And  User Enter the ZipCode '<zipCode>'
	And User click on the continue Button
	Then User redirect to confirmation page
	When User click on the Finish Button
	Then User redirect to the FinishPage
Examples: 
	| UserName      | Password     | ProductNo | firstName | lastName | zipCode |
	| standard_user | secret_sauce | 2         | Vishnu    | T        | 691583  |
