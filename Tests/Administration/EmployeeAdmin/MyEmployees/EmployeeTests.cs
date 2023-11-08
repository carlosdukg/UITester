using Newtonsoft.Json;
using UINavigator.Models.UIModels;
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

            var uiControl = new UIControl
            {
                ErrorMessages = new List<string> { "error 1", "error 2" },
                WarningMessages = new List<string> { "warning 1", "warning 2" },
                InfoMessages = new List<string> { "info 1", "info 2" },
                SetValueMethod = new UINavigator.Models.UI.UIValueMehod
                {
                    MethodParameters = new object[] { "param1", 0, true},
                    MethodReturnType = UINavigator.Models.Enums.DataTypes.Void
                },
                ValidateControlValue = new UINavigator.Models.UI.UIValidateControl
                {
                    ControlValues = new List<string> { "", "value1", "value2"}
                },
                ValidateOtherControls = new UINavigator.Models.UI.UIValidateControls
                {
                    VisibleControls = new[] { "control-id" },
                    HiddenControls = new[] { "control-id" },
                    RequiredControls = new[] { "control-id" },
                    NotRequiredControls = new[] { "control-id" },
                    DisabledControls = new[] { "control-id" },
                    EnabledControls = new[] { "control-id" },
                }
            };

            var jsonString = JsonConvert.SerializeObject(uiControl);

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