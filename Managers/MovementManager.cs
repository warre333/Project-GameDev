using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Managers
{
    public static class MovementManager
    {
        public static void Move(IMovable movable, AnimationState animationState, Vector2 direction)
        {
            Vector2 distance = direction * movable.Speed;
            Vector2 newPosition = movable.Position + distance;

            foreach (var collidable in Game1.mapManager.GetCurrentMap().Tiles)
            {
                if (collidable.GetBoundingBox().Intersects(GetBoundingBox(movable, newPosition)))
                {
                    return;
                }
            }

            movable.Position += distance;

            animationState.ChooseAnimation(direction);
        }

        private static Rectangle GetBoundingBox(IMovable movable, Vector2 position)
        {
            return new Rectangle(
                (int)(position.X + movable.Size.X / 4),
                (int)(position.Y + movable.Size.Y / 2),
                (int)movable.Size.X,
                (int)movable.Size.Y
            );
        }
    }
}
