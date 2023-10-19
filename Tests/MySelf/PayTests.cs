using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using UINavigator.Common;
using UltiProTests.Services;

namespace UltiProTests.Tests.MySelfTopMenu
{
    [TestClass]
    public class PayTests
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
        public async Task Direct_Deposit_Routing_Numbers_Mismatch()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-routing_number-mismatch-error-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Direct_Deposit_Account_Numbers_Mismatch()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-account_number-mismatch-error-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Direct_Deposit_Edit_Page_Load()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-edit-page-load-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Direct_Deposit_Add_Successful()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-valid-create-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Direct_Deposit_Edit_Page_Show_Routing_Confirmation_On_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-edit-page-display-conf-routing-number-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Direct_Deposit_Edit_Page_Show_Account_Confirmation_On_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/USL1001/direct_deposit-edit-page-display-conf-account-number-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task MySelf_Direct_Deposit_Add_DIS1013()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/DIS1013/direct_deposit-add-test.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task MySelf_Direct_Deposit_Edit_DIS1013()
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
                .LoadUITest(@"DataTemplates/MySelf/Pay/DIS1013/direct_deposit-edit-test.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }
    }
}
