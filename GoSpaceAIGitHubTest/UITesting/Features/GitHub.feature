Feature: GitHub
	Github functions

Scenario: Sign in
	Given On sign in page
	When Enter username as "GoSpaceAIInterview"
	When Enter password as "GoSpace123"
	When Click sign in
	Then User should be signed in

Scenario: List repositories
	Given On home page
	When Click profile icon
	When Click your repositories
	Then User should have repositories

Scenario: Create repository
	Given On home page
	When Click new
	When Enter repository name as "NewRepo" with key
	When Click create repository
	Then Repository should be created