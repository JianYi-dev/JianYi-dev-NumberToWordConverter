using System.Collections.Generic;

namespace NumberToWordConverter.Manager
{
    public class ConverterManager
    {
        private static readonly string[] UNITS = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
        private static readonly string[] TEENS = { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static readonly string[] TENS = { "", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        private static readonly string[] POWERS_OF_TEN_BY_THREE = { "", " THOUSAND", " MILLION", " BILLION", " TRILLION", " QUADRILLION" };

        public static string ConvertNumberToString(decimal amount)
        {
            if (amount == 0)
                return "ZERO DOLLARS";

            string translatedString = string.Empty;

            string[] parts = amount.ToString().Split('.');
            string integerPart = parts[0] != null && parts[0] != "" 
                ? parts[0]
                : "0";
            string decimalPart = parts.Length > 1 && parts[1] != null && parts[1] != "" && parts[1] != "00"
                ? parts[1] 
                : "0";

            // INTEGER PART CONVERSION
            if (integerPart != "0")
            {
                List<int> numberList = new List<int>();

                for (int i = integerPart.Length - 3; i >= 0; i -= 3)
                {
                    numberList.Add(int.Parse(integerPart.Substring(i, 3)));
                }
                if (integerPart.Length % 3 != 0)
                {
                    int remainingSubstring = int.Parse(integerPart.Substring(0, integerPart.Length % 3));
                    numberList.Add(remainingSubstring);
                }

                for (int i = numberList.Count - 1; i > -1; i--)
                {
                    int threeDigitNumber = numberList[i];
                    if (threeDigitNumber != 0)
                    {
                        translatedString += ConvertHundredToWords(threeDigitNumber) + POWERS_OF_TEN_BY_THREE[i] + (i == 0 ? " DOLLARS" : " ");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            translatedString += "DOLLARS";
                        }
                    }
                    
                }
            }           

            // DECIMAL PART CONVERSION
            if (decimalPart != "0")
            {
                int decimalAmount = int.Parse(decimalPart);
                if (translatedString == string.Empty)
                {
                    translatedString += ConvertHundredToWords(decimalAmount) + " CENTS";
                }
                else
                {
                    translatedString += " AND " + ConvertHundredToWords(decimalAmount) + " CENTS";
                }
            }

            return translatedString.Trim();
        }

        public static string ConvertHundredToWords(int amount)
        {
            string translation = string.Empty;
            // Example: 789
            if (amount > 100)
            {
                translation += ConvertUnitIntegerToWords(amount / 100) + " HUNDRED ";
                amount %= 100;
            }

            if (amount > 0)
            {
                if (translation != string.Empty)
                    translation += "AND ";

                // 0-9
                if (amount < 10)
                    translation += ConvertUnitIntegerToWords(amount);
                // 10-19
                else if (amount < 20)
                    translation += ConvertTeenIntegerToWords(amount % 10);
                // 20-99
                else
                {
                    translation += ConvertTenIntegerToWords(amount / 10);
                    if ((amount % 10) > 0)
                    {
                        translation += "-" + ConvertUnitIntegerToWords(amount % 10);
                    }
                }
            }

            return translation;
        }

        private static string ConvertUnitIntegerToWords(int unit)
        {
            string word = UNITS[unit];
            return word;
        }

        private static string ConvertTeenIntegerToWords(int teen)
        {
            string word = TEENS[teen];
            return word;
        }

        private static string ConvertTenIntegerToWords(int ten)
        {
            string word = TENS[ten];
            return word;
        }
    }
}