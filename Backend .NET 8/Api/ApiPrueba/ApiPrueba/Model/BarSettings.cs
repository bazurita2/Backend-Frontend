using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class BarSettings : IBarSettings
    {
        public string Server { set; get; }
        public string Database { set; get; }
    }

    public interface IBarSettings
    {
        string Server { set; get; }
        string Database { set; get; }
    }
}
