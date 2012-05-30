using System.Collections.Generic;
using Microsoft.Cci;
using Microsoft.Cci.ILToCodeModel;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class StatementCollector : CodeTraverser
    {
        List<IStatement> statements;
        public IEnumerable<IStatement> Result { get { return statements; } }

        public StatementCollector()
        {
            statements = new List<IStatement>();
        }

        public override void TraverseChildren(IStatement statement)
        {
            if (statement is IEmptyStatement) return;
            if (statement is IReturnStatement && (statement as IReturnStatement).Expression == null) return;
            if (!(statement is BasicBlock)) statements.Add(statement);
            base.TraverseChildren(statement);
        }
    }
}
