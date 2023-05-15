using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Spec_WebTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@AddToCart")]
        public void BeforeScenarioWithTag()
        {
           

        }

        [BeforeScenario]
         public void FirstBeforeScenario()
         {
             IWebDriver driver = new ChromeDriver();
             driver.Manage().Window.Maximize();
             driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
             _container.RegisterInstanceAs<IWebDriver>(driver);
         }
        
        [AfterScenario]
            public void AfterScenario()
        {
            
            var driver = _container.Resolve<IWebDriver>();
            if(driver!=null)
            {
               // driver.Quit();
            }
        }
    }
}