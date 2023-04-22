using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Models
{
    public class Payload<T>
    {
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        public Meta? Meta { get; set; }
    }
}
