namespace WalkGameService.Domain
{
    public interface IMap
    {
        Position AddPlayer(Player player);
        bool DeletePlayer(string username);
        Player? GetPlayer(string username);
        IEnumerable<Player> GetPlayers();
        Position? MovPlayer(Player player);
    }
}