# Platform-Demo

## About
This is a primitve platformer demo. It only supports walking, jumping on platforms, not sliding down the slope, and the main camera smoothly following the player.

### Gameplay mechanics
The character's movements are managed by the animator. In order to avoid sliding down the slope, I had to turn off the gravity when the character
is still on the ground and no space key has been pressed. The player moves by the right and left arrow keys. It jumps using the space key. The 
demo does not support double jumps. There will always be a platform above the player. The moment you land on one of these, a new platform 
is spawned above you. There will be at most 2 platforms at a time in the game. A platform is only destroyed under 2 conditions: 1) You 
successfully land on the platform above it. 2) The platform goes out of the frame of the camera that follows the player. The following are 
3 screenshots of the demo:

![First](https://github.com/CuriousGeekyDude/Platform-Demo/assets/130616138/0cc985bb-ad13-45b4-8033-5dc8394cd2da)

![Second](https://github.com/CuriousGeekyDude/Platform-Demo/assets/130616138/1cc2a6fd-9dcc-4343-94b3-de866dc46202)

![Third](https://github.com/CuriousGeekyDude/Platform-Demo/assets/130616138/783315e8-1f80-4744-a1ff-2d3f6ba1e659)
