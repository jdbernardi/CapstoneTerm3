# Joe Bernardi - Capstone Project - Mobile Performance & 360 Media Specialization

## Versions
- Unity 2017.3.0
- GVR Unity SDK v1.70.0

## Target Build Device = Samsung Galaxys8
## Target VR Platform = Cardboard

## APK Build - build zip file located in root folder ##
## Project planning sheet located in root fodler ##

## Achievements and Walkthrough Video URLs ##
	1. Full walkthrough : https://www.youtube.com/watch?v=6Ye2uP_U08w&feature=youtu.be
	2. Achievement Walkthrough : https://www.youtube.com/watch?v=XSJmZNrKguQ&feature=youtu.be

## Unity Editor ##
	- 'Start' Scene located in Assets>Scenes>Start
		- Three Scenes in project
			- Start - Game - End

## ACHIEVEMENTS ## TOTAL SCORE 1750

	## Fundamentals ##

	1. Scale Achievement 		 : 100
	2. Animation Achievement : 100
	3. Lighting Achievement  : 100
	4. Locomotion Achievement: 100
	5. Physics Achievement   : 100

							Total Score  : 500

	## Completeness ##

	1. Gamification 				 : 250
	2. Alternative Storyline : 250
	3. 3d Modeling           : 250

							Total Score  : 750

	## Challenges ##

	1. Compute Shader        : 500

							Total Score  : 500

## Navigation && Gameplay ##
* START SCENE *
- At start you will have waypoint orbs in front to begin navigation
	- gaze and click on each orb to move with a corresponding tutorial panel that pops up
	-	you must navigate to either of the large faces displaying the corresponding emotion
		- in front of each face is an orb with the emotion to click and start the game
			- each emotion will determine your starting emotional health
* GAME SCENE *
- game scene is a blue orb you can move up/down with your gaze
- behind the player is a planel displaying the score and emotional health
	- the goal of the game is to stay happy by only collecting happy (yellow) emotions
		- collecting angry (red) emotions will speed up play
			- each collect increases emotional health meter
		- collecting sad (blue) emotions will slow down play
			- each collect decreases emotional health meter
		- collect too many red or blue and you will lose
	- there is a 'power up' item shown under the emotional health meter
		- power ups can be replensished by collected happy emotions
		- pressing trigger will send a smile toward the objects causing them to fall
	- as game progresses, more emotions are spawned making it harder to dodge negative ones
* END SCENE *
- upon losing the game, you are presented with your score and the option to reload the game	with your original emotion selected	or you can return to the start scene to select a new starting emotion

## Credits ##
Random Number Generator Class
https://stackoverflow.com/questions/3655430/selection-based-on-percentage-weighting


Animation for bobbing effect on start scene emotions
https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity


Using Lerp for background color changing
https://answers.unity.com/questions/175004/gui-colour-based-on-health.html

Compute Shader
https://stackoverflow.com/questions/4200224/random-noise-functions-for-glsl
Unity docs

Garage Band
used to make Sound effects and Ambient Music

Modeling
Blender used for Structures and power up smiley

