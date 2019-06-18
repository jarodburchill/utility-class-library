/*
Jarod Burchill 
April 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JBClassLibrary
{
    /// <summary>
    /// This class is to provide validations 
    /// for everyday things like phone numbers and 
    /// postal codes.
    /// Jarod Burchill April 19, 2018
    /// </summary>
    public static class JBValidations
    {
        /// <summary>
        /// Validates postal code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBCanadianPostalCodeValidation(string input)
        {
            Regex postalCodePattern = new Regex(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][ ||-]?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", RegexOptions.IgnoreCase);
            return postalCodePattern.IsMatch(input);
        }
        /// <summary>
        /// Validates US zip code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBUnitedStatesZipCodeValidation(string input)
        {
            return Regex.IsMatch(input, @"(^\d{5}$)|(^\d{5}[- ]?\d{4}$)");
        }
        /// <summary>
        /// Validates phone numbers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool JBPhoneNumberValidation(string input)
        {
            Regex phoneNumberPattern = new Regex(@"^(\(?\d{3}\)?(\-?| ?)\d{3}(\-?| ?)\d{4})$");
            return phoneNumberPattern.IsMatch(input);
        }
    }
}
