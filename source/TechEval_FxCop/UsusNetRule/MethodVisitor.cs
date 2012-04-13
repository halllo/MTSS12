using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;

namespace UsusNetRule
{
    internal class MethodVisitor : BinaryReadOnlyVisitor
    {
        public int CyclomaticComplextiy { get; set; }
        public IList<Method> Callees { get; private set; }
        private Dictionary<int, int> CalleeIds;

        public MethodVisitor()
        {
            Callees = new List<Method>();
            CalleeIds = new Dictionary<int, int>();
            CyclomaticComplextiy = 1;
        }

        public override void VisitAssignmentStatement(AssignmentStatement assignment)
        {
            base.VisitAssignmentStatement(assignment);
        }

        public override void VisitBranch(Branch branch)
        {
            if (branch.Condition != null) CyclomaticComplextiy++;
            base.VisitBranch(branch);
        }

        public override void VisitMemberBinding(MemberBinding memberBinding)
        {
            base.VisitMemberBinding(memberBinding);

            Method method = memberBinding.BoundMember as Method;
            if (method == null) return;
            int key = method.UniqueKey;
            if (CalleeIds.ContainsKey(key)) return;
            Callees.Add(method);
            CalleeIds.Add(key, key);
        }
    }
}
