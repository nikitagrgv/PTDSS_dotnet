using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


class PTDSS
{
    static RenderWindow window = new(new VideoMode(800, 600), "PTDSS");
    static GUI.MainGUI gui = new();
    static Clock clock = new();
    public static float delta { get; private set; }
    static View viewport = window.DefaultView;

    public static void Main()
    {
        window.Closed += (obj, ev) => { window.Close(); };
        window.KeyPressed += (sender, ev) =>
        {
            switch (ev.Code)
            {
                case Keyboard.Key.Escape:
                    window.Close();
                    break;
            }
        };

        Control.AddKeybinding(Keyboard.Key.A, () =>
        {
            viewport.Move(new(-100 * delta, 0));
        });
        Control.AddKeybinding(Keyboard.Key.W, () =>
        {
            viewport.Move(new(0, -100 * delta));
        });
        Control.AddKeybinding(Keyboard.Key.S, () =>
        {
            viewport.Move(new(0, 100 * delta));
        });
        Control.AddKeybinding(Keyboard.Key.D, () =>
        {
            viewport.Move(new(100 * delta, 0));
        });
        Control.AddKeybinding(Keyboard.Key.E, () =>
        {
            viewport.Zoom(1 - 0.3f * delta);
        });
        Control.AddKeybinding(Keyboard.Key.Q, () =>
        {
            viewport.Zoom(1 + 0.3f * delta);
        });



        // window.MouseMoved += (sender, ev) =>
        // {
            // window.MapCoordsToPixel()
        // }



        CircleShape shape = new(100);
        shape.FillColor = Color.Green;
        shape.Position = new Vector2f(0, 200);

        CircleShape shape2 = new(20);
        shape2.FillColor = Color.Red;
        shape2.Position = new Vector2f(15, 15);




        clock.Restart();
        while (window.IsOpen)
        {
            delta = clock.Restart().AsSeconds();
            window.DispatchEvents();




            gui.setFpsText((1 / delta).ToString());


            Control.ProcessKeys();


            shape.Position = nextPos(shape.Position, 100 * delta);

            // start draw
            window.Clear();

            window.SetView(viewport);
            window.Draw(shape);
            window.Draw(shape2);

            window.SetView(window.DefaultView);
            window.Draw(gui);

            window.Display();
            // end draw
        }


        Vector2f nextPos(Vector2f pos, float adding)
        {
            if (pos.X >= 200)
            {
                pos.X = 0;
            }
            else
            {
                pos.X += adding;
            }
            return pos;
        }

    }
}

