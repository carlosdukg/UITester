using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;
using UINavigator.Models.Enums;
using UINavigator.Models.UIModels;
using UltiProTests.Contracts;

namespace UltiProTests.Services
{
    public  class ValidationsService : IValidationsService
    {
        private readonly IWebDriver _driver;
        private readonly ITestMethodsService _testMethods;

        public ValidationsService(IWebDriver driver, ITestMethodsService testMethods)
        {
            _driver = driver;
            _testMethods = testMethods;
        }

        public void ValidateVisibleControls(IEnumerable<string>? visibleControls)
        {
            if (visibleControls != null && visibleControls.Any())
            {
                foreach (var displayControl in visibleControls)
                {
                    Assert.IsTrue(_driver.FindElement(By.Id(displayControl)).Displayed);
                }
            }
        }

        public void ValidateHiddenControls(IEnumerable<string>? hiddenControls)
        {
            if (hiddenControls != null && hiddenControls.Any())
            {
                foreach (var hiddenControl in hiddenControls)
                {
                    var controlElement = _driver.FindElement(By.Id(hiddenControl));
                    Assert.IsFalse(controlElement.Displayed);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(controlElement.GetAttribute("value")));
                }
            }
        }

        public void ValidateRequiredControls(IEnumerable<string>? requiredControls)
        {
            if (requiredControls != null && requiredControls.Any())
            {
                foreach (var requiredControl in requiredControls)
                {
                    var attribute = _driver.FindElement(By.Id(requiredControl)).GetAttribute("required");
                    Assert.IsTrue(string.Equals(attribute, "true", StringComparison.OrdinalIgnoreCase));
                }
            }
        }

        public void ValidateNotRequiredControls(IEnumerable<string>? notRequiredControls)
        {
            if (notRequiredControls != null && notRequiredControls.Any())
            {
                foreach (var notRequiredControl in notRequiredControls)
                {
                    var attribute = _driver.FindElement(By.Id(notRequiredControl)).GetAttribute("required");
                    Assert.IsTrue(attribute == null || string.Equals(attribute, "false", StringComparison.OrdinalIgnoreCase));
                }
            }
        }

