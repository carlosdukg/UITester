using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using UINavigator.Common;
using UltiProTests.Services;

namespace UltiProTests.Tests.MyTeamTopMenu.MyEmployees.Employee
{
    [TestClass]
    public class HireDirectDepositStepTest
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
        public async Task Hire_Direct_Deposit_Sted_Add_Data_DIS1013()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/add-employee-add-direct-deposit.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task Hire_Direct_Deposit_Sted_Edit_Data_DIS1013()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/add-employee-edit-direct-deposit.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }
    }
}
