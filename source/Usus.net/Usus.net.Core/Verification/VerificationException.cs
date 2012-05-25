﻿using System;
using System.Reflection;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Verification
{
    public class VerificationException : Exception
    {
        private const string MESSAGE = "\"{0}\" does not meet expectation {1}";

        public VerificationException(MethodInfo method, MethodExpectation expectation)
            : base(String.Format(MESSAGE, method.GetFullName(), expectation.Message))
        {
        }
    }
}