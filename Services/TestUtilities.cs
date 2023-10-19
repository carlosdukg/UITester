﻿
using UINavigator.Models;
using UINavigator.Models.UIModels;

namespace UltiProTests.Services
{
    public class TestUtilities : ITestUtilities
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
