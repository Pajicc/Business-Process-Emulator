Feature: Logout
	As a User
	I want to be able to logout

Background: 
	Given I am logged in

@mytag
Scenario: Logout
	When I press logout button
	Then I should be logged out
