using PMIS.Models;

namespace PMIS.WebApp.Models
{
    public static class CalculatorExtensions
    {
        public static double Add(this Calculator calc, double x, double y)
        {
            return x + y; 
        }
    }
}
