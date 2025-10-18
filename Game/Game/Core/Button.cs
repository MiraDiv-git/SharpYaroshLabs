using Raylib_cs;
using System.Numerics;

namespace Game.Core;

using Raylib_cs;
using System.Numerics;

public class Button
{
    public Rectangle Bounds;
    public string Text;
    public Color NormalColor = Color.Gray;
    public Color HoverColor = Color.LightGray;
    public Color PressedColor = Color.DarkGray;
    public Color TextColor = Color.Black;

    public bool _hovered;
    private bool _pressed;

    public Button(int x, int y, int width, int height, string text)
    {
        Bounds = new Rectangle(x, y, width, height);
        Text = text;
    }

    public bool Update()
    {
        Vector2 mouse = Raylib.GetMousePosition();
        _hovered = Raylib.CheckCollisionPointRec(mouse, Bounds);
        
        bool wasPressed = _pressed;
        _pressed = _hovered && Raylib.IsMouseButtonPressed(MouseButton.Left);
        
        return _pressed && !wasPressed;
    }

    public virtual void Draw()
    {
        Color color = NormalColor;
        
        if (_hovered)
        {
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
                color = PressedColor;
            else
                color = HoverColor;
        }

        Raylib.DrawRectangleRec(Bounds, color);
        Raylib.DrawRectangleLines((int)Bounds.X, (int)Bounds.Y, (int)Bounds.Width, (int)Bounds.Height, Color.Black);

        int fontSize = 20;
        int textWidth = Raylib.MeasureText(Text, fontSize);
        Raylib.DrawText(Text,
            (int)(Bounds.X + Bounds.Width / 2 - textWidth / 2),
            (int)(Bounds.Y + Bounds.Height / 2 - fontSize / 2),
            fontSize,
            TextColor);
    }
}

public class TexturedButton : Button
{
    public Texture2D Texture;

    public TexturedButton(int x, int y, int width, int height, Texture2D texture) 
        : base(x, y, width, height, text: "")
    {
        Texture = texture;
        NormalColor = Color.Blank;
        HoverColor = new Color(255, 255, 255, 100);
        PressedColor = new Color(200, 200, 200, 150);
    }

    public override void Draw()
    {
        Color color = NormalColor;
        
        if (_hovered)
        {
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
                color = PressedColor;
            else
                color = HoverColor;
        }
        
        Raylib.DrawTexture(Texture, (int)Bounds.X, (int)Bounds.Y, Color.White);
        
        if (color.A > 0)
        {
            Raylib.DrawRectangleRec(Bounds, color);
        }
        
        Raylib.DrawRectangleLines((int)Bounds.X, (int)Bounds.Y, (int)Bounds.Width, (int)Bounds.Height, Color.Black);
    }
}