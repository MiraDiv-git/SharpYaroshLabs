using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Game.Extensions;

public class Standard
{
    public static void DrawCenteredText(string text, int x, int y, int fontSize, Color color)
    {
        int textWidth = MeasureText(text, fontSize);
    
        DrawText(text, x - textWidth / 2, y - fontSize / 2, fontSize, color);
    }

    public static int GetScreenCenter(char axis)
    {
        return axis switch
        {
            'x' or 'X' => GetScreenWidth() / 2,
            'y' or 'Y' => GetScreenHeight() / 2,
            _ => throw new ArgumentException($"Invalid axis: {axis}. Use 'x' or 'y'")
        };
    }
}