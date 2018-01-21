using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBox.Common
{
    public class DBXParameters : List<KeyValuePair<string, object>>
    {
        public DBXParameters Add(string name, object value)
        {
            Add(new KeyValuePair<string, object>(name, value));
            return this;
        }
    }
}
