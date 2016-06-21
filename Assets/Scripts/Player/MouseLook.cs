using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	// Set the sensitivity for how fast the mouse turns
	public float sensitivityX;
	public float sensitivityY;

	GameObject player;

	float rotationX = 0F;
	float rotationY = 0F;

	void Start ()
	{
		player = GameObject.Find ("Player2/Ship");
	}

	void Update ()
	{
		// Multiply how much the mouse moved in a direction by the sensitivity
		rotationX = sensitivityX * Input.GetAxis ("Mouse X");
		rotationY = sensitivityY * Input.GetAxis ("Mouse Y");

		// Rotate this object by that much
		transform.Rotate (-rotationY, rotationX, 0, Space.Self);

		// Make this object stick to the player
		transform.position = player.transform.position;
	}
}
