using UltiProTests.Contracts;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class EmployeeTests
    {
        private readonly ITestHelperService _testHelper;

        public EmployeeTests()
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
        public async Task Add_Employee()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/MyEmployees/add-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Add_Employee_Add_Direct_Deposit()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/MyEmployees/add-employee-add-direct-deposit.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Add_Employee_Edit_Direct_Deposit()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/MyEmployees/add-employee-edit-direct-deposit.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}