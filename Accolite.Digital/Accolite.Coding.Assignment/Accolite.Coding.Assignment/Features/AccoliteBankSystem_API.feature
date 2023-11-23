Feature: AccoliteBankSystem_API

A short summary of the feature

@API
Scenario: Create new bank account
	Given Account Holder name is <AccountName>
	And Deposit money for the account is <Amount>
	And Bank is located in the address <Address>
	And the base url used is <url>
	When POST endpoint is triggered to create a new bank account with the above details
	Then Verify the response code is 200
	And Verify the success message "Account Created Successfully"
	And Verify the response body with the correct account details has been created

Examples: 
| AccountName | Amount | Address | url                                      |
| Sagar       | 10000  | Pune    | "https://www.localhost:8080/api/account" |

@API
Scenario: Delete a existing bank account
	Given Account Holder name is <AccountName>
	And Account number is <AccountNo>
	And the base url used is <url>
	When DELETE endpoint is triggered to delete an existing bank account with the above details
	Then Verify the response code is 200
	And Verify the success message "Account Deleted Successfully"
	And Verify the response body with the correct account details has been deleted

Examples: 
| AccountName | AccountNo  | url                                      |
| Sagar       | 1234567890 | "https://www.localhost:8080/api/account" |
	
@API
Scenario: Deposit an amount in the bank account
	Given Account Holder name is <AccountName>
	And Account number is <AccountNo>
	And Deposit money for the account is <Amount>
	And the base url used is <url>
	When PUT endpoint is triggered to deposit amount in a bank account with the above details
	Then Verify the response code is 200
	And Verify the success message "<Amount> Deposited to an Account <AccountNo> successfully"
	And Verify the response body with the correct account details and new balance

Examples: 
| AccountName | AccountNo  | Amount | url                                      |
| Sagar       | 1234567890 | 1000   | "https://www.localhost:8080/api/account" |

@API
Scenario: Withdraw an amount from the bank account
	Given Account Holder name is <AccountName>
	And Account number is <AccountNo>
	And Withdrawal money from the account is <Amount>
	And the base url used is <url>
	When PUT endpoint is triggered to withdraw amount from bank account with the above details
	Then Verify the response code is 200
	And Verify the success message "<Amount> Withdrawn from an Account <AccountNo> successfully"
	And Verify the response body with the correct account details and new balance

Examples: 
| AccountName | AccountNo  | Amount | url                                      |
| Sagar       | 1234567890 | 1000   | "https://www.localhost:8080/api/account" |