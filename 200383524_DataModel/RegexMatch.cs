using System;
using System.Text.RegularExpressions;

namespace _200383524_DataModel
{
    public class RegexMatch
    {
        private static Regex _nameRegex = new Regex(@"[a-zA-Z\ ]+"); // only letters are accepted for names
        private static Regex _emailRegex = new Regex(@"^([\w\.\-]+)\@([\w\-]+)\.([\.\w\-]+)$"); // looks for @ after some characters and then looks for . and multiple .'s are possible.

        /// <summary>
        /// Returns true if regex matches to name pattern
        /// </summary>
        /// <param name="text"></param>
        /// <returns>bool</returns>
        public static bool NameMatchesRegex(string text)
        {
            var match = _nameRegex.Match(text);

            return match.Success;
        }

        /// <summary>
        /// Returns true if regex matches to email pattern
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        public static bool EmailMatchesRegex(string email)
        {
            var match = _emailRegex.Match(email);

            return match.Success;
        }

    }

}