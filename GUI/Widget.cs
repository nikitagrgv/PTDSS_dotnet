using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GUI
{
    abstract class Widget : Drawable
    {
        public bool isVisible { get; protected set; } = true;
        public bool isMovable { get; protected set; } = false;

        abstract public void Draw(RenderTarget target, RenderStates states);

    }

    class TextWidget : Widget
    {
        public static readonly Font default_font = new("C:/Windows/Fonts/arial.ttf");

        private Text text;

        public TextWidget(string text, Font font)
        {
            this.text = new Text(text, font);
        }

        public TextWidget(string text)
        {
            this.text = new Text(text, default_font);
        }

        public TextWidget()
        {
            this.text = new Text("", default_font);
        }

        public void setText(string text)
        {
            this.text.DisplayedString = text;
        }

        public string getText()
        {
            return this.text.DisplayedString;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(text, states);
        }
    }
}