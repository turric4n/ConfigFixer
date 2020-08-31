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

                var environment1 = EnvironmentBySystemService.GetCurrentEnvironment(o.SubEnvironmentVariable1);                
                var environment2 = EnvironmentBySystemService.GetCurrentEnvironment(o.SubEnvironmentVariable2);                
                var environment = EnvironmentBySystemService.GetCurrentEnvironment(o.EnvironmentVariable);

                var separator = o.Separator;

                //Normalize
                environment1 = !string.IsNullOrEmpty(environment1) ? string.Concat(environment1, separator) : environment1;
                environment2 = !string.IsNullOrEmpty(environment2) ? string.Concat(environment2, separator) : environment2;
                o.SourceFile = !string.IsNullOrEmpty(o.SourceFile) ? string.Concat(o.SourceFile, separator) : o.SourceFile;

                if (string.IsNullOrEmpty(environment)) { throw new InvalidArgumentException("Undefined : o.EnvironmentVariable"); } 

                Console.WriteLine("[Main] >> Defined environment variable result -> Environment variable is : " + environment);

                var configpath = string.Concat(o.SourceFile, environment1, environment2, environment, o.Extension);

                Console.WriteLine("[Main] >> Source file path -> is : " + configpath);

                if (!File.Exists(configpath)) { throw new InvalidFileparameterException("[Args] Invalid config file file or not found : " + configpath); }


                Console.WriteLine("[Main] >> Deleting old main config file if exists -> is : " + o.MainConfigFile);

                if (!string.IsNullOrEmpty(o.MainConfigFile) && File.Exists(o.MainConfigFile)) { File.Delete(o.MainConfigFile); }

                Console.WriteLine("[Main] >> Deleting old main config file if exists -> is : " + o.DestinationFile);

                if (!string.IsNullOrEmpty(o.DestinationFile) && File.Exists(o.DestinationFile)) { File.Delete(o.DestinationFile); }

                Console.WriteLine("[Main] >> Copying -> : " + configpath + " to " + Path.Combine(currentdirectory, o.DestinationFile ));

                File.Copy(configpath, Path.Combine(currentdirectory, o.DestinationFile));
            });
        }
    }
}
