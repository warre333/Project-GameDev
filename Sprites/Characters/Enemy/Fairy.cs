﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Managers;
using Project.UI;
using System;

namespace Project.Sprites.Characters.Enemy
{
    public class Fairy : Enemy
    {
        public Fairy(Texture2D texture, Texture2D heartTexture) : base(texture, heartTexture)
        {
            Position = new Vector2(-48, 1);
            Speed = new Vector2(1, 1);
            Health = new Health(1, heartTexture);
        }

        internal override void Move()
        {
            Vector2 direction = Position - Game1.player.Position;

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            MovementManager.Move(this, animationState, direction);
        }
    }
}