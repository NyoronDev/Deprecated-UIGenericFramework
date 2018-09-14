# Selenium Generic Framework
This framework provides the opportunity to help the people to start a new UI automation project with all the architecture needed to generate tests on multiple platforms (Web, Mobile) using Selenium and Appium. 

The idea of this project is to separate the different layers so that they can be used independently (regardless of the tools that you use to generate the tests and automate the project), maintaining the scalability of the test solution.

Include an example on a real web to see how the architecture works.

## Requirements
- [Visual Studio] (https://visualstudio.microsoft.com/downloads/)
- Visual Studio Extension "Specflow for Visual Studio" (Tools -> Extensions and Updates -> Online -> Specflow)
- [.Net Framework 4.7] (https://www.microsoft.com/en-us/download/details.aspx?id=55168)
- [Appium Server] (http://appium.io/) (If you need run tests with mobile platforms)

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
