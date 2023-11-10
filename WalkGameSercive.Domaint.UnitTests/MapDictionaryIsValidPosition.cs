using FluentAssertions;
using WalkGameService.Domain;

namespace WalkGameSercive.Domaint.UnitTests
{
    public class MapDictionaryIsValidPosition
    {
        [Fact]
        public void PositionNull()
        {
            MapDictionary map = new();
            bool result = map.IsValidPosition(null);
            result.Should().BeFalse();

        }

        [Fact]
        public void OutByUp()
        {
            MapDictionary map = new();
            Position position = new(7,0);
            bool result = map.IsValidPosition(position);
            result.Should().BeFalse();
        }

        [Fact]
        public void OutByDown()
        {
            MapDictionary map = new();
            Position position = new(-7,0);
            bool result = map.IsValidPosition(position);
            result.Should().BeFalse();
        }

        [Fact]
        public void OutByLeft()
        {
            MapDictionary map = new();
            Position position = new(0,-7);
            bool result = map.IsValidPosition(position);
            result.Should().BeFalse();
        }

        [Fact]
        public void OutByRight()
        {
            MapDictionary map = new();
            Position position = new(0,7);
            bool result = map.IsValidPosition(position);
            result.Should().BeFalse();
        }

        [Fact]
        public void InMap()
        {
            MapDictionary map = new();
            Position position = new(0,0);
            bool result = map.IsValidPosition(position);
            result.Should().BeTrue();
        }

        [Fact]
        public void OutByOcuppation()
        {
            MapDictionary map = new();
            Player player = new("test");
            Position position = map.AddPlayer(player);
            bool result = map.IsValidPosition(position);
            result.Should().BeFalse();
        }

    }
}