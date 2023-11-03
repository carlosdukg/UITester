using UINavigator.Models.UIModels;

namespace UltiProTests.Contracts
{
    public interface IValidationsService
    {
        void ValidateVisibleControls(IEnumerable<string>? visibleControls);

        void ValidateHiddenControls(IEnumerable<string>? hiddenControls);

        void ValidateRequiredControls(IEnumerable<string>? requiredControls);

        void ValidateNotRequiredControls(IEnumerable<string>? notRequiredControls);

        void ValidateDisabledControls(IEnumerable<string>? disabledControls);

        void ValidateEnabledControls(IEnumerable<string>? enabledControls);

        void ValidatePageMessages(UIControl control);

        void ValidateValidationObject(UIControl control);

        void ValidateControlValue(UIControl control);
    }
}
