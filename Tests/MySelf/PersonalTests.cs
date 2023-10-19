using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using UINavigator.Common;
using UltiProTests.Services;

namespace UltiProTests.Tests.MySelfTopMenu
{
    [TestClass]
    public class PersonalTests
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
        public async Task Personal_AddressAndNameChange_Page_Load()
        {
            //*** arrange ***//
            var uiTest = await _testHelper
                .LoadUITest(@"DataTemplates/MySelf/Personal/personal-address-name-change-page-load-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Personal_AddressAndNameChange_Address_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Personal/personal-address-change-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail("Missing test template");
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Personal_AddressAndNameChange_Smart_Address_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Personal/personal-smart-address-change-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Personal_AddressAndNameChange_Name_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Personal/personal-name-change-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }

        [TestMethod]
        public async Task Personal_AddressAndNameChange_NameAndAddress_Change()
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
                .LoadUITest(@"DataTemplates/MySelf/Personal/personal-name-address-change-USL1001.json");

            if (uiTest == null)
            {
                Assert.Fail();
            }

            //*** execute UI actions ***//
            _testHelper.ProcessUIActions(uiTest.Actions, _driver);
        }
    }
}
