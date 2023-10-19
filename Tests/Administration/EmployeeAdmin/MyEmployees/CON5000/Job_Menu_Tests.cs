using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using UINavigator.Common;
using UltiProTests.Services;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class CON1000_Admin_Job_Menu_Tests
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
        public async Task Change_Job()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job.json");
           
            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest, _driver);
        }

        [TestMethod]
        public async Task Change_Job_Salary()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job-salary.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest, _driver);
        }

        [TestMethod]
        public async Task Update_Job_History()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/edit-job-history.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest, _driver);
        }

        [TestMethod]
        public async Task Add_Job_History()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest, _driver);
        }
    }
}
