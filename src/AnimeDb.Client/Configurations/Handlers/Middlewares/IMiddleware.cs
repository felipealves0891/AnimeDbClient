using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations.Handlers
{
    public interface IMiddleware
    {
        void Handle(object data, IDictionary<string, object> parameters);
    }
}
