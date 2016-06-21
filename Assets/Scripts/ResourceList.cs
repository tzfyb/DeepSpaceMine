using UnityEngine;
using System.Collections;

public class ResourceList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (10, 10, 100, 90), "Resources");

		// Shows how much iron you have
		GUI.Label (new Rect (20, 30, 80, 20), "Iron: ");

		// Shows how much Cooper you have
		GUI.Label (new Rect (20, 50, 80, 20), "Cooper: ");

		// Shows how much Hydrogen you have
		GUI.Label (new Rect (20, 70, 80, 20), "Hydrogen: ");

		// Shows how much aluminum you have
		GUI.Label (new Rect (20, 90, 80, 20), "Aluminum: ");

		// Shows how much lead you have
		GUI.Label (new Rect (20, 110, 80, 20), "Lead: ");

		// Shows how much platinum you have
		GUI.Label (new Rect (20, 130, 80, 20), "Platinum: ");

		// Shows how much gold you have
		GUI.Label (new Rect (20, 150, 80, 20), "Gold: ");

		// Shows how much Carbon you have
		GUI.Label (new Rect (20, 170, 80, 20), "Carbon: ");

		// Shows how much uranium you have
		GUI.Label (new Rect (20, 190, 80, 20), "Uranium: ");

		// Shows how much unobtanium you have
		GUI.Label (new Rect (20, 210, 80, 20), "Unobtanium: ");


	}
}
