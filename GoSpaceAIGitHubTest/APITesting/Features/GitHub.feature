Feature: GitHub
	API Testing for github

Scenario: List repos
	Given Authenticated
	When Send request to get repos
	Then Repositories should be listed

Scenario: Delete repo
	Given Authenticated
	When Send request to delete repo
	Then Repo should be deleted
