# Fix_The_Ship_Presentation

itch.io: https://amitay2022.itch.io/fix-the-ship-presentation

https://www.youtube.com/watch?v=62NHXKyTWyw&ab_channel=ItayHasidi

## The Game:

We have three level including a tutoral level.
In the game you play as the chief engineer onboard the ship, when pirates attack your ship and disable the engine.
The captain and the first officers have managed to lock themselvs in the bridge, but someone must go and fix the engine before more pirates arrive.
The captain has put this assignment on you! 
Good luck!

## Scripts:

### WeaponSettings.cs & GunPickUp.cs : 
are responsible for the pickup of the gun by the player and general settings about the gun.

### openQuestion.cs & DoorTrigger.cs : 
Are responsible for the apperance of the question on canvas and the logic behind opening the door on the correct answer and hiding the question assets.

### LookX.cs & LookY.cs & CharacterKeyboardMover.cs & CursorHider.cs:
Were taken from Arel without change except for CursorHider.cs where the hide and show logic were each moved to a seperate function.

### EnemyAiTutorial.cs & DestroyOnKill.cs :
Are responsible for the movment and destruction of the enemies.
EnemyAiTutorial.cs was taken from: https://www.youtube.com/watch?v=UjkSFoLxesw&ab_channel=Dave%2FGameDevelopment.

### EndTrigger.cs :
Triggers end message.
