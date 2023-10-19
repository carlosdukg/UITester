using OpenQA.Selenium;
using Microsoft.Extensions.Caching.Memory;
using UltiProTests.Services;
using UINavigator.Common;

namespace UltiProTests.Tests.TopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class ChangeJobAndSalaryTests
    {
        private IWebDriver? _driver;
        private ChromeWebDriver? _chormeDriver;
        private TestHelper? _testHelper;

        [TestInitialize]
        public void Initialize()
        {
            _chormeDriver = new ChromeWebDriver();
            _driver = _chormeDriver.GetDriver();

            var cacheOptions = new MemoryCacheOptions
            {
                SizeLimit = 1024
            };
            var cache = new MemCache(new MemoryCache(cacheOptions));
            var customerSelector = new CustomerSelector(_driver);
            var login = new Login(_driver, customerSelector);
            var navigate = new Navigation(_driver, login);
            var testUtils = new TestUtilities();
            var testMethods = new TestMethods(cache);

            _testHelper = new TestHelper(navigate, testUtils, testMethods);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        [TestMethod]
        public async Task Change_Job_And_Salary()
        {
            if (_driver == null)
            {
                Assert.Fail("Null selenium driver");
            }
            if (_testHelper == null)
            {
                Assert.Fail("Null test helper");
            }
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/Employee/change-job-and-salary.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

    }
}