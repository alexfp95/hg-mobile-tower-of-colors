Towers of Colors - Alexis Fuentes

#1# Implement two optimizations on the project.

1) One Unity UI assets optimization.
- An atlas (MainAtlas) has been created with the UI icons, and has been included in the build. This reduces UI DrawCalls quite a bit.

2) Add a pooling system for the barrels.
- A GameObject "PoolSystem" has been added to the scene, which generates a singleton and is marked as DontDestroyOnLoad. It has been done this way because the gameplay is based on reloading the scene with each level.
- This pool system is capable of managing both normal and special tiles (barrels).
- Pool size increases on demand. It will always try to give you an available resource, and if it doesn't have any left, it creates it and adds it to the system.

3) Extras
- "Enable GPU Instancing" has been activated for materials: Cylinder, Exploding, Water. Performance in DrawCalls has improved greatly, since all 3D is painted in just a few calls. Before we had between 120-180 calls (depending on the level), and it has dropped to 4-6 calls in total
- Image Raycast Target has been unchecked from UIs that did not require this functionality. 


#2# Add missions

An extensible and easy-to-configure Missions and Rewards system has been created.
- The system has been set up based on a ScriptableObjects architecture.
- A mission is an scriptable object and its made up of a title, a difficulty (Easy/Medium/Hard), a set of submissions or steps (you must get them all to complete the main mission), and a set of rewards. Rewards are claimed when all steps are completed.
- Each mission and submission has a unique non-editable ID. This ID is established upon creation of the Scriptable, so objects should be created using its creation menu, AND NEVER duplicating existing assets. Assets > Create > Missions > Mission / Steps / Reward.
- A submission is an abstract scriptable object, which has the virtual methods: Evaluate, IsCompleted, SetCompleted, GetDescription, and GetID.
- Different submissions have been extended as an example:
	- MissionStepCombo: Get a combo number equal to or greater.
	- MissionStepLevel: Reach a certain level of the game.
	- MissionStepExplosionCount: Win a level by achieving the exact number of explosions requested.
- A reward is an abstract scriptable object, which presents the virtual methods: ClaimReward, GetDescription.
- The following reward has been extended as an example:
	- RewardStar: Adds a number of stars to your inventory.
- Specific editors have been made for scriptable objects.
- The ScriptableObjects architecture has been used because it allows a fairly easy creation of missions and steps, their rewards,... as well as easy editing of them, since each element is an asset.
- Active game missions are set in the GameObject "MissionManager" found in the scene. They are presented in the order they are listed, and the player must complete them in order. You only have one current mission at a time.
- The evaluation of the missions occurs based on events after: Performing a game action, or opening the missions menu (this last subscription has been made for steps that do not require an action as such, but use external elements such as level, or open a certain menu or something).
- 3 example missions (easy, medium, and hard) have been created and configured. Folder: "5_Missions"
- A mission panel has been created in UI keeping UX in mind. It is adaptable to different types of screens and responds well to use. You can have all the missions you want, since the panel has a DropdowView that grows everything necessary in a clean way.
- The missions are crossed out as we achieve them, and you will see the current mission in white.
- All colors are configurable in their respective panels/prefabs.
- The whole system is very easy to extend, since you can create all the steps you want, and you can limit their evaluation since the GameManager is passed to it, and the GameState has been exposed, so you can configure that a Step is only evaluate in "Win", or outside of gameplay. It is also very easy to extend the rewards since you only have to overwrite the virtual method with the logic you want.
- The system is easy to migrate to any other game, since the only reference to the current game is the pass of the GameManager as a parameter in the virtual method Evaluate(). In any other game, you can skip it or use the appropriate manager.
- RemoteConfig.BOOL_MISSIONS_ENABLED has been included for use as a mockup.
- The game has been tested on an Android mobile and works correctly.

Extras:
- The PlayerPrefs saving system that came with this game has been supported. Both missions and steps are saved using their ID and a bool indicating their completeness. So you can exit the game and continue with the missions at any time, as progress is not lost. The stars (rewards) earned are also saved as an inventory.

[Android APK](https://drive.google.com/file/d/10oRoNA23MAwRB9zfsM4MM_Yeu9Z6rpLc/view?usp=sharing)