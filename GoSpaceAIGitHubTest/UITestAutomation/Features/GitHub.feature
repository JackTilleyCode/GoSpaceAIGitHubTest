Feature: GitHub
	Simple calculator for adding two numbers

@mytag
Scenario: User Sign In to github
	Given On sign in page
	When Enter username as "TestAccountGoSpace"
	When Enter password as "NotAPassword1234"
	Then User should be signed in