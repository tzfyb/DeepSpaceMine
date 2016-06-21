using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
		//destroys everthing as it leaves but the player
		if (other.tag == "Player")
			return;
		Destroy(other.gameObject);
	}
}