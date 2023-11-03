
using UINavigator.Contracts;
using UltiProTests.Contracts;

namespace UltiProTests.Services
{
    public class TestMethodsService : ITestMethodsService
    {
        private readonly IMemCacheService _cache;

        public TestMethodsService(IMemCacheService testCache) 
        {
            _cache = testCache;
        }

        public string GenerateSSN()
        {
            var ssn = _cache.Get<string>("ssn");
            if (ssn == null)
            {
                var random = new Random();
                ssn = $"{random.Next(10000).ToString("D4").Substring(0, 3)}" +
                    $"-{random.Next(10000).ToString("D4").Substring(0, 2)}" +
                    $"-{random.Next(10000).ToString("D4").Substring(0, 4)}";
                _cache.Set("ssn", ssn);
            }
            return ssn;
        }

        public string GenerateSIN()
        {
            var sin = _cache.Get<string>("sin");
            if (sin == null)
            {
                var r = new Random();
                int[] s = new int[9];

                for (int i = 0; i < 9; i++)
                    s[i] = r.Next(0, 10);

                sin = $"{s[0]}{s[1]}{s[2]} {s[3]}{s[4]}{s[5]} {s[6]}{s[7]}{s[8]}";
            }
            return sin;
        }

        public string GenerateEMPNum()
        {
            var _random = new Random();
            var empnum = _cache.Get<string>("empnum");
            if (empnum == null)
            {
                empnum = _random.Next(0, 9999).ToString("D4");
                _cache.Set("empnum", empnum);
            }
            else
            {
                var newNum = int.Parse(empnum);
                newNum += 1;
                empnum = newNum.ToString();
                _cache.Set("empnum", empnum);
            }

            return empnum;
        }

        public double CalculateAnnualSalaryC(string? hour, string? rate)
        {
            if (hour != null && rate != null)
            {
                return double.Parse(hour) * double.Parse(rate) * 22;
            }
            return 0;
        }

        public bool ValidateCoreAnnualSalary(string? hour, string? rate, string? salary)
        {
            if (hour != null && rate != null)
            {
                var customSalaryC = double.Parse(hour) * double.Parse(rate) * 22;
                var customSalaryB = double.Parse(hour) * double.Parse(rate) * 20;

                if (salary != null)
                {
                    if (salary.Contains("$"))
                    {
                        salary = salary.Replace("$", "");
                    }
                    return double.Parse(salary) != customSalaryC && double.Parse(salary) != customSalaryB;
                }
            }
            return false;
        }
    }
}
