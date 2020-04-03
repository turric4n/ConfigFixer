using CommandLine;
using System;
using System.IO;
using System.Reflection;

namespace ConfigFixerByEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                var currentdirectory = AppDomain.CurrentDomain != null ?
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory) :
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);                  
                var environment = EnvironmentBySystemService.GetCurrentEnvironment(o.EnvironmentVariable);
                if (string.IsNullOrEmpty(environment)) { throw new InvalidArgumentException("Undefined : o.EnvironmentVariable"); } 
                Console.WriteLine("[Main] >> Defined environment variable result -> Environment variable is : " + environment);
                var configpath = string.Concat(o.SourceFile, ".", environment, ".config");
                Console.WriteLine("[Main] >> Source file path -> is : " + environment);
                if (!File.Exists(configpath)) { throw new InvalidFileparameterException("[Args] Invalid file or not found : " + configpath); }
                if (File.Exists(o.MainConfigFile)) { File.Delete(o.MainConfigFile); }
                File.Copy(configpath, Path.Combine(currentdirectory, o.MainConfigFile));
            });
        }
    }
}
