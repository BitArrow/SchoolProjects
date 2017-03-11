using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Should_Have_FirstName()
        {
            var sut = new Person()
            {
                FirstName = "Tauri"
            };

            Assert.Equal("Tauri", sut.FirstName);
        }

        [Fact]
        public void Should_Trim_FirstName()
        {
            var sut = new Person()
            {
                FirstName = "    Tauri    "
            };

            Assert.Equal("Tauri", sut.FirstName);
        }

        [Fact]
        public void Should_Have_LastName()
        {
            var sut = new Person()
            {
                LastName = "Busch"
            };

            Assert.Equal("Busch", sut.LastName);
        }

        [Fact]
        public void Should_Trim_LastName()
        {
            var sut = new Person()
            {
                LastName = "    Busch    "
            };

            Assert.Equal("Busch", sut.LastName);
        }

        [Fact]
        public void Should_Have_FirstLastName()
        {
            var sut = new Person()
            {
                FirstName = "Tauri",
                LastName = "Busch"
            };

            Assert.Equal("Tauri Busch", sut.FirstLastName);
        }

        [Fact]
        public void Should_Have_LastFirstName()
        {
            var sut = new Person()
            {
                FirstName = "Tauri",
                LastName = "Busch"
            };

            Assert.Equal("Busch Tauri", sut.LastFirstName);
        }
    }
}
