using Project.Characters;
using Project.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project.Managers
{
    public static class ScreenManager
    {
        public static int ScreenWidth;
        public static int ScreenHeight;

        public static void Setup(GraphicsDeviceManager graphics, GameWindow window)
        {
            ScreenWidth = window.ClientBounds.Left + window.ClientBounds.Right;
            ScreenHeight = window.ClientBounds.Top + window.ClientBounds.Bottom;
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.HardwareModeSwitch = true;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }
    }
}
