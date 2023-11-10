namespace WalkGameService.Domain
{
    public interface IMapService
    {
        Position AddPlayer(Player player);
        bool DeletePlayer(string username);
        Player? GetPlayer(string username);
        IEnumerable<Player> GetPlayers();
        Position? MovPlayer(Player player);
        void NewGame(int width, int height);

    }
}