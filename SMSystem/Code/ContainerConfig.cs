using System.Collections.Generic;
using System;

namespace SMSystem.Code
{
    public static class ContainerConfig
    {
        private static Dictionary<string, object> configuration = new Dictionary<string, object>();

        public static void Register(string name, object obj)
        {
            if (!configuration.ContainsKey(name))
            {
                configuration.Add(name, obj);
                Console.WriteLine($"Registered key: {name}");
            }
            else
            {
                Console.WriteLine($"Key '{name}' already exists.");
            }
        }

        public static object ObjectType(string name)
        {
            if (configuration.TryGetValue(name, out var value))
            {
                Console.WriteLine($"Retrieved key: {name}");
                return value;
            }
            else
            {
                Console.WriteLine($"Key '{name}' not found.");
                throw new KeyNotFoundException($"The key '{name}' was not found in the configuration.");
            }
        }
    }
}