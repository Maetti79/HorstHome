using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;
using IPlugin;

namespace FritzHome
{

    public class PluginCore
    {

        public PluginCore(String pPathToPlugins)
        {
            Plugins = new Dictionary<string, object>();
            LoadPlugins(pPathToPlugins);
        }

        private static Dictionary<string, object> GetModul(string pFileName, Type pTypeInterface)
        {
            Dictionary<string, object> interfaceinstances = new Dictionary<string, object>();
            Assembly assembly = Assembly.LoadFrom(pFileName);
            // http://msdn.microsoft.com/de-de/library/t0cs7xez.aspx
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsPublic)
                {
                    if (!type.IsAbstract)
                    {
                        Type typeInterface = type.GetInterface(pTypeInterface.ToString(), true);
                        if (typeInterface != null)
                        {
                            try
                            {
                                object activedInstance = Activator.CreateInstance(type);
                                if (activedInstance != null)
                                {
                                    interfaceinstances.Add(type.Name, activedInstance);
                                }
                            }
                            catch (Exception exception)
                            {
                                System.Diagnostics.Debug.WriteLine(exception);
                            }
                        }
                        typeInterface = null;
                    }
                }
            }
            assembly = null;
            return interfaceinstances;
        }

        public void LoadPlugins(String pPluginPath)
        {
            String[] files = Directory.GetFiles(pPluginPath);
            foreach (String file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension.Equals(".dll"))
                {
                    Dictionary<string, object> dictionary = GetModul(file, typeof(IPlugin.IPlugin));
                    foreach (var a in dictionary)
                    {
                        Plugins.Add(a.Key, a.Value);
                    }
                }
            }
        }

        public Dictionary<string, object> Plugins { get; protected set; }

        public Array getPlugins()
        {
            return Plugins.Keys.ToArray();
        }

        public Array getPlugins(string license)
        {
            Array pls = Plugins.Keys.ToArray();
            for (int i = 0; i < pls.Length; i++)
            {
                if (license.Contains(pls.GetValue(i).ToString()) == false)
                {
                    pls.SetValue("", i);
                }

            }
            return pls;
        }

        private IPlugin.IPlugin GetPlugin(string pluginName)
        {
            foreach (var dir in Plugins)
            {
                IPlugin.IPlugin plugin = dir.Value as IPlugin.IPlugin;
                if (plugin.Name.ToLower().Equals(pluginName.ToLower()))
                {
                    return plugin;
                }
            }
            return null;
        }


        public Image Icon(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Icon();
            }
            else
            {
                return null;
            }
        }

        public string Name(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Name;
            }
            else
            {
                return "";
            }
        }

        public string Description(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Description;
            }
            else
            {
                return "";
            }
        }

        public string Author(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Author;
            }
            else
            {
                return "";
            }
        }

        public string Version(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Version;
            }
            else
            {
                return "";
            }
        }

        public pluginType Type(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Type;
            }
            else
            {
                return pluginType.none;
            }
        }

        public pluginHook Hook(string pInput)
        {
            if (pInput.Length > 0)
            {
                IPlugin.IPlugin plugin = GetPlugin(pInput);
                return plugin.Hook;
            }
            else
            {
                return pluginHook.none;
            }
        }

        public DataTable Process(string pluginName, DataTable Data, String Arg)
        {
            IPlugin.IPlugin plugin = GetPlugin(pluginName);
            Data = plugin.Process(Data, Arg);
            return Data;
        }

    }

}
