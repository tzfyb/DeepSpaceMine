	using UnityEngine;
using System.Collections;
using AssemblyCSharp;
	
// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class UI : MonoBehaviour
{
		string levelName;
		PlayerSaveLoadMethods playerSaveLoadMethods;
		bool isDrawingTier1;
		bool isDrawingTier2;
		bool isDrawingTier3;
		bool isDrawingTier4;
		
		bool isDisplayingInventory;
		/**This list holds a list of upgrade obnjects*/
		public ArrayList listOfBaseUpgradeObjects;
		public int listSize;
		/**This enables*/
		PlayerCenter playerController;
		/**This variable will control the Ui displaying so that it does not dissapear after the user releases the "escape" key*/
		bool isInGameUIEnabled = false;
		/**This variable will control when a menu box is being drawn*/
		//bool isDrawingGUIBox = false;
		/**this variable will be true if the player in at the home base*/
		//bool isLevelHomeBase = false;
		/**this is the title for the currrent box being drawn*/
		string boxTitle = "";
		/**This is the screen width*/
		int screenWidth = Screen.width;
		/**This is the screen height*/
		int screenHeight = Screen.height;
		/**This is the default button width*/
		static int defaultButtonWidth = 160;
		/**This is the default button width*/
		static int defaultButtonHeight = 40;
		/**This is the default side window width*/
		int defaultSideWindowWidth = Screen.width / 4;
		/**This is the default side window height*/
		int defaultSideWindowHeight = Screen.height;
		/**This is the styling for the game title on the main screen*/
		GUIStyle boxGUIStyle;
		/**This is the player gameobject*/
		GameObject player;
		/**This is the playertest gameobject*/
		GameObject playerTest;
		/**This is a helpful buffer size*/
		//static int bufferSize = 30;
		/**These are the textures for the resource menu*/
		Texture2D asteroidIcon;
		Texture2D ironIcon;
		Texture2D copperIcon;
		Texture2D alumIcon;
		Texture2D diamondIcon;
		Texture2D uranIcon;
		Texture2D hydrogenIcon;
		Texture2D platIcon;
		Texture2D leadIcon;
		Texture2D goldIcon;
		Texture2D unobtainIcon;
		/**This is the texture for the player health bar*/
		Texture2D playerHealthbar;
		//float tierOneColumnXPos;
		//float tierTwoColumnXPos;
		//float tierThreeColumnXPos;
		//float tierFourColumnXPos;	
		float tierOneRightColumnXPos;
		float tierTwoRightColumnXPos;
		float tierThreeRightColumnXPos;
		float tierFourRightColumnXPos;
		float buttonCenterPosX;
		float rightBoxPosX;
		/**This contains the array of resources that the player collects.*/
		int[] resources;
		/**This is the players health.*/
		public float health;
		/**default health of player*/
		public float defaultHealth;
		/**this is the player health bar width*/
		public float playerHealthbarWidth = 128f;
		static float defaultPlayerHealthbarWidth = 128f;
		/**this is the player health bar height*/
		static int playerHealthbarHeight = 32;
		public float healthScaleRemovalValue;
		bool isHealthScaleRemovalValueSet;
		public bool isPlayerHealthDifferent;
		
		public float previousHealth = 0;
		static int costScale = 1;
		Rect tierOnePosition;
		Rect tierTwoPosition;
		Rect tierThreePosition;
		Rect tierFourPosition;
		bool isGameLoaded;
		
			
		// Use this for initialization
		void Start ()
		{
				playerSaveLoadMethods = new PlayerSaveLoadMethods ();
				listOfBaseUpgradeObjects = new ArrayList ();
				//Load the icons for the resource layout
				ironIcon = Resources.Load ("UITextures/ironIcon", typeof(Texture2D)) as Texture2D;
				copperIcon = Resources.Load ("UITextures/copperIcon", typeof(Texture2D)) as Texture2D;
				alumIcon = Resources.Load ("UITextures/alumIcon", typeof(Texture2D)) as Texture2D;
				diamondIcon = Resources.Load ("UITextures/diamondIcon", typeof(Texture2D)) as Texture2D;
				uranIcon = Resources.Load ("UITextures/uranIcon", typeof(Texture2D)) as Texture2D;
				hydrogenIcon = Resources.Load ("UITextures/hydrogenIcon", typeof(Texture2D)) as Texture2D;
				platIcon = Resources.Load ("UITextures/platIcon", typeof(Texture2D)) as Texture2D;
				leadIcon = Resources.Load ("UITextures/leadIcon", typeof(Texture2D)) as Texture2D;
				goldIcon = Resources.Load ("UITextures/goldIcon", typeof(Texture2D)) as Texture2D;
				unobtainIcon = Resources.Load ("UITextures/unobtainIcon", typeof(Texture2D)) as Texture2D;
				asteroidIcon = Resources.Load ("UITextures/asteroidIcon", typeof(Texture2D)) as Texture2D;
				
				//Load the player health bar texture
				playerHealthbar = Resources.Load ("UITextures/playerHealthBar", typeof(Texture2D)) as Texture2D;
				
				
				//The style for the main title
				boxGUIStyle = new GUIStyle ();
				boxGUIStyle.fontSize = 14;
				boxGUIStyle.normal.textColor = Color.white;
		
				//tierOneColumnXPos = (40 * 1);
				//tierTwoColumnXPos = (40 * 4);
				//tierThreeColumnXPos = (40 * 7);
				//tierFourColumnXPos = (40 * 10);
		
		
				tierOneRightColumnXPos = screenWidth - (defaultButtonWidth * 1);
				tierTwoRightColumnXPos = screenWidth - (defaultButtonWidth * 2);
				tierThreeRightColumnXPos = screenWidth - (defaultButtonWidth * 3);
				tierFourRightColumnXPos = screenWidth - (defaultButtonWidth * 4);
		
		
				buttonCenterPosX = (screenWidth / 2) - (defaultButtonWidth / 2);
				rightBoxPosX = screenWidth - (defaultButtonWidth * 3);
				isHealthScaleRemovalValueSet = false;
				//Add the upgrades
				//Tier 1
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (1, "Auto Turret", (costScale * 8), 0, 0, 0, 0, (costScale * 2), 0, 0, 0, 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (1, "Shell", (costScale * 8), 0, 0, 0, 0, (costScale * 2), 0, 0, 0, 0, false));
				//Tier 2
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (2, "Auto Turret", (costScale * 4), 0, 0, 0, 0, (costScale * 2), (costScale * 2), (costScale * 2), 0, 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (2, "Shell", 0, 0, 0, 0, 0, (costScale * 4), 0, (costScale * 3), (costScale * 2), 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (2, "Shield", 0, (costScale * 5), (costScale * 1), 0, 0, 0, 0, 0, (costScale * 4), 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (2, "Missile Battery", (costScale * 2), 0, (costScale * 3), 0, 0, (costScale * 3), 0, (costScale * 1), (costScale * 1), 0, false));
				//Tier 3
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Auto Turret", (costScale * 1), 0, 0, (costScale * 3), 0, (costScale * 2), (costScale * 3), (costScale * 1), 0, 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Shell", 0, 0, 0, (costScale * 6), 0, 0, 0, (costScale * 2), (costScale * 2), 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Shield", 0, (costScale * 1), (costScale * 1), (costScale * 4), (costScale * 1), 0, 0, (costScale * 2), (costScale * 1), 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Missile Battery", (costScale * 1), (costScale * 1), 0, (costScale * 2), (costScale * 1), (costScale * 2), (costScale * 2), (costScale * 1), 0, 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Nuclear Weapons", 0, 0, 0, (costScale * 4), (costScale * 3), (costScale * 1), 0, (costScale * 1), 0, 0, false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (3, "Mine Field", 0, (costScale * 1), (costScale * 2), (costScale * 3), (costScale * 1), 0, (costScale * 2), (costScale * 1), 0, 0, false));
				//Tier 4
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Auto Turret", 0, 0, 0, (costScale * 2), 0, (costScale * 1), (costScale * 2), (costScale * 1), 0, (costScale * 4), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Shell", 0, 0, 0, (costScale * 1), 0, 0, 0, (costScale * 1), (costScale * 1), (costScale * 7), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Shield", 0, 0, 0, (costScale * 3), (costScale * 1), 0, 0, (costScale * 2), 0, (costScale * 4), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Missile Battery", 0, 0, 0, (costScale * 2), (costScale * 1), (costScale * 2), 0, (costScale * 1), 0, (costScale * 3), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Nuclear Weapons", 0, 0, 0, (costScale * 3), (costScale * 3), (costScale * 1), 0, (costScale * 1), 0, (costScale * 2), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Mine Field", 0, 0, 0, (costScale * 3), (costScale * 1), 0, 0, (costScale * 1), 0, (costScale * 5), false));
				listOfBaseUpgradeObjects.Add (new BaseUpgradeObject (4, "Orbiting Platform", 0, (costScale * 2), (costScale * 1), 0, 0, 0, 0, (costScale * 1), 0, (costScale * 5), false));
				if(Application.loadedLevelName.Equals("main"))
				{
					levelName = "HomeBase";
				}else if(Application.loadedLevelName.Equals("HomeBase"))
				{
					levelName = "main";
				}
		}
	
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update ()
		{
				if (Application.loadedLevelName.Equals ("HomeBase")) {
						//isLevelHomeBase = true;
				} else {
						//isLevelHomeBase = false;
				}
				
				playerController = (PlayerCenter)FindObjectOfType (typeof(PlayerCenter));
		
				if (playerController != null) {
						/*if (!isGameLoaded) {
								//Application.LoadLevel("main");
								PlayerSaveObject loadMe = new PlayerSaveObject ();
								PlayerSaveObject playerInfo = loadMe.loadTheGame ();
						
								if (playerInfo != null) {
										playerController.setResourceList (playerInfo.listOfResourcesCollected);
										playerController.SetPlayerHealth ((float)playerInfo.playerHealth);
										health = (float)playerInfo.playerHealth;
										isGameLoaded = true;
							
								}
						}*/
						/*
						if (previousHealth != health && previousHealth != 0) {
								isPlayerHealthDifferent = true;
								previousHealth = health;
						} else {
								isPlayerHealthDifferent = false;
								previousHealth = health;
						}
						*/
						
						resources = playerController.getResourceList ();
						health = playerController.GetPlayerHealth ();
						
						//defaultHealth = playerController.GetDefaultPlayerHealth ();
						if (!isHealthScaleRemovalValueSet) {
								healthScaleRemovalValue = playerHealthbarWidth / health;
								isHealthScaleRemovalValueSet = true;
						}
						
				}
		
				//Reese 9/26/2014 This will trigger the menu for the player
				if (Input.GetKeyDown (KeyCode.Escape)) {
						isInGameUIEnabled = !isInGameUIEnabled;
				} else if (Input.GetKeyDown (KeyCode.I)) {
						//display the inventory
						isDisplayingInventory = !isDisplayingInventory;
				}
		}
		/// <summary>
		/// Draws the in game UI.
		/// </summary>
		void drawInGameUI ()
		{	
				// Make the second button. If it is pressed, this will display available upgrades for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight), "Upgrades")) {
						boxTitle = "Upgrades";
				}
				
				// Make the second button. If it is pressed, this will display available upgrades for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight), "Home Base Upgrades")) {
						boxTitle = "Home Base Upgrades";
				}
				
				// Make the thrid button. If it is pressed, this will display levels to warp to
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight), "Warp")) {
						boxTitle = "Warp";
				}
				// Make the fourth button.If it is pressed, this will save the players game
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 4), defaultButtonWidth, defaultButtonHeight), "Save")) {
						boxTitle = "Save";
						bool isSucessful = playerSaveLoadMethods.saveTheGame ((int)health, playerController.GetPurchasedShipUpgradeList (), playerController.resources, playerController.GetPurchasedHomeBaseUpgradeList ());
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
						if (isSucessful) {
								Debug.Log ("The game has been successfully saved.");
						}
				}
				// Make the fifth button. If it is pressed, this will display available save files to load for the player
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 5), defaultButtonWidth, defaultButtonHeight), "Load")) {
						boxTitle = "Load";
				}
				// Make the six button.If it is pressed, this will exit the game
				if (GUI.Button (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 6), defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.LoadLevel ("startMenuUI");
				}
	
	
				if (boxTitle.Equals ("Warp")) {
						drawWarpMenu (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight));
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
				} else if (boxTitle.Equals ("Upgrades")) {
						drawUpgradeMenu (new Rect (buttonCenterPosX, (screenHeight / 4) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight));
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
				} else if (boxTitle.Equals ("Home Base Upgrades")) {
						drawHomeBaseUpgradeMenu (new Rect (buttonCenterPosX, (screenHeight / 4) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight));
				} else if (boxTitle.Equals ("Load")) {
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
						
						if (playerSaveLoadMethods != null) {
								PlayerPrefs.SetInt ("health", playerSaveLoadMethods.loadThePlayerHealth ());
								PlayerPrefs.SetString ("shipUpgrades", playerSaveLoadMethods.loadThePlayerShipUpgrades ());
								PlayerPrefs.SetString ("homeBaseUpgrades", playerSaveLoadMethods.loadThePlayerHomebaseUpgrades ());
								PlayerPrefs.SetString ("resourcesCollected", playerSaveLoadMethods.loadThePlayerResources ());
								
						}
				}
		}
		
		/// <summary>
		/// Raises the GU event.
		/// </summary>
		void OnGUI ()
		{
		
				drawPlayerHealthReadout ();
				if (isDisplayingInventory) {
						//draw the resource readout
						drawResourcesReadout ();
				}
				
				if (isInGameUIEnabled) {
			
						player = GameObject.Find ("Player2");
			
						//playerTest = GameObject.Find("Player Controller Test");
			
						//gameObject.GetComponent<PlayerControler>().enabled = false;
						//gameObject.GetComponent<PlayerControllerTest>().enabled = false;
			
			
						//player.SetActive (false);
						//playerTest.SetActive (true);
						//playerTest.GetComponent<PlayerControllerTest>().enabled = false;
						drawInGameUI ();
						//this disables the player object
						if (player != null) {
								//player.SetActive(false);
								//player.GetComponent<PlayerControler> ().enabled = false;
								//player.GetComponent<PlayerControllerTest> ().enabled = false;
						}
				} else {
						if (player != null) {
							//player.SetActive(true);
								//player.GetComponent<PlayerControler> ().enabled = true;
								//player.GetComponent<PlayerControllerTest> ().enabled = true;
						}					
				}
		}
		
		/// <summary>
		/// Draws the load menu.
		/// </summary>
		/// <param name="originPosition">Origin position.</param>
		void drawLoadMenu (Rect originPosition)
		{
				//originPosition.
				//TODO: load in the current saves
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				// This will warp the player to the home base scene
				//how many saves determine how many buttons there are
				if (GUI.Button (originPosition, "Save 1")) {
						//Application.LoadLevel ("HomeBase");
			
				}
		}
		
		/// <summary>
		/// Draws the warp menu.
		/// </summary>
		/// <param name="originPosition">Origin position.</param>
		void drawWarpMenu (Rect originPosition)
		{
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				// This will warp the player to the home base scene
				if (GUI.Button (originPosition, levelName)) {
						Application.LoadLevel (levelName);
				
				}
		}
		/// <summary>
		/// Draws the home base upgrades.
		/// </summary>
		/// <param name="originPosition">Origin position.</param>
		/// <param name="tierLevel">Tier level.</param>
		void drawHomeBaseUpgrades (Rect originPosition, int tierLevel)
		{
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				foreach (BaseUpgradeObject item in listOfBaseUpgradeObjects) {	
						if (item.tierLevel == tierLevel) {
								if (GUI.Button (originPosition, "Tier" + tierLevel + " " + item.upgradeName)) {
										if (tierLevel == 1 && item.upgradeName.Equals ("Auto Turret")) {
												//TODO: create methoid that will attemp to buy a item, give it item tier and item name
												Debug.Log ("you are trying to buy a tier 1 auto turret");
										}
												
								}
								originPosition.Set (originPosition.x, originPosition.y + originPosition.height, defaultButtonWidth, defaultButtonHeight);
						}		
				}
		}
		/// <summary>
		/// Draws the home base upgrade menu.
		/// </summary>
		/// <param name="originPosition">Origin position.</param>
		void drawHomeBaseUpgradeMenu (Rect originPosition)
		{
				Rect previousOriginPosition = new Rect (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
				
				
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				if (isDrawingTier1) {
						drawHomeBaseUpgrades (originPosition, 1);
				}
				if (GUI.Button (originPosition, "Tier One")) {
						isDrawingTier1 = true;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
						tierOnePosition.Set (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
				}

				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (isDrawingTier2) {
						drawHomeBaseUpgrades (originPosition, 2);
				}
		
				if (GUI.Button (originPosition, "Tier Two")) {
						isDrawingTier1 = false;
						isDrawingTier2 = true;
						isDrawingTier3 = false;
						isDrawingTier4 = false;
						tierTwoPosition.Set (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
				}

				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (isDrawingTier3) {
						drawHomeBaseUpgrades (originPosition, 3);
				}
		
				if (GUI.Button (originPosition, "Tier Three")) {
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = true;
						isDrawingTier4 = false;
						tierThreePosition.Set (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
				}
				
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (isDrawingTier4) {
						drawHomeBaseUpgrades (originPosition, 4);
				}
		
				if (GUI.Button (originPosition, "Tier Four")) {
						isDrawingTier1 = false;
						isDrawingTier2 = false;
						isDrawingTier3 = false;
						isDrawingTier4 = true;
						tierFourPosition.Set (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
				}
				
		
		}
		/// <summary>
		/// Draws the player health readout.
		/// </summary>
		void drawPlayerHealthReadout ()
		{
		if(playerController.wasPlayerHit){
			playerHealthbarWidth -= healthScaleRemovalValue;
		}

				
						Rect healthBarRect = new Rect (screenWidth - playerHealthbarWidth, screenHeight - playerHealthbarHeight, playerHealthbarWidth, playerHealthbarHeight);
						Rect healthBarLabelRect = new Rect (screenWidth - defaultPlayerHealthbarWidth, screenHeight - playerHealthbarHeight, defaultPlayerHealthbarWidth, playerHealthbarHeight);
						GUI.DrawTexture (healthBarRect, playerHealthbar, ScaleMode.StretchToFill, true, 0.0f);
						healthBarRect.Set (healthBarRect.x, healthBarRect.y, healthBarRect.width, healthBarRect.height);
						GUI.Label (healthBarLabelRect, "Health", boxGUIStyle);
				playerController.setWasPlayerHit(false);
		}
		
		/// <summary>
		/// Draws A resource.
		/// </summary>
		/// <param name="originRect">Origin rect.</param>
		/// <param name="tierLevel">Tier level.</param>
		/// <param name="resourceName">Resource name.</param>
		void drawAResource (Rect originRect, int tierLevel, string resourceName, Texture2D icon, int index)
		{
				float iconWidthAdjustment;
				float amountLabelPosAdjust;
				float labelPosAdjust;

				if (resourceName.Equals ("Hydrogen") 
						|| resourceName.Equals ("Diamond")) {
						iconWidthAdjustment = (icon.width);
						amountLabelPosAdjust = icon.width / 2;
						labelPosAdjust = icon.width * 2;
				} else {
						iconWidthAdjustment = (icon.width / 2);
						amountLabelPosAdjust = 0;
						labelPosAdjust = icon.width;
				}
				Rect texturePositon = new Rect (originRect.x - amountLabelPosAdjust, originRect.y, (icon.height / 2), (icon.height / 2));
				Rect labelPosition = new Rect (originRect.x + (labelPosAdjust), originRect.y, defaultButtonWidth, defaultButtonHeight);
				Rect amountLabelPosition = new Rect (labelPosition.x - iconWidthAdjustment, labelPosition.y, labelPosition.width, labelPosition.height);
		
				GUI.Label (labelPosition, resourceName, boxGUIStyle);
				GUI.DrawTexture (texturePositon, icon, ScaleMode.ScaleToFit, true, 0.0f);
				if (resources != null) {
						GUI.Label (amountLabelPosition, resources [index].ToString ());
				} else {
						string resourcesText = playerSaveLoadMethods.loadThePlayerResources ();
						string[] tempListResources = resourcesText.Split (',');
						GUI.Label (amountLabelPosition, tempListResources [index].ToString ());
				}
				
		}
		
		/// <summary>
		/// Draws the resources readout.
		/// </summary>
		void drawResourcesReadout ()
		{
				// Make a background box for the container "Resources", this displays stats, resources, thats about it
				//This will display the read out of current resources collected by the player//Index – ResouceName
				//1 – Aluminum
				//2 – Copper
				//3 – Diamond
				//4 – Gold
				//		5 – Hydrogen
				//		6 – Iron
				//		7 – Lead
				//		8 – Platinum
				//		9 – Unobtanium
				//		10- Uranium
				//		0 – Asteroid
				
				drawAGUIBox (new Rect ((screenWidth / 2) - ((defaultButtonWidth * 3) / 2), 10, (defaultButtonWidth * 3), screenHeight), "Inventory");
				//asteroid, Iron, copper, Aluminum, Hydrogen tier 1
				Rect originRect = new Rect ((screenWidth / 2) - ((defaultButtonWidth * 3) / 2), 10, defaultButtonWidth, defaultButtonHeight);
				Rect originalOriginRect = new Rect (originRect.x, originRect.y, defaultButtonWidth, defaultButtonHeight);
				//Tier 1
				originRect.Set (originRect.x + 10, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 1, "Asteroid", asteroidIcon, 0);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 1, "Iron", ironIcon, 6);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 1, "Copper", copperIcon, 2);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 1, "Aluminum", alumIcon, 1);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 1, "Hydrogen", hydrogenIcon, 5);
				
				
				//Tier 2
				originRect.Set (originalOriginRect.x + defaultButtonWidth, originalOriginRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 2, "Platinum", platIcon, 8);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 2, "Gold", goldIcon, 4);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 2, "Lead", leadIcon, 7);
				
				//Tier 3
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 3, "Uranium", uranIcon, 10);
				originRect.Set (originRect.x, originRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 3, "Diamond", diamondIcon, 3);
				//Tier 4
				originRect.Set (originalOriginRect.x + (defaultButtonWidth * 2), originalOriginRect.y + (asteroidIcon.height / 2), defaultButtonWidth, defaultButtonHeight);
				drawAResource (originRect, 4, "Unobtainium", unobtainIcon, 9);
		}	
		
		/// <summary>
		/// Draws the AGUI box.
		/// </summary>
		/// <param name="rect">Rect.</param>
		/// <param name="boxTitle">Box title.</param>
		void drawAGUIBox (Rect rect, string boxTitle)
		{
				GUI.Box (rect, boxTitle);
		}
		
			
		/// <summary>
		/// Draws the upgrade menu.
		/// </summary>
		/// <param name="originPosition">Origin position.</param>
		void drawUpgradeMenu (Rect originPosition)
		{
				GameObject player = GameObject.Find ("Player2");

				Rect previousOriginPosition = new Rect (originPosition.x, originPosition.y, originPosition.width, originPosition.height);
			
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
		
				//GUI.Label (new Rect (tierOneRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Offense", boxGUIStyle);
				if (GUI.Button (originPosition, "Blaster Power")) {
						if (player.GetComponent<PlayerCenter> ().incBlasterPower ()) {
								Debug.Log ("Upgrade purchased!");
								// Purchase was successful
						} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
						}
				}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "More Blasters")) {
						if (player.GetComponent<PlayerCenter> ().incNumBlasters ()) {
								// Purchase was successful
						} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
						}
				}
				//originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				//if (GUI.Button (originPosition, "Homing Missiles")) {
				//		if (player.GetComponent<PlayerCenter> ().incMissilePower ()) {
								// Purchase was successful
				//		} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
				//		}
				//}
					
				originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);
				//GUI.Label (new Rect (tierTwoRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Defense", boxGUIStyle);
				if (GUI.Button (originPosition, "Hull Strength")) {
						if (player.GetComponent<PlayerCenter> ().incHullStrength ()) {
								Debug.Log ("Upgrade purchased!");
								// Purchase was successful
						} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
						}
				}
				//originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				//if (GUI.Button (originPosition, "Shields")) {
				//		if (player.GetComponent<PlayerCenter> ().incShieldPower ()) {
				//				Debug.Log ("Upgrade purchased!");
								// Purchase was successful
				//		} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
				//		}
				//}
				originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				if (GUI.Button (originPosition, "Regen")) {
						if (player.GetComponent<PlayerCenter> ().incHullRegen ()) {
								Debug.Log ("Upgrade purchased!");
								// Purchase was successful
						} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
						}
				}
				
				originPosition = new Rect (previousOriginPosition.x + (defaultButtonWidth * 2), previousOriginPosition.y, previousOriginPosition.width, previousOriginPosition.height);	
				originPosition.Set (originPosition.x + defaultButtonWidth, originPosition.y, defaultButtonWidth, defaultButtonHeight);
				//GUI.Label (new Rect (tierThreeRightColumnXPos, (bufferSize * 2), defaultButtonWidth, defaultButtonHeight), "Utility", boxGUIStyle);
				if (GUI.Button (originPosition, "Flight Speed")) {
						if (player.GetComponent<PlayerCenter> ().incMovementLevel ()) {
								Debug.Log ("Upgrade purchased!");
								// Purchase was successful
						} else {
								// Purchase was not successful (max upgrade level reached, not enough resources)
						}
				}
				//Commented out, not wanted
				//originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				//if (GUI.Button (originPosition, "Radar")) {
				//	if(player.GetComponent<PlayerCenter> ().incRadarLevel ()){
				//		Debug.Log("Upgrade purchased!");
				// Purchase was successful
				//	} else {
				// Purchase was not successful (max upgrade level reached, not enough resources)
				//	}
				//}
				//originPosition.Set (originPosition.x, originPosition.y + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight);
				//if (GUI.Button (originPosition, "Resource Magnet")) {
				//	if(player.GetComponent<PlayerCenter> ().incResourceMagnet ()){
				//		Debug.Log("Upgrade purchased!");
				// Purchase was successful
				//	} else {
				// Purchase was not successful (max upgrade level reached, not enough resources)
				//	}
				//}
		}
	
}
	
