using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GUI
{
    class MainGUI : Drawable
    {
        private static TextWidget fps = new();

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(fps, states);
        }

        public void setFpsText(string str)
        {
            fps.setText(str);
        }
    }
}