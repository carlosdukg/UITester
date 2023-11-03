using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UINavigator.Services;

public class ChromeWebDriverService : IChromeWebDriver
{
    public IWebDriver GetDriver()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        options.AddArgument("test-type");
        options.AddArgument("disable-notifications");
        options.AddUserProfilePreference("autofill.profile_enabled", false);
        options.AcceptInsecureCertificates = true;

        var driver = new ChromeDriver(options);

        return driver;
    }
}