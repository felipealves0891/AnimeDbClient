using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Models
{
    public class Meta
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int TotalPage { get; set; }

        public int TotalData { get; set; }
    }
}
