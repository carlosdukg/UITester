using UltiProTests.Contracts;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class CareerAndEducation_Menu_Tests
    {
        private readonly ITestHelperService _testHelper;

        public CareerAndEducation_Menu_Tests()
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
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Tuberculosis_PeridicTesting_TBResults_Selection_Views()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-tb-pt-tb-results.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);

        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_ConsentDate_Selection_Views()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-consent-date.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Selection_Views()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-decline-date_valid.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Valid_Selection()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL_valid.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_All_Required()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-inf-il-decline-date_required_all.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_Dates()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-INF-IL-decline-date_required_dates.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task MyEmployees_Employee_CareerAndEducation_AddVaccineTest_Influenza_IL_DeclineDate_Save_Missing_Attestation()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Benefits/AddVaccine/my-employees-add-vaccine-test-inf-il-decline-date.json");
            if (uiTest == null)
            {
                Assert.Fail();
            }

            // execute UI actions
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}