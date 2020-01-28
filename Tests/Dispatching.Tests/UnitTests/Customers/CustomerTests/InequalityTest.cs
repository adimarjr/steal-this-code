﻿using AutoFixture;
using Dispatching.Customers;
using Dispatching.Framework;
using Dispatching.TestFixtures.DomainObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dispatching.Tests.UnitTests.Customers.CustomerTests
{
    [TestClass]
    public class InequalityTest
    {
        private readonly Fixture _fixture = new Fixture();

        private Id<Customer> _id;

        [TestInitialize]
        public void Initialize()
        {
            _fixture.Customize(new LocationCustomization());

            _id = _fixture.Create<Id<Customer>>();
        }

        [TestMethod]
        public void WhenSame_ComparisonShouldBeFalse()
        {
            // Arrange
            var customer = new Customer(_id);
            var sameCustomer = new Customer(_id);

            // Act
            var actual = customer != sameCustomer;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNotSame_ComparisonShouldBeTrue()
        {
            // Arrange
            var customer = _fixture.Create<Customer>();
            var sameCustomer = _fixture.Create<Customer>();

            // Act
            var actual = customer != sameCustomer;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenReferenceToSameObject_ComparisonShouldBeTrue()
        {
            // Arrange
            var customer = _fixture.Create<Customer>();

            // Act
            var actual = customer != customer;

            // Assert
            actual.Should().BeFalse();
        }
    }
}
