Feature: Login
    In order to check the login

@Story:Login
@InternalTcId:0AAA31D0-AD03-4180-94D2-E93148047844
@Owner:sernajaj
@CreationDate:2018-04-14
@ReviewDate:
@Reviewer:
Scenario: This is a generic feature using a failed login
	Given The user goes to the 'http://demo.guru99.com/v4/index.php' page
	When The user tries to login with the following user
		| UserId   | Password     |
		| fakeUser | fakePassword |
	Then The user cannot login and the 'User or Password is not valid' alert appears

@Story:Login
@InternalTcId:81C2740C-13E8-4A66-B820-ADEA68EE9B86
@Owner:sernajaj
@CreationDate:2018-04-14
@ReviewDate:
@Reviewer:
Scenario: This is another generic feature using a failed login
	Given The user goes to the 'http://demo.guru99.com/v4/index.php' page
	When The user tries to login with the following user
		| UserId      | Password        |
		| anotherUser | anotherPassword |
	Then The user cannot login and the 'User or Password is not valid' alert appears
