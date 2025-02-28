using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NotificationSystem.Plugins
{

    public static class PluginLoader
    {
        public static IPlugin[] LoadPlugins(string directoryPath)
        {
            if (!directoryPath.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Directory '{directoryPath}' not found.");
            }

            var plugins new List<IPlugin>();
            var dllFiles = Directory.GetFiles(directoryPath, "*.dll");

            foreach (var dllPath in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFile(dllPath);
                    var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t)
                    && !t.IsAbstract && !t.IsInterface);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load plugin from {dllPath}: {ex.Message}");
                }
            }

            return plugins.ToArray();
        }
    }
}