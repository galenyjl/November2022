using System;
using TechTalk.SpecFlow;

namespace November2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();

            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new Time and Material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            // TM Page object initialization and definition
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "November2022", "Actual code and expected code do not match.");
            Assert.That(newDescription == "November2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$12.00", "Actual price and expeected price do not match.");
        }

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' on an existing time record")]
        public void WhenIUpdateOnAnExistingTimeRecord(string description, string code, string price)
        {
            tmPageObj.EditTM(driver, description, code, price);
        }

        [Then(@"The record should have the updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string description, string code, string price)
        {
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.That(editedDescription == description, "Actual desription and expected description do not match");
            Assert.That(editedCode == code, "Actual code and expected code do not match");
            Assert.That(editedPrice == price, "Actual price and expected price do not match");
        }
    }
}
