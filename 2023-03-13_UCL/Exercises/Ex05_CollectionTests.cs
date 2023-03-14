﻿using System;
using System.Configuration;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex05_CollectionTests
    {
        [Fact]
        public void Sortedness()
        {
            // result should be sorted in ascending order

            // Arrange
            var result = new[] { 41, 42, 43 };

            // Assert
            result.Should().NotBeNull().And.ContainInOrder(new[] {41,42,43});
            
            //throw new NotImplementedException();
        }

        [Fact]
        public void CollectionEquality()
        {
            // The two collections should be identical,
            // i.e. contain the same members in the same order

            // Arrange
            var expected = new[] { 41, 42, 43 };

            // Act
            var result = new[] { 41, 42, 43 };

            // Assert
            result.Should().NotBeNull().And.ContainInOrder(expected);
            
        }

        [Fact]
        public void CollectionEquality_ByProperty()
        {
            // 'expected' and 'result' should again be identical,
            // but only regarding the 'Name' property.

            // Arrange
            var expected = new[]
            {
                new Person
                {
                    Name = "John"
                }
            };

            // Act
            Person[] result = GetPersons();

            // Assert
            result.Should().NotBeNullOrEmpty().And.AllSatisfy(x =>
            {
                x.Name.Should().Be(expected[0].Name);
            });
            //throw new NotImplementedException();
        }

        [Fact]
        public void GetObjects_has_exactly_2_items()
        {
            // Arrange
            int expectedCount = 2;

            // Act
            object[] objects = GetObjects();

            // Assert
            objects.Should().HaveCount(expectedCount);
            //throw new NotImplementedException();
        }

        [Fact]
        public void GetObjects_SatisfyRespectively()
        {
            // * The first item should be a string of length 2
            // * The second item should be equal to 42
            // See example of SatisfyRespectively on https://fluentassertions.com/collections/

            // Arrange
            int expectedLength = 2;
            int expectedNumber = 42;

            // Act
            object[] objects = GetObjects();
            
            // Assert
            objects.Should().SatisfyRespectively(
                first => {
                    first.As<String>().Should().HaveLength(2);
                    
                    },
                second => {
                    second.As<int>().Should().Be(expectedNumber);
                });
            //throw new NotImplementedException();
        }

        [Fact]
        public void BeEquivalentTo_WithoutOrder()
        {
            // Arrange
            var expected = new object[] { 42, "42" };

            // Act
            object[] objects = GetRandomObjects();

            // Assert
            objects.Should().HaveCount(expected.Length).And.BeSubsetOf(expected);
            //throw new NotImplementedException();
        }

        [Fact]
        public void BeEquivalentTo_WithStrictOrder()
        {
            // Arrange
            object[] expectedNumbers = new object[] { "42", 42 };

            // Act
            object[] objects = GetObjects();

            // Assert
            objects.Should().BeEquivalentTo(expectedNumbers);
            //throw new NotImplementedException();
        }

        #region Helpers
        private static Person[] GetPersons() =>
            new Person[] { new() { Name = "John", Company = "Refsvindinge Bryggeri" } };

        private class Person
        {
            public string Name { get; set; }

            public string Company { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Person person
                    && Name == person.Name
                    && Company == person.Company;
            }

            public override int GetHashCode() => HashCode.Combine(Name, Company);
        }

        private static object[] GetObjects() => new object[] { "42", 42 };

        private static object[] GetRandomObjects() =>
            new Random().Next(0, 1) > 0
            ? new object[] { "42", 42 }
            : new object[] { 42, "42" };
        #endregion
    }
}
