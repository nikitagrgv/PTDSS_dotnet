using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

static class Control
{
    private static Dictionary<Keyboard.Key, Action> keybindings = new();

    public static void AddKeybinding(Keyboard.Key key, Action action)
    {
        if (keybindings.ContainsKey(key))
        {
            keybindings[key] += action;
        }
        else
        {
            keybindings.Add(key, action);
        }

    }

    public static void ProcessKeys()
    {
        foreach (var bind in keybindings)
        {
            if (Keyboard.IsKeyPressed(bind.Key))
            {
                bind.Value.Invoke();
            }
        }
    }
}
