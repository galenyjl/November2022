using System;
using TechTalk.SpecFlow;

namespace November2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new Time and Material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            // TM Page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObj = new TMPage();

            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "November2022", "Actual code and expected code do not match.");
            Assert.That(newDescription == "November2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$12.00", "Actual price and expeected price do not match.");
        }

        [When(@"I update '([^']*)' on an existing time record")]
        public void WhenIUpdateOnAnExistingTimeRecord(string Description)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver, Description);
        }

        [Then(@"The record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string Description)
        {
            TMPage tmPageObj = new TMPage();
            string editDescription = tmPageObj.GetEditedDescription(driver);

            Assert.That(editDescription == Description, "Actual desription and expected description do not match");
        }

    }
}
