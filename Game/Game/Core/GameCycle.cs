using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Extensions;

namespace Game.Core;

public class GameCycle : IDisposable
{
    public GameCycle()
    {
        int width = 800;
        int height = 600;
        InitWindow(width, height, "Game Name");
        SetTargetFPS(60);
    }
    
    public void Run()
    {
        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.White);
            Standard.DrawCenteredText("Game Name", Standard.GetScreenCenter('x'), Standard.GetScreenCenter('y') - 200, 70, Color.Black);
            EndDrawing();
        }
    }

    public void Dispose()
    {
        CloseWindow();
    }
}