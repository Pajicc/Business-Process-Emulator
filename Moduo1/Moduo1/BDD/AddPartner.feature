Feature: AddPartner
	As a CEO
	I want to be able to make partners

@mytag
Scenario: Add Partner
	Given I have form for choosing company
	When I press button
	Then the outsorcing company should be contacted with request
