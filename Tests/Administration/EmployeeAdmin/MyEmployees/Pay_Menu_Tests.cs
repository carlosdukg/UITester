using UltiProTests.Contracts;

namespace UltiProTests.Tests.AdministrationTopMenu.EmployeeAdmin.MyEmployees
{
    [TestClass]
    public class Pay_Menu_Tests
    {
        private readonly ITestHelperService _testHelper;

        public Pay_Menu_Tests()
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
        public async Task Direct_Deposit_Routing_Numbers_Mismatch()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Pay/direct_deposit-routing_number-mismatch-error-USL1001.json");
            
            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }

        [TestMethod]
        public async Task Direct_Deposit_Account_Numbers_Mismatch()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/Administration/EmployeeAdmin/Pages/Pay/direct_deposit-account_number-mismatch-error-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            await _testHelper.ProcessUIActionsAsync(uiTest);
        }
    }
}