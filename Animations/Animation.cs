using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Microsoft.Xna.Framework;

namespace Project.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double tickCounter;
        private int fps;


        public Animation(int fps)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
            counter = 0;
            tickCounter = 0;
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            tickCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if(tickCounter >= 1d / fps)
            {
                counter++;
                tickCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTexture(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites, int startAnimation, int endAnimation)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int i = startAnimation; i <= endAnimation; i++)
            {
                int x = i % numberOfWidthSprites;
                int y = i / numberOfWidthSprites;

                frames.Add(new AnimationFrame(
                    new Rectangle(x * widthOfFrame, y * heightOfFrame, widthOfFrame, heightOfFrame)
                ));
            }

            CurrentFrame = frames[0];
        }
    }
}
