
using MyDemoProject.Hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDemoProject.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        
        }
        public IWebElement linkHome => driver.FindElement(By.XPath("//a[@title='Home']"));
        public IWebElement textUserFullName => driver.FindElement(By.XPath("Testtt"));

        public IWebElement searchButton => driver.FindElement(By.ClassName("component--header__search"));
        public IWebElement searchInput => driver.FindElement(By.Name("k"));
        public IList<IWebElement> searchResult => driver.FindElements(By.XPath("//div[@class='header--search__results']//a"));

        public IList<IWebElement> searchResultPage => driver.FindElements(By.XPath("//a[@class='s - results__tag']"));
        public IWebElement menuButton => driver.FindElement(By.ClassName("header--toggle"));

        public IWebElement contactButton => driver.FindElement(By.XPath("//*[contains(@href,'/contact')]"));

        public IWebElement contactAddress => driver.FindElement(By.XPath("//div[@id='bermudaoffice']//address"));


    }
}
 