namespace CommandLine.Tests.Unit
{
    using System;
    using System.Linq;

    using CommandLine.Tests.Fakes;

    using FluentAssertions;

    using Xunit;

    public class ValidationTests
    {
        [Fact]
        public void FileExistValidationTest()
        {
            var expected = string.Empty;
            var filename = Guid.NewGuid().ToString("N") + ".txt";

            // Exercise system 
            Parser.Default.ParseArguments<Options_With_Validation>(new[] { "-t", filename })
                .WithNotParsed(p  => expected = ((ValidationFailedError)p.First()).Message)
                .WithParsed(p => expected = "Should not happen");

            // Verify outcome
            string.Format("File {0} not found", filename).ShouldBeEquivalentTo(expected);
        }
    }
}
