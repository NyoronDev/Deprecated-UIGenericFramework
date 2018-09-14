# Selenium Generic Framework
This framework provides the opportunity to help the people to start a new UI automation project with all the architecture needed to generate tests on multiple platforms (Web, Mobile) using Selenium and Appium. 

The idea of this project is to separate the different layers so that they can be used independently (regardless of the tools that you use to generate the tests and automate the project), maintaining the scalability of the test solution.

Include an example on a real web to see how the architecture works.

## Requirements
asdf
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Visual Studio Extension "Specflow for Visual Studio" (Tools -> Extensions and Updates -> Online -> Specflow)
- [.Net Framework 4.7](https://www.microsoft.com/en-us/download/details.aspx?id=55168)
- [Appium Server](http://appium.io/) (If you need run tests with mobile platforms)

## QuickStart
1. Fork the project and open it with Visual Studio
2. Add config.runsettings to Test Settings File (Test -> Test Settings -> Select Test Settings File)
3. Build the solution (you can use Debug and Chrome for Laptop WebBrowser and ChromeAndroid to use Android mobile device)
4. Run tests
5. Explore and change everything you need for your project.

### Configuration Files
**config.runsettings**
- Used to add some parameters that you need to run your tests
- By default the project has "WebSiteURL", modify it to use your web

**App.config**
- Used to build the project with different configurations
- Add the App.config files that you need
- By default the project has "Chrome" and "ChromeAndroid" build configuration

## Architecture
The framework is based on N-Layers architecture (4 layers for the basic project, but you can add more if you need it).

### User Stories Layer
Principal layer of the application, used to write the test cases with Gherkin language (you can use it another test framework if dont need Gherkin).

We have two different folders, **Features** is used to create the Gherkin test cases and **Steps** is used to implement the steps of this gherkins.

Is used **only** to define the different test scenarios, using dependency injection to call the methods used to automate the application.

### Automation Core Layer
Layer with the responsibility to create all the automation workflow. We have two different projects in this layer, **Contracts** and **SeleniumDriver** (if you need more implementations to use other frameworks, you can use the same interfaces and create new solutions)

Contracts project has all the automation core interfaces, which we use to inject the implementation to the Steps (**User Stories Layer**). The purpose of having the interfaces separated from the classes is that you can have different implementations using the same interfaces in order to use the same test cases.

In this project we are using Selenium (or Appium) using the Page Object / Page Factory patterns, we have different "Page" class to separate all the modules.

- Constructor has the webDriver configuration (injected with ISetUp).
- We are using WebDriverWait to see if the element is enabled or not.
- The Page implements the interface and inherit from the base.

### Data Factory
Project used to create the entities used for all the solution in order to create test cases more clear.
If you need to access to the database (or api) to generate data for tests, be free to create here the Factory Pattern and inject it in the solution.

### Cross Layer
All the common parts of the project are created here. At the moment we have the dependency injection (using Unity) to create different containers of the application (at the example only we have one, but if you need to create different implementations add here the other containers).

## Contact
Please, if you have any question / improve be free to send an email to jsernajaen@gmail.com
