using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using WebDriverManager.DriverConfigs.Impl;

namespace MyDemoProject.Hooks
{
    public static class DriverClass
    {


        public static void StartTest(string BaseURL)
        {
            try
            {

                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                var Options = new ChromeOptions();
                Options.AddArguments("--start-maximized");
                Options.AddArguments("--no-sandbox");

                CustomBaseClass.MyDriver = new ChromeDriver();             
               
                CustomBaseClass.MyDriver.Navigate().GoToUrl(BaseURL);
                CustomBaseClass.MyDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                CustomBaseClass.MyDriver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();    
   
                
                Console.WriteLine("Browser loaded, Test Passed");
            }
            catch (Exception testInitiationException)
            {
                Console.WriteLine("Failed Initiation : {0}", testInitiationException.Message);                
                Assert.Fail();
            }
        }



        [TearDown]

        // Tears down test and throws exception
        public static void CloseTest()
        {
            try
            {
                CustomBaseClass.MyDriver.Quit();
                //Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

                //foreach (var chromeDriverProcess in chromeDriverProcesses)
                //{
                //    chromeDriverProcess.Kill();
                //}
                Console.WriteLine("Test Completes successfully");
            }
            catch (WebDriverException testClosingException)
            {
                Console.WriteLine("Driver Failed to close the browser: {0}", testClosingException.Message);
            }

        }


    }
}

