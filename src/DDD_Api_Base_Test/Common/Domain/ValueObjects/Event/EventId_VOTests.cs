namespace DDD_Api_Base_Test
{
    using System;
    using Common.Domain.ValueObjects.Event;
    using Xunit;

    public class EventId_VOTests
    {
        private class TestEventId_VO : EventId_VO
        {
            public TestEventId_VO(string? id = null) : base(id)
            {
            }

            public bool PublicIsValid()
            {
                return base.IsValid();
            }
        }

        private readonly TestEventId_VO _testClass;
        private string _id;

        public EventId_VOTests()
        {
            _id = "TestValue1539373568";
            _testClass = new TestEventId_VO(_id);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TestEventId_VO(_id);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestEventId_VO(value));
        }

        [Fact]
        public void CanCallIsValid()
        {
            // Act
            var result = _testClass.PublicIsValid();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}