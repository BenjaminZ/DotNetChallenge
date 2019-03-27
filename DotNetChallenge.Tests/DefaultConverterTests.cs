using DotNetChallenge.Application.Services;
using FluentAssertions;
using Xunit;

namespace DotNetChallenge.Tests
{
    public class DefaultConverterTests
    {
        private readonly IConverter _converter;

        public DefaultConverterTests()
        {
            _converter = new DefaultConverter();
        }

        [Theory]
        [InlineData(123.4, " cents")]
        [InlineData(123.01, " cent")]
        [InlineData(123, "")]
        public void CentWordTest(decimal input, string expected)
        {
            DefaultConverter.GetCentWord(input).Should().Be(expected);
        }

        [Theory]
        [InlineData(123.45, " and forty-five cents")]
        [InlineData(23.450, " and forty-five cents")]
        [InlineData(0.01, "one cent")]
        [InlineData(100, "")]
        public void DecimalWordTest(decimal input, string expected)
        {
            DefaultConverter.GetDecimalWord(input).Should().Be(expected);
        }

        [Theory]
        [InlineData(123.45, "one hundred and twenty-three dollars")]
        [InlineData(999999999999,
            "nine hundred and ninety-nine billion nine hundred and ninety-nine million nine hundred and ninety-nine thousand nine hundred and ninety-nine dollars")]
        [InlineData(1000012, "one million twelve dollars")]
        public void IntWordTest(decimal input, string expected)
        {
            DefaultConverter.GetIntWord(input).Should().Be(expected);
        }

        [Theory]
        [InlineData(0.12, "TWELVE CENTS")]
        [InlineData(0, "ZERO")]
        [InlineData(123, "ONE HUNDRED AND TWENTY-THREE DOLLARS")]
        [InlineData(10012, "TEN THOUSAND TWELVE DOLLARS")]
        [InlineData(999999999999.99,
            "NINE HUNDRED AND NINETY-NINE BILLION NINE HUNDRED AND NINETY-NINE MILLION NINE HUNDRED AND NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE DOLLARS AND NINETY-NINE CENTS")]
        public void AmountToStringTest(decimal input, string expected)
        {
            _converter.AmountToString(input).Should().Be(expected);
        }

        [Theory]
        [InlineData(123.4, " dollars")]
        [InlineData(1, " dollar")]
        [InlineData(10000, " dollars")]
        [InlineData(0, "")]
        public void DollarWordTest(decimal input, string expected)
        {
            DefaultConverter.GetDollarWord(input).Should().Be(expected);
        }

        [Theory]
        [InlineData(10, "ten")]
        [InlineData(19, "nineteen")]
        [InlineData(20, "twenty")]
        [InlineData(99, "ninety-nine")]
        public void TenWordsTest(int tens, string expected)
        {
            DefaultConverter.TensWords(tens).Should().Be(expected);
        }

        [Theory]
        [InlineData(3, "three")]
        public void DigitWordsTest(int digit, string expected)
        {
            DefaultConverter.DigitWords(digit).Should().Be(expected);
        }
    }
}