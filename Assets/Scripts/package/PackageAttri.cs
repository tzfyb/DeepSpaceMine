using UnityEngine;
using System.Collections;

public class PackageAttri : MonoBehaviour {
	public int resourceNum;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "ShipBody")
		{
			Debug.Log ("Triiger detect");
			int type = 0;

			if(name.Contains("Aluminum"))
			{
				type = 1;
			}
			else if(name.Contains("Copper"))
			{
				type = 2;
			}
			else if(name.Contains("Diamond"))
			{
				type = 3;
			}
			else if(name.Contains("Gold"))
			{
				type = 4;
			}
			else if(name.Contains("Hydrogen"))
			{
				type = 5;
			}
			else if(name.Contains("Iron"))
			{
				type = 6;
			}
			else if(name.Contains("Lead"))
			{
				type = 7;
			}
			else if(name.Contains("Platinum"))
			{
				type = 8;
			}
			else if(name.Contains("Unobtanium"))
			{
				type = 9;
			}
			else if(name.Contains("Uranium"))
			{
				type = 10;
			}
			else
			{
				type = 0;
			}

			Debug.Log (type+" " + resourceNum);
			GameObject Player = GameObject.Find("Player2");
			Player.GetComponent<PlayerCenter>().resourceCollector(type,resourceNum);

	
			Destroy(gameObject);
		}
	}

	public void setResourceNum(int amount)
	{
		resourceNum = amount;
	}
}
