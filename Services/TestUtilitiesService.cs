
using UINavigator.Models;
using UINavigator.Models.UIModels;
using UltiProTests.Contracts;

namespace UltiProTests.Services
{
    public class TestUtilitiesService : ITestUtilitiesService
    {
        public UIWizardStep? GetWizardStep(Enum stepName, EntryAction entryAction)
        {
            var stepActions = entryAction?
                .WizardSteps?
                .SingleOrDefault(s => string.Equals(s.Name, stepName.ToString(), StringComparison.OrdinalIgnoreCase));

            return stepActions;
        }

        /// <inheritdoc/>
        public IEnumerable<UIWizardStep?> GetWizardSteps(UIAction entryAction)
        {
            var steps = entryAction?.WizardSteps;

            return steps ?? Enumerable.Empty<UIWizardStep?>();
        }
    }
}
