using MyDemoProject.Hooks;
using MyDemoProject.PageObjects;
using MyDemoProject.TestData;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace MyDemoProject.StepDefinations
{
    [Binding]
    public class HomeExternalSiteSteps 
    {
       
        [Given(@"User Navigates to application (.*) Home page")]
        public void GivenUserNavigatesToApplicationHomePage(String site)
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                DriverClass.StartTest(TestConfig.externalUrl);
                 //Comment for Applications where default page is Login
                //loginPage.linkLogin.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }


        [Then(@"User click on to search button Home page")]
        [When(@"User click on to search button Home page")]
        public void ThenUserClickonSearchButton()
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                CustomBaseClass.ActionHoverAndClick(HomePage.searchButton, HomePage.searchButton);
                WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
                waitForElement.Until(ExpectedConditions.ElementToBeClickable(HomePage.searchButton)).Click();               
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }

        [Then(@"User Enter the search input (.*) Home page")]
        public void ThenUserEnterthesearchInput(string searchText )
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                //CustomBaseClass.EventClick(HomePage.searchButton);
                WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
                waitForElement.Until(ExpectedConditions.ElementToBeClickable(HomePage.searchInput)).Click();
                CustomBaseClass.EnterText(HomePage.searchInput, searchText);           
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }

        [Then(@"User Verify the search Result (.*) Home page")]
        public void ThenUserVerifythesearchResult(string searchText)
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);            
                WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
                foreach(var result in HomePage.searchResult)
                {
                    if (result.Text.Equals(searchText))
                    {
                        Assert.AreEqual(result.Text, searchText);
                        break;
                    }
                    
                }
                
                               
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }


        [Then(@"User Verify the search Result (.*) Search page")]
        public void ThenUserVerifythesearchResultSearchPage(string searchText)
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
                foreach (var result in HomePage.searchResultPage)
                {
                    if (result.Text.Equals(searchText))
                    {
                        Assert.AreEqual(result.Text, searchText);
                        break;
                    }

                }


            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }

        [Then(@"User click on to Menu button Home page")]
        [When(@"User click on to Menu button Home page")]
        public void ThenUserClickonMenuButton()
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                CustomBaseClass.ActionHoverAndClick(HomePage.menuButton, HomePage.menuButton);
               WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
               waitForElement.Until(ExpectedConditions.ElementToBeClickable(HomePage.menuButton)).Click();              
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }

        [Then(@"User click on to Conact button Menu page")]
        [When(@"User click on to Conact button Menu page")]
        public void ThenUserClickonConactButton()
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                CustomBaseClass.ScrollintoView(HomePage.contactButton);
                CustomBaseClass.ActionHoverAndClick(HomePage.contactButton, HomePage.contactButton);
                //WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30));
                //waitForElement.Until(ExpectedConditions.ElementToBeClickable(HomePage.menuButton)).Click();

            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }


        [Then(@"User Verify the Contact Address  (.*) Contact page")]
        public void ThenUserVerifytheContactAddressContactPage(string expectedAddress)
        {
            try
            {
                HomePage HomePage = new HomePage(CustomBaseClass.MyDriver);
                WebDriverWait waitForElement = new WebDriverWait(CustomBaseClass.MyDriver, TimeSpan.FromSeconds(30)); 
                var actutalText = HomePage.contactAddress.Text;
                actutalText = actutalText.Replace(System.Environment.NewLine, string.Empty);
                Assert.AreEqual(actutalText, expectedAddress);

            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }


        [Then(@"Test completed Successfully")]
        public void ThenTestCompletedSuccessfully()
        {
            DriverClass.CloseTest();
        }

    }
}
