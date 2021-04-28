Feature: GitHub
	API Testing for github

Scenario: List repos
	Given Authenticated
	When Send request to get repos
	Then Repositories should be listed

Scenario: Check new repo exists
	Given Authenticated
	When Send request to get repos
	Then New repo should exist

Scenario: Create repo
	Given Authenticated using octokit
	When Send request to create repo
	Then Repo should be created

Scenario: Delete repo
	Given Authenticated
	When Send request to delete repo
	Then Repo should be deleted
