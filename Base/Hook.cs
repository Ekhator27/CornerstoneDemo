using BoDi;
using CornerstoneDemo.Drivers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace CornerstoneDemo.Base
{
    [Binding]
    public sealed class Hook : DriverHelper
    {
        IObjectContainer container;
        public ChromeOptions options;
        public Hook(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
            options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            container.RegisterInstanceAs(driver);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}