        public void ValidateDisabledControls(IEnumerable<string>? disabledControls)
        {
            if (disabledControls != null && disabledControls.Any())
            {
                foreach (var disabledControl in disabledControls)
                {
                    var coreDisabledAttr = _driver.FindElement(By.Id(disabledControl)).GetAttribute("core-disabled");
                    if (coreDisabledAttr != null)
                    {
                        Assert.IsTrue(string.Equals(coreDisabledAttr, "true", StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        var disabledAttr = _driver.FindElement(By.Id(disabledControl)).GetAttribute("disabled");
                        Assert.IsTrue(disabledAttr != null);
                    }
                }
            }
        }

        public void ValidateEnabledControls(IEnumerable<string>? enabledControls)
        {
            if (enabledControls != null && enabledControls.Any())
            {
                foreach (var enabledControl in enabledControls)
                {
                    var coreDisabledAttr = _driver.FindElement(By.Id(enabledControl)).GetAttribute("core-disabled");
                    Assert.IsTrue(coreDisabledAttr == null);

                    var disabledAttr = _driver.FindElement(By.Id(enabledControl)).GetAttribute("disabled");
                    Assert.IsTrue(disabledAttr == null);
                }
            }
        }

        public void ValidatePageMessages(UIControl control)
        {
            if (control.ErrorMessages != null && control.ErrorMessages.Any())
            {
                var errorDiv = _driver.FindElement(By.Id("ctl00_errMsg"));
                var listUl = errorDiv.FindElement(By.TagName("ul"));
                var links = listUl.FindElements(By.TagName("li"));

                foreach (var errorMessage in control.ErrorMessages)
                {
                    if (!links.Any(l => string.Equals(l.Text, errorMessage, StringComparison.OrdinalIgnoreCase)))
                        Assert.Fail($"Error message not found: {errorMessage}");
                }
            }
            if (control.InfoMessages != null && control.InfoMessages.Any())
            {
                if (control.InfoMessages.Count == 0 && control.InfoMessages[0] == "empty")
                {
                    try
                    {
                        var infoDiv = _driver.FindElement(By.Id("ctl00_infoMsg"));
                        var listUl = infoDiv.FindElement(By.TagName("ul"));
                        Assert.Fail("There are information messages"); // TODO: improve
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    var infoDiv = _driver.FindElement(By.Id("ctl00_infoMsg"));
                    var listUl = infoDiv.FindElement(By.TagName("ul"));
                    var links = listUl.FindElements(By.TagName("li"));

                    foreach (var infoMessage in control.InfoMessages)
                    {
                        if (!links.Any(l => string.Equals(l?.Text, infoMessage, StringComparison.OrdinalIgnoreCase)))
                            Assert.Fail($"Info message not found: {infoMessage}");
                    }
                }
            }
        }

        public void ValidateValidationObject(UIControl control)
        {
            throw new NotImplementedException();
        }

        /*
        public void ValidateValidationObject(UIControl control)
        {
            if (control?.ValidateControls?.ValidationObject != null)
            {
                var methodName = control?.ValidateControls?.ValidationObject?.MethodName?.Trim();
                var methodParams = control?.ValidateControls?.ValidationObject?.MethodControlParams;

                Type utilsType = _testMethods.GetType();
                if (!string.IsNullOrWhiteSpace(methodName))
                {
                    MethodInfo? ctrlMethod = utilsType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
                    object? expectedControlValue;
                    if (control?.ValidateControls.ValidationObject.MethodReturnType == DataTypes.Double)
                    {
                        if (methodParams != null)
                        {
                            var parsedParams = methodParams.Select(x => x.Type == ControlType.Any
                            || x.Type == ControlType.Span ?
                                GetHtmlValue(x.Id) :
                                GetInputValue(x.Id)).ToArray();
                            expectedControlValue = (double?)ctrlMethod?.Invoke(_testMethods, parsedParams);
                        }
                        else
                        {
                            expectedControlValue = (double?)ctrlMethod?.Invoke(_testMethods, null);
                        }

                        var controlToValidate = control?.ValidateControls.ValidationObject.ControlToValidateId;
                        var controlToValidateValue = controlToValidate?.Type == ControlType.Any || controlToValidate?.Type == ControlType.Span ?
                            GetHtmlValue(controlToValidate?.Id) :
                            GetInputValue(controlToValidate?.Id);

                        Assert.IsTrue((double?)expectedControlValue ==
                            double.Parse(controlToValidateValue), $"expected value:{(double)expectedControlValue}, control value:{double.Parse(controlToValidateValue)}");
                    }
                    else if (control?.ValidateControls.ValidationObject.MethodReturnType == DataTypes.Int)
                    {
                        if (methodParams != null)
                        {
                            var parsedParams = methodParams.Select(x => GetHtmlValue(x.Id)).ToArray();
                            expectedControlValue = (int?)ctrlMethod?.Invoke(utilsType, new[] { parsedParams });
                        }
                        else
                        {
                            expectedControlValue = (int?)ctrlMethod?.Invoke(utilsType, null);
                        }
                        var controlToValidate = control?.ValidateControls.ValidationObject.ControlToValidateId;
                        var controlToValidateValue = GetHtmlValue(controlToValidate?.Id);

                        Assert.IsTrue((int?)expectedControlValue == int.Parse(controlToValidateValue));
                    }
                    else if (control?.ValidateControls.ValidationObject.MethodReturnType == DataTypes.String)
                    {
                        if (methodParams != null)
                        {
                            var parsedParams = methodParams.Select(x => GetHtmlValue(x.Id)).ToArray();
                            expectedControlValue = (string?)ctrlMethod?.Invoke(_testMethods, parsedParams);
                        }
                        else
                        {
                            expectedControlValue = (string?)ctrlMethod?.Invoke(_testMethods, null);
                        }
                        var controlToValidate = control?.ValidateControls.ValidationObject.ControlToValidateId;
                        var controlToValidateValue = GetHtmlValue(controlToValidate?.Id);

                        Assert.IsTrue(string.Equals(expectedControlValue, controlToValidateValue));
                    }
                    else if (control?.ValidateControls.ValidationObject.MethodReturnType == DataTypes.Bool)
                    {
                        if (methodParams != null)
                        {
                            var parsedParams = methodParams.Select(x => x.Type == ControlType.Any
                            || x.Type == ControlType.Span ?
                                    GetHtmlValue(x.Id) :
                                    GetInputValue(x.Id)).ToArray();
                            expectedControlValue = (bool?)ctrlMethod?.Invoke(_testMethods, parsedParams);
                        }
                        else
                        {
                            expectedControlValue = (bool?)ctrlMethod?.Invoke(_testMethods, null);
                        }

                        Assert.IsTrue((bool?)expectedControlValue);
                    }
                }
            }
        }
        */

        public void ValidateControlValue(UIControl control)
        {
            switch (control.Type)
            {
                case ControlType.Dropdown:
                    DropDownValueValidation(control);
                    break;
                case ControlType.Div:
                    HtmlValueValidation(control);
                    break;
                case ControlType.UrlLocation:
                    UrlLocationValidation(control);
                    break;
                case ControlType.Span:
                    HtmlValueValidation(control);
                    break;
                case ControlType.Any:
                    HtmlValueValidation(control);
                    break;
            }
        }

        private void DropDownValueValidation(UIControl control)
        {
            var dropdown = control.Id == null ? _driver.FindElement(By.Id(control.Name)) : _driver.FindElement(By.Id(control.Id));
            var dropdownElement = new SelectElement(dropdown);

            if (control.ValidateControlValue != null 
                && control.ValidateControlValue.ControlValues != null 
                && control.ValidateControlValue.ControlValues.Any())
            {
                if (control.ValidateControlValue.ControlValues.Count == 1)
                {
                    var option = dropdownElement.SelectedOption;
                    var optionSelected = option.Text;

                    var validateValue = control.ValidateControlValue.ControlValues.FirstOrDefault();
                    Assert.IsTrue(option.Text == validateValue, $"select option:{validateValue} not found");
                }
                else
                {
                    var options = dropdownElement.Options.Select(o => o.Text).ToList();
                    foreach (string value in control.ValidateControlValue.ControlValues)
                    {
                        Assert.IsTrue(dropdownElement
                            .Options
                            .Any(o => o.Text == value), $"select option:{value} not found");
                    }
                }
            }
        }

        private void HtmlValueValidation(UIControl control)
        {
            if (control?.ValidateControlValue?.ControlValue != null)
            {
                var htmlCtrl = _driver.FindElement(By.Id(control.Id));
                var htmlCtrlText = htmlCtrl.Text;
                Assert.IsTrue(htmlCtrlText.Contains(control.ValidateControlValue.ControlValue), $"HTML text {htmlCtrlText} not found in control {control.Id}");
            }
        }

        private void UrlLocationValidation(UIControl control)
        {
            var handles = _driver.WindowHandles;
            _driver.SwitchTo().Window(handles.Last());

            var driverUrl = _driver.Url;

            Assert.IsTrue(driverUrl == control.Value);
        }

        private string GetInputValue(string? id)
        {
            if (id == null)
            {
                return string.Empty;
            }

            var htmlCtrl = _driver.FindElement(By.Id(id));
            var htmlCtrlValue = htmlCtrl.GetAttribute("value").Contains('$') ? htmlCtrl.GetAttribute("value")[1..] : htmlCtrl.GetAttribute("value");
            return htmlCtrlValue;
        }

        private string GetHtmlValue(string? id)
        {
            if (id == null)
            {
                return string.Empty;
            }

            var htmlCtrl = _driver.FindElement(By.Id(id));
            var htmlCtrlText = htmlCtrl.Text.Contains('$') ? htmlCtrl.Text[1..] : htmlCtrl.Text;
            return htmlCtrlText;
        }       
    }
}
