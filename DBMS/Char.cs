using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DBMStest")]
namespace LocalDBMS
{
    internal class Char : SupportedType
    {
        internal const string TypeValue = "char";

        public Char() { }
        public Char(string input)
        {
            var chars = input.Where(c => !System.Char.IsWhiteSpace(c));
            if (chars.Count() == 1)
                Value = chars.First();
        }
        public bool Equals(SupportedType p)
        {
            if (p.Type != Type || p == null)
                return false;
            return this.Value == (p as Char)!.Value;

        }
        public bool isInvalid() { return this.Value == null; }

        public string stringOutput()
        {
            if(this.isInvalid()) return string.Empty;

            return Value.ToString()!;
        }
        public string Type { get; } = TypeValue;
        public char? Value { get; set; } = null;
    }
}
