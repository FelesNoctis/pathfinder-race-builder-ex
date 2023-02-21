using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PathfinderSystem
{
    public static class Utils
    {
        private static readonly char[] separators = { ' ', '-', '_', '\'' };

        public static string Capitalize(string input, bool allWords = false)
        {
            if (input == null)
                return null;
            else if (allWords)
            {
                bool foundSeparator = true;
                StringBuilder sb = new StringBuilder(input);

                for (int i = 0; i < sb.Length; i++)
                {
                    if (foundSeparator)
                        sb[i] = char.ToUpper(sb[i]);
                    else
                        sb[i] = char.ToLower(sb[i]);

                    foundSeparator = Array.Exists<char>(separators, curChar => curChar == sb[i]);
                }

                return sb.ToString();
            }
            else if (input.Length > 1)
                return (char.ToUpper(input[0]) + input.Substring(1).ToLower());
            else
                return input.ToUpper();
        }

        public static string GetXMLNodeValue(XmlNode node, string xPath, string defaultValue = "")
        {
            XmlNode result = node.SelectSingleNode(xPath);

            if (result == null)
                return defaultValue;
            else
                return result.InnerXml;
        }

        public static TEnum ToEnum<TEnum>(string input)
        {
            input = input.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

            return (TEnum)Enum.Parse(typeof(TEnum), input);
        }

        public static TEnum ToEnum<TEnum>(string input, TEnum defaultValue)
        {
            input = input.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

            if (!Enum.IsDefined(typeof(TEnum), input))
                return defaultValue;

            return (TEnum)Enum.Parse(typeof(TEnum), input);
        }

        // http://www.codeproject.com/Articles/51488/Implementing-Word-Wrap-in-C
        public static string SimpleWordWrap(string text, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return text;

            // Parse each line of text
            for (pos = 0; pos < text.Length; pos = next)
            {
                // Find end of line
                int eol = text.IndexOf(Environment.NewLine, pos);
                if (eol == -1)
                    next = eol = text.Length;
                else
                    next = eol + Environment.NewLine.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;
                        if (len > width)
                            len = BreakLine(text, pos, width);
                        sb.Append(text, pos, len);
                        sb.Append(Environment.NewLine);

                        // Trim whitespace following break
                        pos += len;
                        while (pos < eol && Char.IsWhiteSpace(text[pos]))
                            pos++;
                    } while (eol > pos);
                }
                else sb.Append(Environment.NewLine); // Empty line
            }
            return sb.ToString();
        }

        private static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;

            // If no whitespace found, break at maximum length
            if (i < 0)
                return max;

            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;

            // Return length of text before whitespace
            return i + 1;
        }

        public static bool ArrayContains(Array testMe, object value)
        {
            for (int i = 0; i < testMe.Length; i++)
            {
                if (testMe.GetValue(i) == value)
                    return true;
            }

            return false;
        }

        public static int DieToIntHash(string die)
        {
            try
            {
                string[] split = die.Split(new char[] { 'd' }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length == 1)
                    return int.Parse(split[0]);
                else if (split.Length == 2)

                    return int.Parse(split[1]) | (int.Parse(split[0]) << 16);
                else
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Bad die string: " + die);
            }

            return 0;
        }

        public static string IntHashToDie(int dieHash)
        {
            int dieSize = dieHash & (int)(ushort.MaxValue);
            int dieCount = (dieHash >> 16) & (int)(ushort.MaxValue);

            if (dieCount == 0)
                return dieSize.ToString();
            else
                return dieCount.ToString() + 'd' + dieSize.ToString();
        }

        private static readonly string[,] dieSizeConversion =
        {
            { "1", "1d2" },
            { "1d2", "1d3" },
            { "1d3", "1d4" },
            { "1d4", "1d6" },
            { "1d6", "1d8" },
            { "1d8", "2d6" },
            { "1d10", "2d8" },
            { "1d12", "3d6" },
            { "2d4", "2d6" },
            { "2d6", "3d6" },
            { "2d8", "3d8" },
            { "2d10", "4d8" },
        };

        public static string ResizeDie(string dieString, Globals.Size targetSize)
        {
            int i;
            Globals.Size currentSize = Globals.Size.Medium;

            while (currentSize < targetSize)
            {
                for (i = 0; i < dieSizeConversion.GetLength(0); i++)
                {
                    if (dieSizeConversion[i, 0] == dieString)
                    {
                        dieString = dieSizeConversion[i, 1];
                        break;
                    }
                }

                currentSize++;
            }

            while (currentSize > targetSize)
            {
                for (i = 0; i < dieSizeConversion.GetLength(0); i++)
                {
                    if (dieSizeConversion[i, 1] == dieString)
                    {
                        dieString = dieSizeConversion[i, 0];
                        break;
                    }
                }

                currentSize--;
            }


            return dieString;
        }

        public static string PrerequisitesString(List<Prerequisite> list)
        {
            string result = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                    result += "; ";

                result += list[i].ToString();
            }

            return result;
        }
    }
}
