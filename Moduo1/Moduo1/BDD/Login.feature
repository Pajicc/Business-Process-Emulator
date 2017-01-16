Feature: Login
	As an User 
	I want to be able to log in


@mytag
Scenario Outline: Valid LogIn
	Given I have form to log in
	When I enter valid <username> and <password> as
	Then I should be logged in successfully

	Examples: 
	| username | password |
	| "test"   | "test"   |

Scenario Outline: Invalid LogIn
	Given I have form to log in
	When I enter wrong <username> or <password> as
	Then I should be warned

	Examples: 
	| username | password |
	| "test"   | "safaga" |
