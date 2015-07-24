﻿// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See doc/License.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using FluentAssertions;

namespace CommandLine.Tests.Unit
{
    public class UnParserExtensionsTests
    {
        [Theory]

        public static IEnumerable<object> UnParseData
        {
                yield return new object[] { new FakeOptions(), "" };
                yield return new object[] { new FakeOptions { BoolValue = true }, "-x" };
                yield return new object[] { new FakeOptions { IntSequence = new[] { 1, 2, 3 } }, "-i 1 2 3" };
                yield return new object[] { new FakeOptions { StringValue = "nospaces" }, "--stringvalue nospaces" };
                yield return new object[] { new FakeOptions { StringValue = " with spaces " }, "--stringvalue \" with spaces \"" };
                yield return new object[] { new FakeOptions { StringValue = "with\"quote" }, "--stringvalue \"with\\\"quote\"" };
                yield return new object[] { new FakeOptions { StringValue = "with \"quotes\" spaced" }, "--stringvalue \"with \\\"quotes\\\" spaced\"" };
                yield return new object[] { new FakeOptions { LongValue = 123456789 }, "123456789" };
    }
}