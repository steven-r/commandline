using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine.Tests.Fakes
{
    using System.IO;

    using CommandLine.Text;

    public class Options_With_Validation
    {
        [Option('t', "text-file")]
        [FileExistsValidation]
        public string TextFile { get; set; }
    }
}
