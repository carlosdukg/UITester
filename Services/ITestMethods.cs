
namespace UltiProTests.Services
{
    public interface ITestMethods
    {
        string GenerateSSN();

        string GenerateSIN();

        string GenerateEMPNum();

        double CalculateAnnualSalaryC(string? hour, string? rate);

        bool ValidateCoreAnnualSalary(string? hour, string? rate, string? salary);
    }
}
