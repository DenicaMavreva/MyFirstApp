using CCA.Models;
using System;
using Xunit;

namespace CCA.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var course = new Courses
            {
                Title = "Art and Design",
                Description = "The first part offers a theme-based introduction to the specialist study of art and design",

            };
        }
    }
}
