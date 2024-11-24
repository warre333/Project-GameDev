using Microsoft.Xna.Framework.Input;

namespace Project.Inputs
{
    public static class MouseReader
    {
        public static bool IsLeftMouseClicked()
        {
            MouseState mouse = Mouse.GetState();
            ButtonState mouseClick = mouse.LeftButton;

            return mouseClick == ButtonState.Pressed;
        }
    }
}
