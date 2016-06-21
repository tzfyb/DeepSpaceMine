using UnityEngine;
using System.Collections;
// Reese 9/26/2014 Created this class to do all the "UIey" stuff
public class MainMenuUI : MonoBehaviour
{
		/**This variable will control the Ui displaying so that it does not dissapear after the user releases the "escape" key*/
		bool isInGameUIEnabled = false;
		/**This is the screen width*/
		int screenWidth = Screen.width;
		/**This is the screen height*/
		int screenHeight = Screen.height;
		/**This is the default button width*/
		int defaultButtonWidth = 160;
		/**This is the default button width*/
		int defaultButtonHeight = 40;
		/**This is the default side window width*/
		float defaultSideWindowWidth = Screen.width / 4;
		/**This is the default side window height*/
		float defaultSideWindowHeight = Screen.height;
		/**This is the default space for ui item buffer*/
		int defaultUIItemBuffer = 10;
		/**This is the styling for the game title on the main screen*/
		GUIStyle gameTitleStyle;
		Texture2D titleLogo;
	
		// This will draw the in game menu
		void drawInGameUI ()
		{
		//This draws the title logo for Deep Space Mine
		if (titleLogo) {
			GUI.DrawTexture (new Rect ((screenWidth / 2) - (titleLogo.width / 2), 0 + titleLogo.height , titleLogo.width, titleLogo.height), titleLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}
		if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + defaultButtonHeight, defaultButtonWidth, defaultButtonHeight), "New Game")) {
						//This loads the main scene, or in our case the core of the game.
						PlayerPrefs.SetInt ("health", 10);
						PlayerPrefs.SetString ("shipUpgrades", "");
						PlayerPrefs.SetString ("homeBaseUpgrades", "");
						PlayerPrefs.SetString ("resourcesCollected", "");
						Application.LoadLevel ("main");
				}
				// Make the fourth button. If it is pressed, this will display available save files to load for the player
		if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + (defaultButtonHeight * 2), defaultButtonWidth, defaultButtonHeight), "Load Last Save")) {
						Application.LoadLevel("main");
				}
				// Make the sixth button.If it is pressed, this will exit the game
		if (GUI.Button (new Rect ((screenWidth / 2) - (defaultButtonWidth / 2), (screenHeight / 2) + (defaultButtonHeight * 3), defaultButtonWidth, defaultButtonHeight), "Exit")) {
						Application.Quit ();
				}
		}
	
		// This updates the UI, similar to Update
		void OnGUI ()
		{
				drawInGameUI ();
			
		}
		// Use this for initialization
		void Start ()
		{
				titleLogo = Resources.Load ("UITextures/deepspaceminelogo1", typeof(Texture2D)) as Texture2D;
				//The style for the main title
				gameTitleStyle = new GUIStyle();
				//gameTitleStyle.fontSize = 48;
				//gameTitleStyle.normal.textColor = Color.white;
				gameTitleStyle.alignment = TextAnchor.MiddleCenter;
				//titleWidth = GUI.skin.label.CalcSize(titleLogo).x;
				//gameTitleStyle.CalcSize
		}
	
		// Update is called once per frame
		void Update ()
		{
			camera.backgroundColor = Color.black;
		}
}

