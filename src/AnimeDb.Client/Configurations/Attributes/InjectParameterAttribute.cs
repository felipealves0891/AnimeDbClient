using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class InjectParameterAttribute : Attribute
    {
        public string Key { get; set; }

        public InjectParameterAttribute(string key)
        {
            Key = key;
        }
    }
}
