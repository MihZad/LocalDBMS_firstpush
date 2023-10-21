using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBMS
{
    public static class SupportMethods
    {
        public static SupportedType? createSupportedTypeInstance(string type, string input)
        {
            SupportedType v;
            switch (type)
            {
                case Int.TypeValue: v = new Int(input); break;
                case Real.TypeValue: v = new Real(input); break;
                case Char.TypeValue: v = new Char(input); break;
                case String.TypeValue: v = new String(input); break;
                case CharInvl.TypeValue: v = new CharInvl(input); break;
                case StringInvl.TypeValue: v = new StringInvl(input); break;
                default: return null;
            }
            return v;
        }
    }
}
