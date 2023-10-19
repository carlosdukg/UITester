using OpenQA.Selenium;
using Microsoft.Extensions.Caching.Memory;
using UltiProTests.Services;
using UINavigator.Common;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class CareerAndEducation_Menu_Tests
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
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Tuberculosis_PeridicTesting_TBResults_Selection_Views()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-tb-pt-tb-results.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);

        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_ConsentDate_Selection_Views()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-consent-date.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Selection_Views()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-decline-date_valid.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Valid_Selection()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL_valid.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_All_Required()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-inf-il-decline-date_required_all.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_Dates()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-decline-date_required_dates.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_Attestation()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-inf-il-decline-date.json");
            if (_driver == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            _testHelper.ProcessUIActions(uiTest?.Actions, _driver);
        }
    }
}