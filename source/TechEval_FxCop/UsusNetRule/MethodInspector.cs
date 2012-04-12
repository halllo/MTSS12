using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;

namespace UsusNetRule
{
    public static class MethodInspector
    {
        public static IList<Method> Callees(this Method caller)
        {
            if (caller == null) throw new ArgumentNullException("caller");
            CalleeVisitor cv = new CalleeVisitor();
            cv.VisitStatements(caller.Body.Statements);
            return cv.Callees;
        }

        public static IList<TypeNode> ReferencedTypes(this Method caller)
        {
            return Callees(caller).Select(m => m.DeclaringType).Distinct().ToList();
        }

        public static int CyclomaticComplexity(this Method caller)
        {
            if (caller == null) throw new ArgumentNullException("caller");
            CalleeVisitor cv = new CalleeVisitor();
            cv.VisitStatements(caller.Body.Statements);
            return cv.Cc;
        }

        public static int NumberOfStatements(this Method caller)
        {
            return caller.Body.Statements.Count;
        }

        private class CalleeVisitor : BinaryReadOnlyVisitor
        {
            public int Cc { get; set; }
            public IList<Method> Callees { get; private set; }
            private Dictionary<int, int> m_CalleeIds;

            public CalleeVisitor()
            {
                Callees = new List<Method>();
                m_CalleeIds = new Dictionary<int, int>();
                Cc = 1;
            }

            public override void VisitAssignmentStatement(AssignmentStatement assignment)
            {
                base.VisitAssignmentStatement(assignment);
            }

            public override void VisitBranch(Branch branch)
            {
                if (branch.Condition != null) Cc++;
                base.VisitBranch(branch);
            }

            public override void VisitMemberBinding(MemberBinding memberBinding)
            {
                base.VisitMemberBinding(memberBinding);

                Method method = memberBinding.BoundMember as Method;
                if (method == null)
                    return;
                int key = method.UniqueKey;
                if (!m_CalleeIds.ContainsKey(key))
                {
                    Callees.Add(method);
                    m_CalleeIds.Add(key, key);
                }
            }
        }
    }
}