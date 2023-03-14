using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Exercises
{
    public class Ex06_DictionaryTests
    {
        [Fact]
        public void Translating_1337_to_leet_speak_is_leet()
        {
            // Arrange
            var expectedKey = 1337;
            var expectedValue = "leet";

            // Act
            KeyValuePair<int, string> leetItem = new KeyValuePair<int, string>(expectedKey, expectedValue);
            Dictionary<int, string> leetSpeak = GetLeetSpeak();

            // Assert
            leetSpeak.Should().NotBeNull().And.Contain(leetItem);
            //throw new NotImplementedException();
        }

        #region Helpers
        private static Dictionary<int, string> GetLeetSpeak() => new()
        {
            [1337] = "leet"
        };
        #endregion
    }
}
