# NarrativeProject
## by James Van Aelst for course 420-JV4-AS

April 02, 2024:
-Added "furnace room" class and actual Room type implemented (still need to modify it's functionality)
-Added new functions to for adding new inventory and checking the player's inventory
-Created bool variables to verify whether certain inventory items have been found and stored, or not.
-Ex. When the user goes through the "door" to the "living room" downstairs, it'll trigger the bool to have 'goneDownstairs' = true (once this 
is set as true, the user can now find the inventoriable item --> the flashlight, and can pick it up to use downstairs, where the lights are off).
-*NOTE* i've currently removed the FinishGame() function, so there is not set END yet, must remember to add it back in wherever I want my game to end.
-NOTE: need to find a way to properly implement the 'AddInventory' function when trying to interact with items like the 'FlashLight'(*See Bedroom file*)

April 06, 2024:
-I've figured out the theme and type of game I want, and am beginning to alter the narrative text accordingly.
Story Narrative Blueprint:
{
The game will be a mystery kidnapping case, with the goal and style of play being similar to an escape room... the player must make it out alive.
The player will have been kidnapped by a stranger met at the bar who claims to have found him/her bruised, bloodied and unconcious, so he took him/her to his home to rest.
The player will wake up in the bedroom to start the game, with a note from the kidnapper explaining the context of the story.
The player's narrated dialogue would say something like "This does not feel right, but I guess... surely... if this supposed Good Samaritan wanted to harm me, he coud've done so in my sleep?'
The game then actually begins, with the console text suggesting the player checks the note on the nightstand. Saying the mystery man went out to get some advils and ice and the convenient store, and if the player wanted to take a bath to freshen up they're welcome to.
The dialogue then says "Maybe I'll just hang around and wait to see who this mystery hero of mine is."
}
Narrative/Text Changes done so far:
{
Since the game happens in someone else's house, I changed all possessive adjectives to be neutral (ex. Instead of "you enter youre bedroom", it now says "you enter the bedroom").
}

-I changed the bedroom currentDescription function to include and 'if-statement' to return a hint in the output text, if they've gone downstairs, to check around for items that may be useful.
-I've decided I'd store all the items in various room and objects, but have most of them only reveal themselves as an option only once you've explored a certain room and return back to the room said object is in. 

April 13, 2024 (Round 4):
-Added lightswitch
-Changed living room description
-Implemented a bool for if the furnace is fixed --> so that the room will still be described as cold (note: i'm thinking of deducting HP for each choice made prior to turning on the heat in furnace room)
-Added more variety in the narrative output depending on various circumstances (different console prompts when returning to a specific room before/after interacting with another object)
-Added a new Room class --> ElectricalRoom 

April 14, 2024 (Round 5):
-Changed flow of the game (how you transition between rooms and displaying different texts depending on the player's choice')
-Front door was added essentially only as another hint of the game's objective... to get out of the house before you're too hurt or time runs out.
-Expanded on my implementation of the ElectricalRoom
-Added various scenarios where a player can potentially lose HP --> just need to implement an actual HP system.
-Edited the LivingRoom scenarios, and expanding on the players' options (the living room will be the central area/environment of the game.. with most events occuring there)
-Things to add later --> HP system, a challenge or hint the player must solve/find in order to turn on the power in electrical room
		--> Need to add the photos for the player to also get a visual while playing to become more immmersed.

April 16, 2024 (Round 6):
-Tons of changes this time around --> mainly involving ElectricalRoom, FurnaceRoom, and LivingRoom.
-Reconfigured the transition and gameflow for these rooms and added new game features inside these rooms.
- Re-worded a bunch of the narrative texts
- Implemented another way to lose health over time --> the alarm (HP will be lost based on time elapsed before turning it off, losing roughly [3 x ElapsedTime] worth of health)
		--> Note: thinking of adding a maximum limit on the alarm --> if the player keeps the alarm on for too long so that they can explore with the power on, then they'll lose the game.

April 20, 2024 (Round 7):
-Still need to finalize all the rooms, add GarageRoom and the garageDoor.
-Need to change my game items once things are finalized
-I previously had it so that the key's behavior is determined by a boolean "isKeyCollected" --> added the code for the key to actually go into inventory as a game item.
-Need to add "inventory" option to each room's switch case --> to be able to check your inventory at any time.

April 21, 2024 (Round 8):
-Added key to inventory system
-Added a checkpoint for once you've managed to turn on the power and fix the furnace, without keeping the alarm on.
-In electricalRoom --> you can turn on the power, leave the room, and go fix the furnace, while the alarm is still going... 
					--> so you'll begin losing time/health quickly from leaving the alarm on, but you'll also stop losing time/health from the cold.
	--> if the user wants to reach the main checkpoint of the game (when it switches from exploration to escape mode), he'll need to figure out the switch that turns off the alarm.
-Began attempts to implement the timer/hp system... still need to figure how it will fit into the game.