﻿
using UINavigator.Models;
using UINavigator.Models.UIModels;

namespace UltiProTests.Services
{
    public interface ITestUtilities
    {
        /// <summary>
        /// Get wizard step object from json test template.
        /// </summary>
        /// <param name="stepName">Wizard step name</param>
        /// <param name="entryAction">Entry action object</param>
        /// <returns></returns>
        UIWizardStep? GetWizardStep(Enum stepName, EntryAction entryAction);

        /// <summary>
        /// Get wizard step object from json test template. 
        /// </summary>
        /// <param name="entryAction">Entry action object</param>
        /// <returns></returns>
        IEnumerable<UIWizardStep?> GetWizardSteps(UIAction entryAction);
    }
}
