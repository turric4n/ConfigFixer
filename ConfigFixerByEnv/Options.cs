using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigFixerByEnv
{
    public class Options
    {
        [Option('m', "mainconfigdelete", Required = true, HelpText = "Set source config file")]
        public string MainConfigFile { get; set; }
        [Option('s', "source", Required = true, HelpText = "Set source config file")]
        public string SourceFile { get; set; }
        [Option('d', "destination", Required = true, HelpText = "Set destination config file")]
        public string DestinationFile { get; set; }
        [Option('e', "environment", Required = true, HelpText = "Defined environment variable")]
        public string EnvironmentVariable { get; set; }
    }
}
