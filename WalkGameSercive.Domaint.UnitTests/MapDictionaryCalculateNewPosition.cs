using WalkGameService.Domain;

namespace WalkGameSercive.Domaint.UnitTests
{
    public class MapDictionaryCalculateNewPosition
    {
        [Fact]
        public void MapEmpty()
        {
            //.            MapDictionary map = new();
            //Position position = map.GetNewPosition();
            //position.Should().NotBeNull();

            MapDictionary map = new MapDictionary(0, 0, 2, 2);
            List<Position> emptyPositions = map.GetEmptyPositions();
        }


    }
}