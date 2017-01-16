Feature: AddNewEmployee
	As a CEO
	I want to be able to register new employees

Background: 
	Given I am logged in as a CEO

@mytag
Scenario Outline: Add New Employee
		Given I have a form for filling up employee data
		When I enter <username>, <password>, <name>, <lastname>, <email>,
		Then the new employee should be added

	Examples: 
		| username | password | name    | lastname  | email           |
		| "idemo"  | "radimo" | "Joca"  | "Skljoca" | "test@test.com" |
		| "sf"     | "sf"     | "Bogut" | "JOhn"    | "bogut@nba.com" |
