Feature: Main Features - How to create different tasks
    In order to create different tasks
    As a user
    I want to create tasks

@Story:MainFeatures
@Owner:NyoronDev
@Guid:0A707F62-1C9D-4C14-B25A-005262136597
@CreationDate:2018-09-14
Scenario: Add Task View - Check the values from the task
    Given The user goes to the main page
    And The user goes to create new item
    When The user creates a new task with the following properties:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | Red    |
    Then The testee display the following items:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | red    |

@Story:MainFeatures
@Owner:NyoronDev
@Guid:24AFA554-B7DB-4B16-ACA8-B7C7E8A754D0
@CreationDate:2018-09-14
Scenario: Add Task View - Check the values from different tasks
    Given The user goes to the main page
    When The user creates a group of task with the following properties:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | Red    |
        | Title 2 | This is a content 2 | White  |
        | Title 3 | This is a content 3 | Yellow |
    Then The testee display the following items:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | red    |
        | Title 2 | This is a content 2 | white  |
        | Title 3 | This is a content 3 | yellow |

@Story:MainFeatures
@Owner:NyoronDev
@Guid:0E257D2C-AAD1-4DBC-B831-0957928010D1
@CreationDate:2018-09-14
Scenario: Add Task View - Check the values from the task added from the json file
    Given The user goes to the main page
    And The user goes to create new item
    When The user creates the task 'Json Task'
    Then The testee display the following items:
        | Title     | Content             | Color |
        | Json Task | This is a content 1 | red   |