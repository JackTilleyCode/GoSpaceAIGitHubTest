Feature: GitHub
	Github functions

Scenario: User Sign In to github
	Given On sign in page
	When Enter username as "GoSpaceAIInterview"
	When Enter password as "GoSpace123"
	When Click sign in
	Then User should be signed in

Scenario: List repositories
	Given On home page
	Then User should have repositories

Scenario: Create repository
	Given On home page
	When Click new
	When Enter repository name as "New Repo" with key
	When Click create repository
	Then Repository should be created