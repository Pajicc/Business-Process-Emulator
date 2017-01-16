Feature: CreateNewProject
	As a User
	I want to be able to create new project

@mytag
Scenario: Create New Project
	Given I have a form for creating projects
	And I have fill it with data
	When I press create button
	Then the project should be created
