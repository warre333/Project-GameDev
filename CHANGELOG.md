# Changelog
## 0.0.1
Code die ik maakte voor het project voordat ik van idee wisselde herbruik ik hier gedeeltelijks terug.

Create: Created project
Added: Added a README.md
Added: Added a CHANGELOG.md
Added: Animation classes (Animation, AnimationFrame, AnimationState, CharacterAnimation) to handle animations
    - Animation: contains a list of animation frames and handles the speed of the animation. Frames can be extracted from a spritesheet with the help of the GetFramesFromTexture method.
    - AnimationFrame: contains the source of the rectangle. This is used to draw the correct frame of the animation.
    - AnimationState: contains a dictionary of animations. This is used to switch between animations. AddAnimation adds a new list of animation frames. PlayAnimation plays a specific animation by the CharacterAnimation enum.
Added: Added a Character class to handle sprites.
    - Contains: an animationstate, texture, position and speed.
Added: Added Player class to handle specific player logic
    - Inherits from Character
    - Is a moveable object with the help of movementmanager and inputreaders
Added: ScreenManager to setup the window and provide static screen information.
Added: Camera class to handle the camera logic
    - Centers the view around a given Character, even whilst moving.