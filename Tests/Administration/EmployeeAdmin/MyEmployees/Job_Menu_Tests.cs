using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using UINavigator.Common;
using UltiProTests.Services;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class Job_Menu_Tests
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
        public async Task Change_Job_HROPS()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/change-job-1.json");
           
            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest, _driver);
        }

        [TestMethod]
        public async Task Change_Job_NON_HROPS()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/change-job-2.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Add_Job_History_HROPS()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/add-job-history-1.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Add_Job_History_NON_HROPS()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/add-job-history-2.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        #region CAT1022

        [TestMethod]
        public async Task Job_Summary_Salary()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/job-summary-not-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Job_Summary_Salary_Pay_Groupp()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/job-summary-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Job_Summary_Salary_Not_In_Pay_Groupp()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/job-summary-not-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Change_Job_And_Salary_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/change-job-salary.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Change_Job_And_Salary_Pay_Not_In_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/change-job-salary-not-in-group.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Change_Salary_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/change-salary.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Change_Salary_Not_In_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/change-salary-not-in-group.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Job_History_Detail_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/job-history-detail-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Job_Detail_Pay_Not_In_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/job-history-detail-not-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Admin_Add_Job_History_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/admin-add-job-history-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_Add_Job_History_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/team-add-job-history-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task MyTeam_Edit_Job_History_Pay_Group()
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
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CAT1022/team-edit-job-history-in-paygroup.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest.Actions, _driver);
        }
        #endregion
    }
}
