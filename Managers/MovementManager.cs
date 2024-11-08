using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;

namespace Project.Characters
{
    public static class MovementManager
    {
        public static void Move(IMovable movable, AnimationState animationState)
        {
            Vector2 direction = movable.InputReader.ReadInput();
            Vector2 distance = direction * movable.Speed;
            movable.Position += distance;

            animationState.ChooseAnimation(direction);
        }
    }
}
