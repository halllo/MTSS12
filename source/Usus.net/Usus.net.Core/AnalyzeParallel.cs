using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core
{
    internal static class AnalyzeParallel
    {
        public static IEnumerable<MetricsReport> Files(string[] files, Func<string, MetricsReport> fileFunction)
        {
            return OnParallel(files, fileFunction);
        }

        private static IEnumerable<MetricsReport> OnParallel(string[] files, Func<string, MetricsReport> fileFunction)
        {
            return from file in files.AsParallel() select fileFunction(file);
        }

        private static IEnumerable<MetricsReport> OnTasks(string[] files, Func<string, MetricsReport> fileFunction)
        {
            var tasks = GetAnalyzeTasks(files, fileFunction).ToArray();
            Task.WaitAll(tasks);
            return from task in tasks select task.Result;
        }

        private static IEnumerable<Task<T>> GetAnalyzeTasks<T>(string[] files, Func<string, T> taskFunction)
        {
            return from file in files
                   select Task.Factory.StartNew(o => taskFunction(file), TaskCreationOptions.LongRunning);
        }
    }
}
