using Newtonsoft.Json;
using OpenQA.Selenium;
using UINavigator.Common;
using UINavigator.Models.UIModels;
using UINavigator.Common.Contracts;
using UltiProTests.Contracts;

namespace UltiProTests.Services
{
    public class TestHelperService : ITestHelperService
    {
        private readonly INavigationService _navService;
        private readonly ITestUtilitiesService _testUtils;
        private readonly ITestMethodsService _testMethods;
        private readonly IValidationsService _validationsService;
        private readonly IWebDriver _driver;

        public TestHelperService(
            INavigationService navService,
            ITestUtilitiesService testUtils,
            ITestMethodsService testMethods,
            IValidationsService validationsService,
            IWebDriver driver)
        {
            _navService = navService;
            _testUtils = testUtils;
            _testMethods = testMethods;
            _validationsService = validationsService;
            _driver = driver;
            ;
        }

        public async Task<UITest?> LoadUITest(string location)
        {
            using StreamReader stream = new(location);
            var data = await stream.ReadToEndAsync();

            var receipe = JsonConvert.DeserializeObject<UITest>(data);
            return receipe;
        }

        public async Task ProcessUIActionsAsync(UITest uiTest)
        {
            // login
            _navService
                .Login(uiTest.Login?.Username, uiTest.Login?.Password, uiTest.Login?.Url, uiTest.Login?.IsSSOUser);

            await ProcessUIActionsAsync(uiTest.Actions);
        }

        private async Task ProcessUIActionsAsync(List<UIAction>? actions)
        {
            if (actions == null)
            {
                return;
            }

            // execute actions
            foreach (var action in actions)
            {
                if (action == null)
                {
                    continue;
                }

                switch (action.Type)
                {
                    case UIActionType.Navigate:
                        await Task.Run(() =>
                        {
                            if (action.Navigation != null && action.Navigation.IsPopUp)
                            {
                                var windowHandles = _driver.WindowHandles;
                                _driver.SwitchTo().Window(windowHandles?.Last());
                                _navService.Path(action.Navigation);
                            }
                            else if (action.Navigation != null)
                            {
                                _navService.Path(action.Navigation);
                            }
                        });
                        break;
                    case UIActionType.Page:
                        var pageFrameSwitch = new List<UIControl>
                        {
                            new UIControl
                            {
                                Id = "ContentFrame",
                                Type = ControlType.SwitchFrame,
                                Value = "last"
                            },
                            new UIControl
                            {
                                Id = "ContentFrame",
                                Type = ControlType.SwitchFrame,
                                Value = ""
                            }
                        };

                        await Task.Run(() =>
                        {
                            ProcessControlActions(pageFrameSwitch);

                            ProcessControlActions(action.Controls);
                        });
                        break;
                    case UIActionType.PopUp: // check action for pages, and clearly define whats a page or a pop-up
                        await Task.Run(() =>
                        {
                            ProcessControlActions(action.Controls);
                        });
                        break;
                    case UIActionType.Wizard:
                        await ProcessWizardControlActions(action);
                        break;
                }
            }
        }

        private void ProcessControlActions(List<UIControl>? controls)
        {

            if (controls == null || !controls.Any())
            {
                return;
            }

            foreach (var control in controls)
            {
                _driver.SetUIControl(control, _testMethods);

                _validationsService.ValidateControlValue(control);

                _validationsService.ValidateVisibleControls(control.ValidateControls?.VisibleControls);

                _validationsService.ValidateHiddenControls(control.ValidateControls?.HiddenControls);

                _validationsService.ValidateRequiredControls(control.ValidateControls?.RequiredControls);

                _validationsService.ValidateNotRequiredControls(control.ValidateControls?.NotRequiredControls);

                _validationsService.ValidateDisabledControls(control.ValidateControls?.DisabledControls);

                _validationsService.ValidateEnabledControls(control.ValidateControls?.EnabledControls);

                _validationsService.ValidatePageMessages(control);

                _validationsService.ValidateValidationObject(control);
            }
        }

        private async Task ProcessWizardControlActions(UIAction? action)
        {
            if (action == null)
            {
                return;
            }

            var wizardSteps = _testUtils.GetWizardSteps(action);
            if (wizardSteps == null || !wizardSteps.Any())
            {
                return;
            }

            foreach (var step in wizardSteps)
            {
                if (step == null)
                {
                    continue;
                }

                ProcessControlActions(step.Controls);

                if (step.MoveNext.HasValue && step.MoveNext.Value)
                {
                    _driver.MoveNext();
                }
                if (step.MovePrev.HasValue && step.MovePrev.Value)
                {
                    _driver.MovePrev();
                }
                if (step.DelayInSeconds != null)
                {
                    await Task.Delay(TimeSpan.FromSeconds(step.DelayInSeconds.Value));
                }
            }
        }

        public void StopWebDriver()
        {
            _driver.Quit();
        }

    }
}
