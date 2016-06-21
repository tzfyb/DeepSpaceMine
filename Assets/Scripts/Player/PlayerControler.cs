using UnityEngine;
using System.Collections;

[System.Serializable]

public class PlayerControler : MonoBehaviour
{
	private GameObject ship;
	public static float speed;
	float accel;

	// weapon stuff
	public GameObject shot0;
	public GameObject shot1;
	public GameObject shot2;
	public GameObject shot3;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	public Transform shotSpawn5;
	public float fireRate;
	private float nextFire;

	public GameObject cameraRod;

	// Stuff having to do with upgrades
	public float movementLevel;
	// End stuff having to do with upgrades

	void Start ()
	{
		cameraRod = GameObject.Find ("Player2/cameraRod");
		ship = GameObject.Find ("Player2/Ship");
	}
	
	void Update ()
	{
		// Set the turning speed of the ship based on the ship's movement level
		movementLevel = this.GetComponent<PlayerCenter> ().getMovementLevel ();
		float turnSpeed;
		if (movementLevel == 0) {
			turnSpeed = 100F;
		} else if (movementLevel == 1) {
			turnSpeed = 200F;
		} else if (movementLevel == 2) {
			turnSpeed = 300F;		
		} else {
			turnSpeed = 700F;
		}

		// Rotate the ship towards the camera's angle based on the turning speed
		ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, cameraRod.transform.rotation, turnSpeed * Time.deltaTime);
	}
	
	void FixedUpdate ()
	{
		// Shoot and control the rate of fire
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			int blasterPower = this.GetComponent<PlayerCenter>().getBlasterPower();
			if(blasterPower == 0) {
				switch(this.GetComponent<PlayerCenter> ().getNumBlasters())
				{
				case 0:
					Instantiate(shot0, shotSpawn1.position, ship.rigidbody.rotation);
					break;
				case 1:
					Instantiate(shot0, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn3.position, ship.rigidbody.rotation);
					break;
				case 2:
					Instantiate(shot0, shotSpawn1.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				case 3:
					Instantiate(shot0, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn3.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot0, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				}
			} else if (blasterPower == 1) {
				switch(this.GetComponent<PlayerCenter> ().getNumBlasters())
				{
				case 0:
					Instantiate(shot1, shotSpawn1.position, ship.rigidbody.rotation);
					break;
				case 1:
					Instantiate(shot1, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn3.position, ship.rigidbody.rotation);
					break;
				case 2:
					Instantiate(shot1, shotSpawn1.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				case 3:
					Instantiate(shot1, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn3.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot1, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				}
			} else if (blasterPower == 2) {
				switch(this.GetComponent<PlayerCenter> ().getNumBlasters())
				{
				case 0:
					Instantiate(shot2, shotSpawn1.position, ship.rigidbody.rotation);
					break;
				case 1:
					Instantiate(shot2, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn3.position, ship.rigidbody.rotation);
					break;
				case 2:
					Instantiate(shot2, shotSpawn1.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				case 3:
					Instantiate(shot2, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn3.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot2, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				}
			} else if (blasterPower == 3) {
				switch(this.GetComponent<PlayerCenter> ().getNumBlasters())
				{
				case 0:
					Instantiate(shot3, shotSpawn1.position, ship.rigidbody.rotation);
					break;
				case 1:
					Instantiate(shot3, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn3.position, ship.rigidbody.rotation);
					break;
				case 2:
					Instantiate(shot3, shotSpawn1.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				case 3:
					Instantiate(shot3, shotSpawn2.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn3.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn4.position, ship.rigidbody.rotation);
					Instantiate(shot3, shotSpawn5.position, ship.rigidbody.rotation);
					break;
				}
			}
		}

		// Set the movement speed based on the ship's movement level
		movementLevel = this.GetComponent<PlayerCenter> ().getMovementLevel ();
		float maxSpeed;
		if (movementLevel == 0) {
			maxSpeed = 10;
		} else if (movementLevel == 1) {
			maxSpeed = 15;
		} else if (movementLevel == 2) {
			maxSpeed = 20;		
		} else {
			maxSpeed = 25;
		}

		// Reduce the movement speed for more controlled movement if the button is being held down
		if (Input.GetButton ("Slow"))
			maxSpeed /= 2;

		accel = maxSpeed - speed;

		float sqrOffset = ship.transform.localPosition.sqrMagnitude;
		Vector3 offsetDir = ship.transform.localPosition.normalized;
		//this takes care of realigning after collisions, where the ship gets displaced due to its rigidbody.
		//I'm pretty sure this is the best way to do it (have the ship and the rig move toward their mutual center)
		ship.transform.Translate(-offsetDir * sqrOffset * 20 * Time.fixedDeltaTime);

		// Move the player in the direction of any buttons being pressed
		if (Input.GetButton ("Forward") || Input.GetButton ("Back") || Input.GetButton ("Left") || Input.GetButton ("Right") || Input.GetButton ("Up") || Input.GetButton ("Down")) {
			speed += accel * Time.fixedDeltaTime;			
			if (Input.GetButton ("Forward"))
				transform.Translate ((offsetDir * sqrOffset * 50 + ship.transform.forward * speed) * Time.fixedDeltaTime, Space.World);
			if (Input.GetButton ("Back"))
				transform.Translate ((offsetDir * sqrOffset * 50 - ship.transform.forward * speed) * Time.fixedDeltaTime, Space.World);
			if (Input.GetButton ("Left"))
				transform.Translate ((offsetDir * sqrOffset * 50 - ship.transform.right * speed) * Time.fixedDeltaTime, Space.World);
			if (Input.GetButton ("Right"))
				transform.Translate ((offsetDir * sqrOffset * 50 + ship.transform.right * speed) * Time.fixedDeltaTime, Space.World);
			if (Input.GetButton ("Up"))
				transform.Translate ((offsetDir * sqrOffset * 50 + ship.transform.up * speed) * Time.fixedDeltaTime, Space.World);
			if (Input.GetButton ("Down"))
				transform.Translate ((offsetDir * sqrOffset * 50 - ship.transform.up * speed) * Time.fixedDeltaTime, Space.World);
		} else {
			speed -= Mathf.Clamp (speed * Mathf.Abs (speed), -30, 100) * Time.fixedDeltaTime;
		}
	}
}