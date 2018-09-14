﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace US.AcceptanceTests.Features.Main
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MainFeatures_HowToCreateDifferentTasksFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Main.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Main Features - How to create different tasks", "    In order to create different tasks\r\n    As a user\r\n    I want to create tasks" +
                    "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Main Features - How to create different tasks")))
            {
                global::US.AcceptanceTests.Features.Main.MainFeatures_HowToCreateDifferentTasksFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Task View - Check the values from the task")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Main Features - How to create different tasks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute("NyoronDev")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:MainFeatures")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Guid:0A707F62-1C9D-4C14-B25A-005262136597")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreationDate:2018-09-14")]
        public virtual void AddTaskView_CheckTheValuesFromTheTask()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Task View - Check the values from the task", new string[] {
                        "Story:MainFeatures",
                        "Owner:NyoronDev",
                        "Guid:0A707F62-1C9D-4C14-B25A-005262136597",
                        "CreationDate:2018-09-14"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
    testRunner.Given("The user goes to the main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
    testRunner.And("The user goes to create new item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content",
                        "Color"});
            table1.AddRow(new string[] {
                        "Title 1",
                        "This is a content 1",
                        "Red"});
#line 13
    testRunner.When("The user creates a new task with the following properties:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content",
                        "Color"});
            table2.AddRow(new string[] {
                        "Title 1",
                        "This is a content 1",
                        "red"});
#line 16
    testRunner.Then("The testee display the following items:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Task View - Check the values from different tasks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Main Features - How to create different tasks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute("NyoronDev")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:MainFeatures")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Guid:24AFA554-B7DB-4B16-ACA8-B7C7E8A754D0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreationDate:2018-09-14")]
        public virtual void AddTaskView_CheckTheValuesFromDifferentTasks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Task View - Check the values from different tasks", new string[] {
                        "Story:MainFeatures",
                        "Owner:NyoronDev",
                        "Guid:24AFA554-B7DB-4B16-ACA8-B7C7E8A754D0",
                        "CreationDate:2018-09-14"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
    testRunner.Given("The user goes to the main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content",
                        "Color"});
            table3.AddRow(new string[] {
                        "Title 1",
                        "This is a content 1",
                        "Red"});
            table3.AddRow(new string[] {
                        "Title 2",
                        "This is a content 2",
                        "White"});
            table3.AddRow(new string[] {
                        "Title 3",
                        "This is a content 3",
                        "Yellow"});
#line 26
    testRunner.When("The user creates a group of task with the following properties:", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content",
                        "Color"});
            table4.AddRow(new string[] {
                        "Title 1",
                        "This is a content 1",
                        "red"});
            table4.AddRow(new string[] {
                        "Title 2",
                        "This is a content 2",
                        "white"});
            table4.AddRow(new string[] {
                        "Title 3",
                        "This is a content 3",
                        "yellow"});
#line 31
    testRunner.Then("The testee display the following items:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Task View - Check the values from the task added from the json file")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Main Features - How to create different tasks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute("NyoronDev")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:MainFeatures")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Guid:0E257D2C-AAD1-4DBC-B831-0957928010D1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreationDate:2018-09-14")]
        public virtual void AddTaskView_CheckTheValuesFromTheTaskAddedFromTheJsonFile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Task View - Check the values from the task added from the json file", new string[] {
                        "Story:MainFeatures",
                        "Owner:NyoronDev",
                        "Guid:0E257D2C-AAD1-4DBC-B831-0957928010D1",
                        "CreationDate:2018-09-14"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
    testRunner.Given("The user goes to the main page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
    testRunner.And("The user goes to create new item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
    testRunner.When("The user creates the task \'Json Task\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content",
                        "Color"});
            table5.AddRow(new string[] {
                        "Json Task",
                        "This is a content 1",
                        "red"});
#line 45
    testRunner.Then("The testee display the following items:", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
