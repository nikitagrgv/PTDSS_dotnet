using SFML;
using SFML.Window;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;


class Program
{
    static void Main()
    {
        RenderWindow window = new(new VideoMode(800, 600), "PTDSS");
        CircleShape shape = new(100);

        window.Closed += (obj, ev) => { window.Close(); };

        shape.FillColor = Color.Green;
        while (window.IsOpen)
        {

            window.DispatchEvents();
            window.Draw(shape);
            window.Display();

        }
    }
}

