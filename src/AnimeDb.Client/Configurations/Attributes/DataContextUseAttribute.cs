using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataContextUseAttribute : Attribute
    {
        public Type Context { get; private set; }

        public DataContextUseAttribute(Type context)
        {
            Context = context;
        }

    }
}
