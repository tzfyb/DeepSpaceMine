using UnityEngine;
using System.Collections;

public class MoverHomeBase : MonoBehaviour {

	public float speed = 5;
	
	void Start ()
	{
		//rigidbody.velocity = transform.localScale * speed;
		rigidbody.velocity = transform.forward * speed;
	}
}