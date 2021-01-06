using System;
using System.Drawing;
using System.Data;

namespace IPlugin {

    public enum pluginType {
        Filter,
        Import,
        Export,
        Other,
        none
    }

    public enum pluginHook {
        All,
        Main,
        Queryer,
        Mover,
        Compare,
        CrossJoin,
        ForEach,
        none
    }

    public interface IPlugin {
        Image Icon();
        String Name { get; set; }
        String Description { get; set; }
        String Author { get; set; }
        String Version { get; set; }
        String Error { get; set; }
        pluginType Type { get; set; }
        pluginHook Hook { get; set; }

        DataTable Process(DataTable Data, String Arg);
    }
}
