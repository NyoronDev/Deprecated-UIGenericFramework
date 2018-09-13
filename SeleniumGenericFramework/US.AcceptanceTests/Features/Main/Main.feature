Feature: Main Features - How to create different tasks
    In order to create different tasks
    As a user
    I want to create tasks

Scenario: Add Task View - Check the values from the task
    Given The user goes to the main page
    And The user goes to create new item
    When The user creates a new task with the following properties:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | Red    |
    Then The testee display the following items:
        | Title   | Content             | Color  |
        | Title 1 | This is a content 1 | red    |

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