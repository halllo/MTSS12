using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Metrics.Types.Interconnection;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateGraph
    {
        public static IEnumerable<string> Reach(Dictionary<string, IEnumerable<string>> graphDict, string start)
        {
            return graphDict.ToGraph().Reach(start).Vertices;
        }

        public static bool ContainsAll(this IEnumerable<string> sequence, params string[] contains)
        {
            return contains.All(c => sequence.Contains(c));
        }

        public static bool ContainsAllNot(this IEnumerable<string> sequence, params string[] contains)
        {
            return contains.All(c => !sequence.Contains(c));
        }

    }
}
