Feature: EditEmployee
	As a CEO
	I want to be able to edit employee info

@mytag
Scenario Outline: Edit Employee
	Given I have form for editing data
	When I change <name>, <lastname>, <password>, <email>,
	Then the changes are updated

Examples: 
	| name   | lastname     | password | email           |
	| "Pera" | "Kardashian" | "123"    | "test@test.com" |
