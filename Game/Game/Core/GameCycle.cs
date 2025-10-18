using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Extensions;

namespace Game.Core;

public class GameCycle : IDisposable
{
    string gameName = "Game Name";
    Button playButton, optionsButton, exitButton;
    
    public GameCycle()
    {
        int width = 800;
        int height = 600;
        InitWindow(width, height, gameName);
        SetTargetFPS(60);
        
        playButton = new Button(Standard.GetScreenCenter('x') - 400 / 2, 
            Standard.GetScreenCenter('y') - 50 / 2, 
            400, 50, "PLAY");
        optionsButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 55,
            400, 50, "OPTIONS");
        exitButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 110,
            400, 50, "EXIT");
    }
    
    public void Run()
    {
        while (!WindowShouldClose())
        {
            UpdateMainMenu();
            
            BeginDrawing();
                ClearBackground(Color.White);
                DrawMainMenu();
            EndDrawing();
        }
    }

    public void Dispose()
    {
        CloseWindow();
    }

    private void UpdateMainMenu()
    {
        if (playButton.Update())
        {
            Console.WriteLine("Play Button pressed");
        }

        if (optionsButton.Update())
        {
            Console.WriteLine("Options Button pressed");
        }
        
        if (exitButton.Update())
        {
            Console.WriteLine("Exit Button pressed");
        }
    }

    private void DrawMainMenu()
    {
        Standard.DrawCenteredText(gameName, 
            Standard.GetScreenCenter('x'), 
            Standard.GetScreenCenter('y') - 200, 
            70, Color.Black);
        playButton.Draw();
        optionsButton.Draw();
        exitButton.Draw();
    }
}