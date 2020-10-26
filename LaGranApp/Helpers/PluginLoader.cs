﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace LaGranApp.Helpers
{
    public static class PluginLoader<T>
    {
        public static ICollection<T> LoadPlugins(string path)
        {
            try
            {
                string[] dllFileNames = null;

                if (Directory.Exists(path))
                {
                    dllFileNames = Directory.GetFiles(path, "*.dll");

                    ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                    foreach (string dllFile in dllFileNames)
                    {
                        if (mf_IsAssembly(dllFile))
                        {
                            //AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                            Assembly assembly = Assembly.Load(File.ReadAllBytes(dllFile));
                            assemblies.Add(assembly);
                        }
                    }

                    Type pluginType = typeof(T);
                    ICollection<Type> pluginTypes = new List<Type>();
                    foreach (Assembly assembly in assemblies)
                    {
                        if (assembly != null)
                        {
                            Type[] types = assembly.GetTypes();

                            foreach (Type type in types)
                            {
                                if (type.IsInterface || type.IsAbstract)
                                {
                                    continue;
                                }
                                else
                                {
                                    if (type.GetInterface(pluginType.FullName) != null)
                                    {
                                        pluginTypes.Add(type);
                                    }
                                }
                            }
                        }
                    }

                    ICollection<T> plugins = new List<T>(pluginTypes.Count);
                    foreach (Type type in pluginTypes)
                    {
                        T plugin = (T)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }

                    return plugins;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool mf_IsAssembly(string dllFile)
        {
            try
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllFile);
                return true;

            }
            catch (Exception ex)
            {
                if (ex != null) return false;
                else return false;
            }
        }
    }
}
