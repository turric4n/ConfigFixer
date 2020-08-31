using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigFixerByEnv
{
    public class Options
    {
        [Option('m', "mainconfigdelete", Required = false, HelpText = "Set source config file to delete")]
        public string MainConfigFile { get; set; }
        [Option('s', "source", Required = true, HelpText = "Set source config file")]
        public string SourceFile { get; set; }
        [Option('d', "destination", Required = true, HelpText = "Set destination config file")]
        public string DestinationFile { get; set; }
        [Option('e', "environment", Required = true, HelpText = "Defined environment variable")]
        public string EnvironmentVariable { get; set; }
        [Option('t', "environment1", Required = false, HelpText = "Another Defined environment variable")]
        public string SubEnvironmentVariable1 { get; set; }
        [Option('x', "environment2", Required = false, HelpText = "Another Defined environment variable")]
        public string SubEnvironmentVariable2 { get; set; }
        [Option('l', "separator", Required = false, Default = ".", HelpText = "Environment Separator")]
        public string Separator { get; set; }
        [Option('r', "extension", Required = false, Default = ".config", HelpText = "File Extension")]        
        public string Extension { get; set; }
    }
}
