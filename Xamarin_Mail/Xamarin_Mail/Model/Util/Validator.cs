using System;
using System.Text.RegularExpressions;

namespace Xamarin_Mail.Model.Util
{
    public class Validator
    {
        private static readonly Regex EmailAddress =
            new Regex(
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
                + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        public static bool MailIsValid(string login, string password)
        {
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(login))
            {
                return false;
            }

            if (!EmailAddress.IsMatch(login))
            {
                return false;
            }

            return true;
        }

        public static bool MailIsValid(string login)
        {
            if (String.IsNullOrEmpty(login))
            {
                return false;
            }

            if (!EmailAddress.IsMatch(login))
            {
                return false;
            }

            return true;
        }
    }
}
