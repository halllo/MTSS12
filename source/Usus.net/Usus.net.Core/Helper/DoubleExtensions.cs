
namespace andrena.Usus.net.Core.Helper
{
    public static class DoubleExtensions
    {
        public static string Percent(this double value)
        {
            return value.ToString("0.0%");
        }
    }
}
