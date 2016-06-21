using UnityEngine;
using System.Collections;


public class DetonationRange : MonoBehaviour {

	public Transform explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//will only detonate if the enemy gets into the bombs collider mesh
	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy") {
			Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
