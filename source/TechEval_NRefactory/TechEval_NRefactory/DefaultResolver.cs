using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;

namespace TechEval_NRefactory
{
    public class DefaultResolver : NodeListResolveVisitorNavigator
    {
        internal Dictionary<AstNode, ResolveResult> resolveResults = new Dictionary<AstNode, ResolveResult>();
        internal Dictionary<AstNode, Conversion> conversions = new Dictionary<AstNode, Conversion>();
        internal Dictionary<AstNode, IType> conversionTargetTypes = new Dictionary<AstNode, IType>();
        bool resolveAll;

        public DefaultResolver(params AstNode[] nodes)
            : base(nodes)
        {
            resolveAll = (nodes.Length == 0);
        }

        public override ResolveVisitorNavigationMode Scan(AstNode node)
        {
            if (resolveAll)
                return ResolveVisitorNavigationMode.Resolve;
            else
                return base.Scan(node);
        }

        public override void Resolved(AstNode node, ResolveResult result)
        {
            resolveResults.Add(node, result);
        }

        public override void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
        {
            conversions.Add(expression, conversion);
            conversionTargetTypes.Add(expression, targetType);
        }
    }
}
