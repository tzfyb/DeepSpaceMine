using UnityEngine;
using System.Collections;

public class rockAttri : MonoBehaviour {
	public float health;
	public int resources;
	public GameController gc;
	public GameObject PlayerWorld;

	// Use this for initialization
	void Start () {
		PlayerWorld = GameObject.Find("Player2/PlayerWorld");
		gc = PlayerWorld.GetComponent<GameController>();

		health = Random.Range (5, 10);
		resources = Random.Range (5, 50);
	}

	public void ApplyDamage(float DamageAmount)
	{
		health -= DamageAmount;
		//Vector3 position = transform.position;

		if(health < 0f)
		{
			gc.SpawnRemoved(gameObject); //call function in GameController.cs
		}
	}

	public int getResource()
	{
		return resources;
	}

	/*void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "ShipBody")
		{
			Debug.Log (other.name);
			other.transform.SendMessage("ApplyDamage",1,SendMessageOptions.DontRequireReceiver);
			health -=1;
			//Instantiate(boom,gameObject.transform.position-gameObject.transform.forward * 1,Quaternion.identity);
		}
		
	}*/

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "ShipBody")
		{
			Debug.Log ("Collision Detect!");
			GameObject.Find("Player2").GetComponent<PlayerCenter>().ApplyDamage(1f);
			//collision.gameObject.transform.SendMessage("ApplyDamage",1,SendMessageOptions.DontRequireReceiver);
			health -=1;
			//Instantiate(boom,gameObject.transform.position-gameObject.transform.forward * 1,Quaternion.identity);
		}
	}

}
