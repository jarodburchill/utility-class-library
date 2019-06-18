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
    /// This class is to provide utilities and validations 
    /// for string fields or feilds that contain strings
    /// Jarod Burchill April 19, 2018
    /// </summary>
    public static class JBStringUtilities
    {
        /// <summary>
        /// Accepts a string as a parameter
        /// Return the capitalized string.  
        /// If the original string was null, returns null
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBCapitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
                string[] splitArray = input.Trim().ToLower().Split(' ');
                input = "";
                for (int i = 0; i < splitArray.Length; i++)
                {
                    try
                    {
                        string firstLetter = splitArray[i].Substring(0, 1).ToUpper();
                        splitArray[i] = firstLetter + splitArray[i].Substring(1);
                        input += $"{splitArray[i]} ";
                    }
                    catch
                    {
                        input += "";
                    }
                }
                return input;
            }
        }
        /// <summary>
        /// accepts a string parameter and returns 
        /// a string with just the digits from it
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBKeepDigitsOnly(string input)
        {
            return input = Regex.Replace(input, @"[^0-9]", "");
        }
        /// <summary>
        /// Validates Postal Code
        /// Reformats Postal Code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBCanadianPostalCodeFormat(string input)
        {
            if (JBValidations.JBCanadianPostalCodeValidation(input))
            {
                input = input.Replace(" ", "").Replace("-","");
                input = input.Insert(3, " ");
                return input.ToUpper();
            }
            else
            {
                throw new Exception("Postal code could not be reformatted\nbecause it is not a valid postal code.");
            }
        }
        /// <summary>
        /// Validates US Zip Code
        /// Reformats US Zip Code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBUnitedStatesZipCodeFormat(string input)
        {
            if (JBValidations.JBUnitedStatesZipCodeValidation(input))
            {
                if (input.Length > 5)
                {
                    input = input.Replace(" ", "").Replace("-", "");
                    input = input.Insert(5, "-");
                }
                return input.ToUpper();
            }
            else
            {
                throw new Exception("Zip code could not be reformatted\nbecause it is not a valid zip code.");
            }
        }
        /// <summary>
        /// Validates Phone Number
        /// Reformats Phone Number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JBPhoneNumberFormat(string input)
        {
            if (JBValidations.JBPhoneNumberValidation(input))
            {
                input = input.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")","");
                input = input.Insert(3, "-").Insert(7,"-");
                return input.ToUpper();
            }
            else
            {
                throw new Exception("Phone number could not be reformatted\nbecause it is not a valid phone number.");
            }
        }
        /// <summary>
        /// accepts two strings (any case): 
        /// one the first name, one the last name, 
        /// and returns the full name, capitalized, 
        /// in the form: lastName, firstName.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string JBFullName(string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(lastName))
            {
                return null;
            }
            else if (String.IsNullOrEmpty(firstName))
            {
                return JBCapitalize(lastName);
            }
            else if (String.IsNullOrEmpty(lastName))
            {
                return JBCapitalize(firstName);
            }
            else
            {
                return JBCapitalize($"{lastName}, {firstName}");
            }
            
        }
    }
}
