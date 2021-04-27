Feature: GitHub
	API Testing for github

Scenario: List repos
	Given Authenticated
	Then Request should return a list of repositories