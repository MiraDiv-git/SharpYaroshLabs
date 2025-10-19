using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Extensions;

namespace Game.Core;

public enum GameState
{
    Intro,
    MainMenu,
    Options,
    Play
}

public class GameCycle : IDisposable
{
    private string gameName = "Game Name";
    private Button playButton, optionsButton, exitButton;
    private Button fpsLockButton, windowSizeButton, backButton;
    
    private Texture2D logo;
    float logoTime = 0;
    
    GameState currentState = GameState.Intro;
    
    public GameCycle()
    {
        int width = 800;
        int height = 600;
        int FPS = 60;
        InitWindow(width, height, gameName);
        SetTargetFPS(FPS);
        
        // Textures
        logo = LoadTexture("Assets/Intro/logo.png");
        
        // Buttons
        playButton = new Button(Standard.GetScreenCenter('x') - 400 / 2, 
            Standard.GetScreenCenter('y') - 50 / 2, 
            400, 50, "PLAY");
        optionsButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 55,
            400, 50, "OPTIONS");
        exitButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 110,
            400, 50, "EXIT");

        fpsLockButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            Standard.GetScreenCenter('y') - 50 / 2,
            400, 50, $"TARGET FPS: {FPS}");
        windowSizeButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 55,
            400, 50, $"WINDOW SIZE: {width}x{height}");
        backButton = new Button(Standard.GetScreenCenter('x') - 400 / 2,
            (Standard.GetScreenCenter('y') - 50 / 2) + 110,
            400, 50, "APPLY AND BACK");
    }
    
    public void Run()
    {
        while (!WindowShouldClose())
        {
            switch (currentState)
            {
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;
                case GameState.Options:
                    UpdateOptions();
                    break;
                case GameState.Intro:
                    UpdateLogo();
                    break;
            }
            
            BeginDrawing();
                ClearBackground(Color.White);

                switch (currentState)
                {
                    case GameState.MainMenu:
                        DrawMainMenu();
                        break;
                    case GameState.Options:
                        DrawOptions();
                        break;
                    case GameState.Intro:
                        DrawLogo();
                        break;
                    default:
                        DrawIfNotValid();
                        break;
                }
                
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
            currentState = GameState.Play;
            Console.WriteLine($"State: {currentState}");
        }

        if (optionsButton.Update())
        {
            currentState = GameState.Options;
            Console.WriteLine($"State: {currentState}");
        }
        
        if (exitButton.Update())
        {
            Environment.Exit(0);
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

    private void DrawOptions()
    {
        Standard.DrawCenteredText("OPTIONS", 
            Standard.GetScreenCenter('x'), 
            Standard.GetScreenCenter('y') - 200, 
            70, Color.Black);
        DrawRectangle(Standard.GetScreenCenter('x') - 320 / 2, 130, 320, 5, Color.Black);
        fpsLockButton.Draw();
        windowSizeButton.Draw();
        backButton.Draw();
    }

    private void UpdateOptions()
    {
        if (fpsLockButton.Update())
        {
            Console.WriteLine("FPS Lock Button pressed");
        }
        
        if (windowSizeButton.Update())
        {
            Console.WriteLine("Window Size Button pressed");
        }
        
        if (backButton.Update())
        {
            currentState = GameState.MainMenu;
            Console.WriteLine($"State: {currentState}");
        }
    }

    private void UpdateLogo()
    {
        logoTime += GetFrameTime();
        
        if (logoTime >= 3.3f)
        {
            currentState = GameState.MainMenu;
            Console.WriteLine($"State: {currentState}");
        }
    }
    
    private void DrawLogo()
    {
        Color bg = new Color(32,32,32,255);
        ClearBackground(bg); 
        
        float scale = 1f; 
        
        int x = Standard.GetScreenCenter('x') - (int)(logo.Width * scale) / 2;
        int y = Standard.GetScreenCenter('y') - (int)(logo.Height * scale) / 2;
        
        float alpha = 0f;
    
        if (logoTime < 0.75f)
        {
            alpha = logoTime / 0.75f;
        }
        else if (logoTime < 2.25f)
        {
            alpha = 1f;
        }
        else if (logoTime < 3f)
        {
            alpha = 1f - (logoTime - 2.25f) / 0.75f;
        }
    
        Color tint = ColorFromNormalized(new Vector4(1f, 1f, 1f, alpha));

        DrawTextureEx(logo, new Vector2(x, y), 0f, scale, tint);
    }

    void DrawIfNotValid()
    {
        DrawText($"Not a valid state: {currentState}", 20, 20, 30, Color.Red);
        Button goback = new Button(20, 60, 200, 30, "Return to Menu");
        goback.Draw();
        if (goback.Update())
        {
            currentState = GameState.MainMenu;
        }
    }
}