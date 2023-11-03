using UltiProTests.Contracts;

namespace UltiProTests.Tests.MyTeamTopMenu.MyEmployees.Employee
{
    [TestClass]
    public class Personal_Menu_Tests
    {
        private readonly ITestHelperService _testHelper;

        public Personal_Menu_Tests()
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
        public async Task Transfer_Employee()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Employee/Personal/transfer-employee.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}
