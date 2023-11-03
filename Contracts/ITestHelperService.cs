using UINavigator.Models.UIModels;

namespace UltiProTests.Contracts
{
    public interface ITestHelperService
    {
        Task<UITest?> LoadUITest(string location);

        Task ProcessUIActionsAsync(UITest uiTest);

        void StopWebDriver();
    }
}
