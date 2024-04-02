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