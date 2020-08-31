using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigFixerByEnv
{
    public class Options
    {
        // Delete destination  
        [Option('m', "mainconfigdelete", Required = false, HelpText = "Set source config file to delete")]
        public string MainConfigFile { get; set; }
        // Source file path
        [Option('s', "source", Required = true, HelpText = "Set source config file")]
        public string SourceFile { get; set; }
        // Destination file path
        [Option('d', "destination", Required = true, HelpText = "Set destination config file")]        
        public string DestinationFile { get; set; }
        //Environment variable
        [Option('e', "environment", Required = true, HelpText = "Defined environment variable")]     
        public string EnvironmentVariable { get; set; }
        // First additional environment variable
        [Option('t', "environment1", Required = false, HelpText = "Another Defined environment variable")]        
        public string SubEnvironmentVariable1 { get; set; }
        // Second additional environment variable
        [Option('x', "environment2", Required = false, HelpText = "Another Defined environment variable")]        
        public string SubEnvironmentVariable2 { get; set; }
        // Environment variables to file separator 
        [Option('l', "separator", Required = false, Default = ".", HelpText = "Environment Separator")]
        public string Separator { get; set; }
        // Destination File extension 
        [Option('r', "extension", Required = false, Default = ".config", HelpText = "File Extension")]        
        public string Extension { get; set; }
    }
}
