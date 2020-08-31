using System;

namespace ConfigFixerByEnv
{
    public static class EnvironmentBySystemService
    {
        public static string GetCurrentEnvironment(string envName)
        {
            if (!string.IsNullOrEmpty(envName)) return Environment.GetEnvironmentVariable(envName);
            else return string.Empty;
        }
    }
}
