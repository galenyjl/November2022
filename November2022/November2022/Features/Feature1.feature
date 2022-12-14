Feature: TMFeature

As a Trunup portal user
I would like to create, edit time and material records
So that I can manage employees' time and materials successfully

Scenario: Create time and material record with valid details
	Given I logged into turn up portal successfully
	When I navigate to Time and Material page
	And I create a new Time and Material record
	Then The record should be created successfully

Scenario Outline: Edit existing time record with valid details
	Given I logged into turn up portal successfully
	When I navigate to Time and Material page
	And I update '<Description>', '<Code>', '<Price>' on an existing time record
	Then The record should have the updated '<Description>', '<Code>' and '<Price>'

Examples: 
| Description  | Code     | Price |
| Time         | Galen    | 20    |
| Material     | Keyboard | 100   |
| EditedRecord | Mouse    | 1500  |
