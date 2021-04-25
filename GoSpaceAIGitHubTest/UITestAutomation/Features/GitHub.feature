Feature: GitHub
	Simple calculator for adding two numbers

Scenario: User Sign In to github
	Given On sign in page
	When Enter username as "TestAccountGoSpace"
	When Enter password as "NotAPassword1234"
	When Click sign in
	Then User should be signed in