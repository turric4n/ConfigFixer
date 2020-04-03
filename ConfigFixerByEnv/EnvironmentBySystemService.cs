using System;

namespace ConfigFixerByEnv
{
    public static class EnvironmentBySystemService
    {
        public static string GetCurrentEnvironment(string envName)
        {
            return Environment.GetEnvironmentVariable(envName);
        }
    }
}
