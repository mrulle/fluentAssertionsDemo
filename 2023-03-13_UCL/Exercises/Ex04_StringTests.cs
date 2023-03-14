using System;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex04_StringTests
    {
        [Fact]
        public void A_default_person_has_a_non_empty_star_sign()
        {
            // Arrange
            var person = new Person();

            // Act
            string starSign = person.GetStarSign();

            // Assert
            starSign.Should().NotBeNull().And.NotBeEmpty();
            //throw new NotImplementedException();
        }

        [Fact]
        public void This_test_framework_ignoring_casing_is_xunit()
        {
            // Arrange
            string expectedFrameworkName = "xunit";

            // Act
            string frameworkName = GetTestFramework();

            // Assert
            frameworkName.Should().BeEquivalentTo(expectedFrameworkName);
            //throw new NotImplementedException();
        }

        [Fact]
        public void Donald_Duck_has_a_nephew_named_Louie()
        {
            // Arrange
            string expectedNephew = "Louie";

            // Act
            string[] nephews = GetNephewsOfDonaldDuck();

            // Assert
            nephews.Should().NotBeNullOrEmpty().And.Contain(expectedNephew);
            //throw new NotImplementedException();
        }

        [Fact]
        public void The_Danish_alphabeth_has_29_letters()
        {
            // Arrange
            int expectedLength = 29;

            // Act
            string alphabet = GetDanishAlphabeth();

            // Assert
            alphabet.Should().NotBeNullOrEmpty().And.HaveLength(expectedLength);
            //throw new NotImplementedException();
        }

        [Fact]
        public void The_error_message_matches_Foo_and_Bar_in_that_order()
        {
            // Act
            string errorMessage = GetErrorMessage();

            // Assert
            errorMessage.Should().NotBeNullOrEmpty().And.ContainAll(new[] {"Foo", "Bar"});
            //throw new NotImplementedException();
        }

        #region Helpers
        private class Person
        {
            public string GetStarSign() => "Taurus";
        }

        public static string GetTestFramework() => "xUniT";

        public static string[] GetNephewsOfDonaldDuck() => new[] { "Huey", "Louie", "Dewey" };

        public static string GetDanishAlphabeth() => "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";

        public static string GetErrorMessage() => "Yada Yada Foo Yada Yada Bar Yada Yada";
        #endregion
    }
}
