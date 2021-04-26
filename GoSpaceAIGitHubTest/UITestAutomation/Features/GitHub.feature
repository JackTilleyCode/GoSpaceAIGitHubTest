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