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
The player will have been kidnapped by a stranger met at the bar who claims to have found her bruised, bloodied and unconcious, so he took her to his home to rest.
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

April 13, 2024:
-Added lightswitch
-Changed living room description
-Implemented a bool for if the furnace is fixed --> so that the room will still be described as cold (note: i'm thinking of deducting HP for each choice made prior to turning on the heat in furnace room)
-