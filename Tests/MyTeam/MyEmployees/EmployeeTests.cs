using OpenQA.Selenium;
using Microsoft.Extensions.Caching.Memory;
using UltiProTests.Services;
using UINavigator.Common;

namespace UltiProTests.Tests.ATopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class EmployeeTests
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
        public async Task MyTeam_MyEmployees_Add_Employee()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/add-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_MyEmployees_Add_Employee_With_Direct_Deposit()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/add-employee-with-direct-deposit.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        #region CAT1022

        [TestMethod]
        public async Task MyTeam_MyEmployees_Add_Canadian_Employee()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/CAT1022/add-canadian-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_MyEmployees_Add_US_Hire_Employee()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/CAT1022/add-us-hire-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_MyEmployees_Add_Employee_1()
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
                .LoadUITest(@"DataTemplates/MyTeam/MyEmployees/CAT1022/add-employee.json");
            
            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_MyEmployees_Transfer_Employee()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Personal/CAT1022/transfer-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest?.Actions, _driver);
        }
        #endregion
    }
}