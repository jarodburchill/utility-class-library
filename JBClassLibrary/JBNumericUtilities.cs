using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBClassLibrary
{
    /// <summary>
    /// This class is to provide utilities and validations 
    /// for numeric fields or feilds that contain numerics
    /// Jarod Burchill April 2, 2018
    /// </summary>
    public static class JBNumericUtilities
    {
        /// <summary>
        /// accepts a string parameter
        /// returns true if the parameter contains only a number.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBIsNumeric(string input)
        {
            Regex pattern = new Regex(@"^-?(\d+\.?\d*|\.\d+)$");
            return pattern.IsMatch(input);
        }
        /// <summary>
        /// accepts an object parameter
        /// returns true if the parameter contains only a number.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBIsNumeric(object input)
        {
            return JBIsNumeric(input.ToString());
        }
        /// <summary>
        /// accepts a string parameter
        /// returns true if the parameter contains only an int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBIsInteger(string input)
        {
            return JBIsNumeric(input) && !input.Contains(".");
        }
        /// <summary>
        /// accepts a double parameter
        /// returns true if the parameter contains only an int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBIsInteger(double input)
        {
            return Math.Truncate(input) == input;
        }
        /// <summary>
        /// accepts an object parameter
        /// returns true if the parameter contains only an int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBIsInteger(object input)
        {
            return JBIsInteger(input.ToString());
        }
        /// <summary>
        /// returns the string less everything 
        /// except digits, the decimal place and a dash. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBNumberReformat(string input)
        {
            input = Regex.Replace(input, @"[^0-9.-]", "");
            if (input.EndsWith("-") && !input.StartsWith("-"))
            {
                input = input.Remove(input.LastIndexOf("-"));
                input = input.Insert(0, "-");
            }
            if (JBIsNumeric(input))
            {
                return input;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// If the property KeyChar is not a digit, set the property Handled to true.
        /// </summary>
        public static void JBDigitOnlyKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }

}
