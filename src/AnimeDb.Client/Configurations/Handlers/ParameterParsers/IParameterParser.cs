using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations.Handlers.QueryParsers
{
    public interface IParameterParser
    {
        IDictionary<string, object> Parse(string query);
    }
}
