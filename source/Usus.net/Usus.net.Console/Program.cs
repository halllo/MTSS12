
namespace andrena.Usus.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Analyzer analyzer = new ConsoleOutputAnalyzer();

            //analyzer.AnalyzeThisAssembly();
            analyzer.AnalyzeFile(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            
            System.Console.ReadLine();
        }
    }
}
