using System;
using ECommerce.Web.Constants;

namespace ECommerce.Web.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitBySingleSpace(this string text)
        {
            return text.Split(ECommerceConstants.CommandSplitCharacter, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] SplitByNewLine(this string text)
        {
            return text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
