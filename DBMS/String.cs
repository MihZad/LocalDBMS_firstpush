using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DBMStest")]

namespace LocalDBMS
{
    internal class String : SupportedType
    {
        internal const string TypeValue = "string";

        public String() { }
        public String(string input) { Value = input; }
        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            return this.Value == (p as String)!.Value;

        }
        public bool isInvalid() { return this.Value == null; }

        public string stringOutput()
        {
            if(this.isInvalid()) return string.Empty;

            return Value!;
        }

        public string Type { get; } = TypeValue;
        public string? Value { get; set; } = null;
    }
}
