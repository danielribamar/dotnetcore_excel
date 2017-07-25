using Humanizer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VolvoCleaner.Web.Frontend.Business;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Helpers
{
    public static class ValuesHelper
    {
        public static NameGenderModel namesList;


        public static void RemoveWhiteSpaces(ref string value)
        {
            while (value.IndexOf("  ") >= 0)
            {
                value = value.Replace("  ", " ");
            }
            value = value.Trim();
        }
        public static void RemoveMultipleSpaces(ref string value)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            value = regex.Replace(value, " ");
        }
        public static void RemoveMultipleAndWhiteSpaces(ref string value)
        {
            RemoveWhiteSpaces(ref value);
            RemoveWhiteSpaces(ref value);
        }
        public static void RemoveSpecialCharacters(ref string value)
        {
            var list = new List<char>() { 'º', 'ª', '\'', '.', ',', '-', '!', '"', '#', '$', '%', '£', '@', '?', '=', ';', ':', '_', '*', '+', '>', '<', '|', '»', '«', '/', '\\' };
            foreach (char c in value)
            {
                if (list.Contains(c))
                {
                    value = value.Replace(c, ' ');
                }
            }
        }
        public static void RemoveSpecialCharacters(ref string value, List<char> list)
        {

            foreach (char c in value)
            {
                if (list.Contains(c))
                {
                    value = value.Replace(c, ' ');
                }
            }
        }
        public static void ToUpper(ref string value)
        {
            value = value.ToUpperInvariant();
        }
        public static void ToTitleCase(ref string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return;
                }

                str = str.ToLower().Transform(To.TitleCase);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void RemoveDiacritics(ref string value)
        {
            var normalizedString = value.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            value = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        public static void TruncateLongString(ref string str, int maxLength)
        {
            str = str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public static bool HasValidDate(string str)
        {
            DateTime date;
            if (DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool HasValidServiceType(string value)
        {
            if (DateTime.Now < new DateTime(2017, 03, 31))
            {
                var servicesList = new List<string>()
                {
                    "Maintenance","Warranty","Repair","Unspecified"
                };

                foreach (var model in servicesList)
                {
                    if (value.ToUpperInvariant().Contains(model.ToUpperInvariant()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void SetGender(ref string value, string firstname)
        {
            int gender;
            if (int.TryParse(value, out gender))
            {
                switch (gender)
                {
                    case 1:
                        value = "M";
                        break;
                    case 2:
                        value = "F";
                        break;
                    case 0:
                        value = "U";
                        break;
                    default:
                        value = "undefined";
                        break;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(firstname))
                {
                    value = "U";
                }

                var temp1 = firstname.Split(' ').First();
                RemoveDiacritics(ref temp1);

                var name = namesList.Names.FirstOrDefault(p => p.Name.Equals(temp1, StringComparison.OrdinalIgnoreCase));

                if (name != null && !string.IsNullOrEmpty(name.Gender))
                {
                    value = name.Gender;
                }
            }

            if (string.IsNullOrEmpty(value))
            {
                value = "U";
            }
        }
    }
}
