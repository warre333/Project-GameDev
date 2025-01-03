# Changelog
## 0.001
Code die ik maakte voor het project voordat ik van idee wisselde herbruik ik hier gedeeltelijks terug.

- Create: Created project.
-Added: Added a README.md.
-Added: Added a CHANGELOG.md.
- Added: Animation classes (Animation, AnimationFrame, AnimationState, CharacterAnimation) to handle animations.
    - Animation: contains a list of animation frames and handles the speed of the animation. Frames can be extracted from a spritesheet with the help of the GetFramesFromTexture method.
    - AnimationFrame: contains the source of the rectangle. This is used to draw the correct frame of the animation.
    - AnimationState: contains a dictionary of animations. This is used to switch between animations. AddAnimation adds a new list of animation frames. PlayAnimation plays a specific animation by the CharacterAnimation enum.
- Added: Added a Character class to handle sprites.
    - Contains: an animationstate, texture, position and speed.
- Added: Added Player class to handle specific player logic
    - Inherits from Character
    - Is a moveable object with the help of movementmanager and inputreaders
- Added: ScreenManager to setup the window and provide static screen information.
- Added: Camera class to handle the camera logic
    - Centers the view around a given Character, even whilst moving.

## 0.002
- Added: Tiles 
- Added: Simple map loaded from a text file.

## 0.003
- Added: Collision detection between player and tiles.

## 0.004
- Added: Health system for the player.

## 0.005
- Added: Basic enemy class.

## 0.006
- Added: Wizard
- Added: Knight
- Added: Fairy
- Added: Enemy AI: Walking

## 0.007
- Added: Weapon class

## 0.008
- Added: display of health from enemies.

## 0.009
- Added: Player attack
- Added: Deal damage to enemies

## 0.010
- Added: Knight attack
- Changed: Weapon class to handle different types of weapons.
- Added: Sword class for knight and player.
- Summary: The player can now attack and deal damage to enemies. The knight can attack and deal damage to the player.

## 0.011
- Added: Wizard attack
    - Wizard shoots fireballs at the player.
- Fix: character boundingbox

## 0.012
- Fix: No more invisible tile in the middle.
- Added: Acceleration and deceleration for the player.

## 0.013
- Fix: started using scenes.
- Added: Scene class to handle different scenes.
- Added: StartScene
- Added: GameScene
- Added: SceneManager to handle the current scene.

## 0.014
- Fix: scaling of the sprites.

## 0.015
- Added: Start screen buttons

## 0.016
- Added: Game over screen

## 0.017
- Added: game over scene when dead

## 0.018
- Added: enemymanager
    - Spawn more enemies easier
    - Difficulty option

## 0.019
- Added: Victory screen