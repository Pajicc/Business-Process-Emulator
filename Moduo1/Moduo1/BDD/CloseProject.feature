Feature: CloseProject
	As a PO
	I want to be able to close project that have all finished UserStories

Background: 
	Given I am logged in as a PO

@mytag
Scenario: Close Project
	Given I have a form for choosing project for closing
	And I have select it
	When I press close button
	Then the project should be changed
