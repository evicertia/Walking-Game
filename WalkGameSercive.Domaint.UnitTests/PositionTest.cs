using FluentAssertions;
using System.Reflection.Metadata;
using WalkGameService.Domain;

namespace WalkGameSercive.Domaint.UnitTests
{
    public class PositionTest
    {
        [Fact]
        public void GetPaths()
        {
            Position position= new Position(1,1);

            List<Position> paths = position.GetPaths();
            paths.Count.Should().Be(4);
            paths.Any(x => x.Row == 0 && x.Column == 1).Should().BeTrue();
            paths.Any(x => x.Row == 1 && x.Column == 0).Should().BeTrue();
            paths.Any(x => x.Row == 1 && x.Column == 2).Should().BeTrue();
            paths.Any(x => x.Row == 2 && x.Column == 1).Should().BeTrue();

        }

        [Fact]
        public void CanMoveTo()
        {
            Position position= new Position(1,1);
            position.CanMoveTo(new Position(1, 0)).Should().BeTrue();
        }

        [Fact]
        public void CantMoveTo()
        {
            Position position= new Position(1,1);
            position.CanMoveTo(new Position(2, 2)).Should().BeFalse();
        }


    }
}