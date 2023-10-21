using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DBMStest")]
namespace LocalDBMS
{

    internal class Int : SupportedType
    {
        internal const string TypeValue = "int";

        public Int() { }
        public Int(string input)
        {
            if (System.Int32.TryParse(input, out int v))
                Value = v;
        }

        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            return this.Value == (p as Int)!.Value;

        }
        public bool isInvalid() {  return this.Value == null; }

        public string stringOutput()
        {
            if (this.isInvalid()) return string.Empty;

            return Value.ToString()!;
        }

        public string Type { get; } = TypeValue;
        public int? Value { get; set; } = null;
    }
}
