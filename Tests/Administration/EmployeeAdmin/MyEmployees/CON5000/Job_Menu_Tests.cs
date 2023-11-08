using UltiProTests.Contracts;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class CON1000_Admin_Job_Menu_Tests
    {
        private readonly ITestHelperService _testHelper;

        public CON1000_Admin_Job_Menu_Tests()
        {
            _testHelper = TestServiceProvider.GetService<ITestHelperService>();
        }

        [TestInitialize]
        public void Initialize()
        {
            Assert.IsNotNull(_testHelper, "null test helper service");
        }

        [TestCleanup]
        public void TearDown()
        {
            _testHelper.StopWebDriver();
        }

        [TestMethod]
        public async Task Change_Job()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job.json");
           
            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Change_Job_Salary()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job-salary.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Update_Job_History()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/edit-job-history.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Add_Job_History()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Jobs/CON5000/change-job.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}
