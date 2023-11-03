using UltiProTests.Contracts;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class CON5000_EmployeeTests
    {
        private readonly ITestHelperService _testHelper;

        public CON5000_EmployeeTests()
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
        public async Task Hire_Employee()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/MyEmployees/CON5000/add-employee.json");

            if (uiTest == null)
            {
                Assert.Fail("Null test template");
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}