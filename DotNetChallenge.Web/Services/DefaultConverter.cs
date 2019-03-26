using System;

namespace DotNetChallenge.Web.Services
{
    public class DefaultConverter : IConverter
    {
        public string AmountToString(decimal amountNum)
        {
            if (amountNum < 0 || amountNum > (long) (Math.Pow(10, 13) - 1))
                throw new ArgumentOutOfRangeException(
                    $"{nameof(amountNum)} should be no less than 0, and less then 1,000,000,000,000");
            if (amountNum == 0)
                return "ZERO";

            var intWord = GetIntWord(amountNum);
            var decimalWord = GetDecimalWord(amountNum);

            return $"{intWord}{decimalWord}".ToUpperInvariant();
        }

        public static string GetIntWord(decimal amount)
        {
            var value = (long) Math.Floor(amount);
            if (value == 0) return string.Empty;

            var intWord = GetIntWord(value, string.Empty, 0);
            var dollarWord = GetDollarWord(amount);

            return $"{intWord}{dollarWord}";
        }

        private static string GetIntWord(long value, string result, int count)
        {
            // trim end space
            if (value == 0) return result.Trim();

            // up to 999 billion
            if (value > (long) (Math.Pow(10, 13) - 1))
                throw new ArgumentOutOfRangeException($"{nameof(value)} should between 0 to 999,999,999,999");

            // if this iteration number is 0, skip
            if (value % 1000 == 0) return GetIntWord(value / 1000, result, ++count);

            var tens = value % 100;
            var tensWord = string.Empty;
            if (tens != 0) tensWord = $"{BelowHundred((int) tens)}";
            var hundred = value % 1000 - tens;
            var hundredWord = string.Empty;
            if (hundred != 0) hundredWord = $"{DigitWords((int) hundred / 100)} hundred";

            var andWord = string.Empty;
            var thousandWord = string.Empty;

            if (!string.IsNullOrEmpty(tensWord) && hundred != 0) andWord = " and ";

            // if this iteration is not the first, there is a thousand word
            if (count != 0) thousandWord = $" {((Thousands) count).ToString()}";

            var thisResult = $"{hundredWord}{andWord}{tensWord}{thousandWord} {result}";

            return GetIntWord(value / 1000, thisResult, ++count);
        }

        public static string GetDecimalWord(decimal amount)
        {
            // decimal digits over 2 is floor to 2
            var value = (int) Math.Floor(amount * 100 - Math.Floor(amount) * 100);
            if (value == 0) return string.Empty;
            var centWord = GetCentWord(amount);
            var andWord = string.Empty;
            // has int
            if (Math.Floor(amount) != 0) andWord = " and ";

            return $"{andWord}{BelowHundred(value)}{centWord}";
        }

        private static string BelowHundred(int belowHundred)
        {
            if (belowHundred < 1 || belowHundred > 99) throw new ArgumentOutOfRangeException();

            return belowHundred < 10 ? DigitWords(belowHundred) : TensWords(belowHundred);
        }

        // No space on left
        public static string DigitWords(int digit)
        {
            if (digit > 9 || digit < 1) throw new ArgumentOutOfRangeException($"{nameof(digit)} should between 1 to 9");

            return ((Digits) digit).ToString();
        }

        public static string TensWords(int tens)
        {
            if (tens >= 10 && tens <= 19) return BelowTwenty(tens);

            if (tens >= 20 && tens <= 99) return AboveTwenty(tens);

            throw new ArgumentOutOfRangeException($"{nameof(tens)} should between 10 to 99");
        }

        private static string BelowTwenty(int tensBelowTwenty)
        {
            if (tensBelowTwenty < 10 || tensBelowTwenty > 19)
                throw new ArgumentOutOfRangeException($"{nameof(tensBelowTwenty)} should between 10 to 19");

            return $"{(TensBelowTwenty) tensBelowTwenty}";
        }

        private static string AboveTwenty(int tensAboveTwenty)
        {
            if (tensAboveTwenty < 20 || tensAboveTwenty > 99)
                throw new ArgumentOutOfRangeException($"{nameof(tensAboveTwenty)} should between 20 to 99");

            var ten = tensAboveTwenty / 10;
            var digit = tensAboveTwenty % 10;
            var digitWords = digit == 0 ? string.Empty : $"-{DigitWords(digit)}";
            return $"{((TensAboveTwenty) ten).ToString()}{digitWords}";
        }

        public static string GetCentWord(decimal amount)
        {
            var value = amount - Math.Floor(amount);

            if (value == 0) return string.Empty;
            if (value == 0.01m) return " cent";
            return " cents";
        }

        public static string GetDollarWord(decimal amount)
        {
            var dollarDigit = (long) amount % 10;
            switch (dollarDigit)
            {
                case 1:
                    return " dollar";
                case 0:
                    return string.Empty;
                default:
                    return " dollars";
            }
        }
    }
}