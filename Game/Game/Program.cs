using Game.Core;

namespace Game;

class Program
{
    private static void Main()
    {
        using GameCycle gameCycle = new GameCycle();
        gameCycle.Run();
    }
}