namespace UltiProTests.Contracts
{
    public interface ITestMethodsService
    {
        string GenerateSSN();

        string GenerateSIN();

        string GenerateEMPNum();

        double CalculateAnnualSalaryC(string? hour, string? rate);

        bool ValidateCoreAnnualSalary(string? hour, string? rate, string? salary);
    }
}
