using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrunchiVote.Infrastructure.ExtensionMethods;

internal static class TitleFormatter
{
   public static string FormatTitle(this string title)
    {
       return Regex.Replace(title,"&#8217;","'");
     
    }
}
