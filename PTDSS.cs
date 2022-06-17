using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


class PTDSS
{
    static RenderWindow window = new(new VideoMode(800, 600), "PTDSS");
    static GUI gui = new();
    static Clock clock = new();

    public static double getFps()
    {
        return 1e6 / (double)clock.Restart().AsMicroseconds();
    }

    public static void Main()
    {
        window.Closed += (obj, ev) => { window.Close(); };
        window.KeyPressed += (sender, ev) =>
        {
            if (ev.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        };

        clock.Restart();
        while (window.IsOpen)
        {
            gui.setFpsText(getFps().ToString());
            window.DispatchEvents();
            window.Clear();
            window.Draw(gui);
            window.Display();
        }
    }
}

