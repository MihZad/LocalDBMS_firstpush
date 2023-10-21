using System.Globalization;

namespace DBMStest
{
    public class Tester
    {
        [Fact]
        public static void test_int()
        {
            string s = "155232323";
            var i = new LocalDBMS.Int(s);
            Assert.False(i.isInvalid());
        }

        [Fact]
        public static void test_char()
        {
            string s = "a";
            var i = new LocalDBMS.Char(s);
            Assert.False(i.isInvalid());
        }

        [Fact]
        public static void test_charinvl()
        {
            string s = "a, b";
            var i = new LocalDBMS.CharInvl(s);
            Assert.False(i.isInvalid());
        }

        [Fact]
        public static void test_real()
        {
            string s = "12142,40";
            var i = new LocalDBMS.Real(s);
            Assert.False(i.isInvalid());
        }

        [Fact]
        public static void test_string()
        {
            string s = "12142.40afff";
            var i = new LocalDBMS.String(s);
            Assert.False(i.isInvalid());
        }

        [Fact]
        public static void test_stringinvl()
        {
            string s = "a,b; c,d; e,f; g,h";
            var i = new LocalDBMS.StringInvl(s);
            Assert.False(i.isInvalid());
        }
    }
}