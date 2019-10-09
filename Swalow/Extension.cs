using Swalow.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Swalow
{
    public static class Extension
    {
        public static bool IsAssemblyClass(this member member, string str)
        {
            return (String.IsNullOrWhiteSpace(member.name)) ? false : new Regex(@"^T:OUR_ASSEMBLY.[^.]*\z").IsMatch(member.name);
        }

        public static bool IsClassFeature(this member member, string str)
        {
            return (String.IsNullOrWhiteSpace(member.name)) ? false : new Regex(@"^T:OUR_ASSEMBLY.[^.]*\z").IsMatch(member.name);
        }

        public static bool IsClassMethod(this member member, string str)
        {
            return (String.IsNullOrWhiteSpace(member.name)) ? false : new Regex(@"^T:OUR_ASSEMBLY.[^.]*\z").IsMatch(member.name);
        }
    }
}
