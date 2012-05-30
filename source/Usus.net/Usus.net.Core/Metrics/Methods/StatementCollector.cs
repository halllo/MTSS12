using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.ILToCodeModel;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class StatementCollector : CodeTraverser
    {
        bool requireLocations;
        List<IStatement> statements;

        public IEnumerable<IStatement> Result { get { return statements; } }

        public StatementCollector(PdbReader pdb)
        {
            statements = new List<IStatement>();
            requireLocations = pdb != null;
        }

        public override void TraverseChildren(IStatement statement)
        {
            if (statement is IEmptyStatement) return;
            if (statement is IReturnStatement && (statement as IReturnStatement).Expression == null) return;

            RememberStatement(statement);
            base.TraverseChildren(statement);
        }

        private void RememberStatement(IStatement statement)
        {
            if (requireLocations)
                RememberStatementWithLocation(statement);
            else
                RememberStatementNotBlock(statement);
        }

        private void RememberStatementWithLocation(IStatement statement)
        {
            if (statement.Locations.Any() || statement is IConditionalStatement)
                statements.Add(statement);
        }

        private void RememberStatementNotBlock(IStatement statement)
        {
            if (!(statement is BasicBlock))
                statements.Add(statement);
        }
    }
}
