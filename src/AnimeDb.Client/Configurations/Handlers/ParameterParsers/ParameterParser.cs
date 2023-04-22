using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations.Handlers.QueryParsers
{
    public class ParameterParser : IParameterParser
    {
        public IDictionary<string, object> Parse(string query)
        {
            var parameters = new Dictionary<string, object>();
            if (!query.Contains(".xaml?"))
                return parameters;

            var lenght = query.Length;
            var position = query.IndexOf(".xaml?") + 6;
            var queryString = query.Substring(position, lenght - position);
            var items = queryString.Split('&').Select(x => x.Split('='));

            foreach ( var item in items )
            {
                var key = item[0];
                var value = item[1];
                parameters[key] = value;
            }

            return parameters;
        }
    }
}
