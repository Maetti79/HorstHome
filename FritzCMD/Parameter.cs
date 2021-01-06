using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FritzCMD
{
    class Parameter : IDisposable
    {
        public Dictionary<String, String> Arguments = new Dictionary<String, String>();

        private const string Pattern = @"\/(?<argname>\w+):(?<argvalue>.+)";
        private readonly Regex _regex = new Regex( Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly Dictionary<String, String> _args = new Dictionary<String, String>();
        
        public Parameter()
        {
            Arguments.Add("FritzBox", "http://fritz.box/");
            Arguments.Add("SID", "");
            Arguments.Add("Username", "");
            Arguments.Add("Password", "");
            Arguments.Add("Device", "");
            Arguments.Add("Command", "");
            Arguments.Add("Value", "");
        }

        public Parameter(string[] args)
        {
            
            Arguments.Add("FritzBox", "http://fritz.box/");
            Arguments.Add("SID", "");
            Arguments.Add("Username", "");
            Arguments.Add("Password", "");
            Arguments.Add("Device", "");
            Arguments.Add("Command", "");
            Arguments.Add("Value", "");

            BuildArgDictionary(args);

            foreach (KeyValuePair<String, String> arg in _args) {
                if (Arguments.Keys.Contains(arg.Key)) {
                    Arguments[arg.Key] = arg.Value;
                }
            }
        }

        public string this[string key]
        {
            get
            {
                return _args.ContainsKey(key) ? _args[key] : null;
            }
        }

        public bool ContainsKey(string key)
        {
            return _args.ContainsKey(key);
        }

        private void BuildArgDictionary(string[] args)
        {

            foreach (var match in args.Select(arg => _regex.Match(arg)).Where(m => m.Success))
            {
                try
                {
                    _args.Add( match.Groups["argname"].Value, match.Groups["argvalue"].Value);
                }
                // Ignore any duplicate args
                catch (Exception) { }
            }
        }

        public void Dispose()
        {

        }

        ~Parameter()
        {

        }
    }

}
