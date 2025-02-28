using NotificationSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Tests
{
    public class DateExtensionsTests
    {
        [Theory]
        [InlineData("25-12-2025", "2025-12-25")]
        [InlineData("2025/12/25 14:30:00", "2025-12-25 14:30:00")]
        public void ParseCustomDate_ValidFormats_ReturnsExpectedDateTime(string input, string expected)
        {
            var result = input.ParseCustomDate();
            Assert.Equal(DateTime.Parse(expected), result);
        }

        [Fact]
        public void ParseCustomDate_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<ArgumentException>(() => "25-12-2025 14:30:00".ParseCustomDate());
        }

        [Fact]
        public void ParseCustomDate_InvalidDate_ThrowsFormatException()
        {
            Assert.Throws<ArgumentException>(() => "30-02-2025".ParseCustomDate()); // 30th February does not exist
        }

        [Fact]
        public void ParseCustomDate_NullString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ((string)null).ParseCustomDate());
        }

        [Fact]
        public void ParseCustomDate_EmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "".ParseCustomDate());
        }

        [Fact]
        public void ParseCustomDate_WhitespaceString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "   ".ParseCustomDate());
        }

        [Fact]
        public void ToStandardDateString_FormatDateCorrectly()
        {
            var date = new DateTime(2025, 12, 25);
            Assert.Equal("2025-12-25", date.ToStandardDateString());
        }
    }
}