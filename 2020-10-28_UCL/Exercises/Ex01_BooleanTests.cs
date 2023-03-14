﻿using System;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex01_BooleanTests
    {
        [Fact]
        public void CanBuyAlcohol_Adult_Allowed()
        {
            // Arrange
            var person = new Person
            {
                Age = 18
            };

            // Act
            bool result = CanBuyAlcohol(person);

            // Assert
            throw new NotImplementedException();
        }

        [Fact]
        public void CanBuyAlcohol_Child_Disallowed()
        {
            // Arrange
            var person = new Person
            {
                Age = 5
            };

            // Act
            bool result = CanBuyAlcohol(person);

            // Assert
            throw new NotImplementedException();
        }

        #region Helpers
        private static bool CanBuyAlcohol(Person person) => person.Age >= 18;

        private class Person
        {
            public int Age { get; set; }
        }
        #endregion
    }
}
