using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

class GUI : Drawable
{
    static private readonly Font default_font = new("C:/Windows/Fonts/arial.ttf");
    static private Text fps_text = new("", default_font);



    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(fps_text, RenderStates.Default);
    }

    public void setFpsText(string str)
    {
        fps_text.DisplayedString = str;
    }
}