using Project.Interfaces;
using Project.States;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Project.Enums;
using Project.Tiles;
using Project.Characters;

namespace Project.Managers
{
    public static class MovementManager
    {
        public static void Move(IMovable movable, AnimationState animationState, Vector2 direction)
        {
            MoveSprite(movable, direction);
            animationState.ChooseAnimation(direction);
        }

        public static void Move(IMovable movable, AnimationState animationState, Vector2 direction, out CharacterAnimation animation)
        {
            MoveSprite(movable, direction);
            animationState.ChooseAnimation(direction, out animation);
        }

        private static void MoveSprite(IMovable movable, Vector2 direction)
        {
            if (movable is Player)
            {
                MovePlayer((Player)movable, direction);
                return;
            }

            Vector2 distance = direction * movable.Speed;
            Vector2 newPosition = movable.Position + distance;

            foreach (Tile collidable in Game1.mapManager.GetCurrentMap().Tiles)
            {
                if (collidable.GetBoundingBox().Intersects(GetBoundingBox(movable, newPosition)))
                {
                    return;
                }
            }

            movable.Position += distance;
        }

        private static void MovePlayer(Player player, Vector2 direction)
        {
            const float acceleration = 0.2f;
            const float deceleration = 0.15f;

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
                player.Velocity += direction * acceleration;

                if (player.Velocity.Length() > player.Speed.Length())
                {
                    player.Velocity = Vector2.Normalize(player.Velocity) * player.Speed.Length();
                }
            }
            else
            {
                if (player.Velocity.Length() > deceleration)
                {
                    player.Velocity -= Vector2.Normalize(player.Velocity) * deceleration;
                }
                else
                {
                    player.Velocity = Vector2.Zero;
                }
            }

            Vector2 newPosition = player.Position + player.Velocity;

            foreach (Tile collidable in Game1.mapManager.GetCurrentMap().Tiles)
            {
                if (collidable.GetBoundingBox().Intersects(GetBoundingBox(player, newPosition)))
                {
                    return;
                }
            }

            player.Position += player.Velocity;
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
