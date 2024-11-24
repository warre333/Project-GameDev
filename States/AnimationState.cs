using Project.Animations;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project.Enums;

namespace Project.States
{
    public class AnimationState
    {
        private Animation currentAnimation;
        private Dictionary<CharacterAnimation, Animation> animations;
        public bool IsInProgress { get; set; }

        public AnimationState()
        {
            animations = new Dictionary<CharacterAnimation, Animation>();
        }

        public void AddAnimation(CharacterAnimation characterAnimation, int width, int height, int numberOfWidthSprites, int numberOfHeightSprites, int startAnimation, int endAnimation, int fps)
        {
            Animation animation = new Animation(fps);
            animation.GetFramesFromTexture(width, height, numberOfWidthSprites, numberOfHeightSprites, startAnimation, endAnimation);

            animations.Add(characterAnimation, animation);
        }

        public void PlayAnimation(CharacterAnimation animation)
        {
            IsInProgress = true;
            currentAnimation = animations.GetValueOrDefault(animation);
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

        public void ChooseAnimation(Vector2 direction)
        {
            if (direction.X > 0)
                PlayAnimation(CharacterAnimation.WALK_RIGHT);
            else if (direction.X < 0)
                PlayAnimation(CharacterAnimation.WALK_LEFT);
            else if (direction.Y > 0)
                PlayAnimation(CharacterAnimation.WALK_DOWN);
            else if (direction.Y < 0)
                PlayAnimation(CharacterAnimation.WALK_UP);
            else
                PlayAnimation(CharacterAnimation.IDLE);
        }

        public void ChooseAnimation(Vector2 direction, out CharacterAnimation animation)
        {
            if (direction.X > 0)
            {
                PlayAnimation(CharacterAnimation.WALK_RIGHT);
                animation = CharacterAnimation.WALK_RIGHT;

            }
            else if (direction.X < 0)
            {
                PlayAnimation(CharacterAnimation.WALK_LEFT);
                animation = CharacterAnimation.WALK_LEFT;
            }
            else if (direction.Y > 0)
            {
                PlayAnimation(CharacterAnimation.WALK_DOWN);
                animation = CharacterAnimation.WALK_DOWN;
            }
            else if (direction.Y < 0)
            {
                PlayAnimation(CharacterAnimation.WALK_UP);
                animation = CharacterAnimation.WALK_UP;
            }
            else
            {
                PlayAnimation(CharacterAnimation.IDLE);
                animation = CharacterAnimation.IDLE;
            }
        }

        public AnimationFrame GetCurrentFrame()
        {
            return currentAnimation.CurrentFrame;
        }
    }
}
