using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.UI;

namespace Project.Sprites.Characters.Enemy
{
    public class Wizard : Enemy
    {
        public Wizard(Texture2D texture, Texture2D heartTexture) : base(texture, heartTexture)
        {
            Position = new Vector2(1, 1);
            Speed = new Vector2(1, 1);
            Health = new Health(2, heartTexture);
        }
    }
}
