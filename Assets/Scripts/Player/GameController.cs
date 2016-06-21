using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private GameObject Asteroid;
	private GameObject Aluminum;
	private GameObject Copper;
	private GameObject Diamond;
	private GameObject Gold;
	private GameObject Hydrogen;
	private GameObject Iron;
	private GameObject Lead;
	private GameObject Platinum;
	private GameObject Unobtanium;
	private GameObject Uranium;
	private GameObject EnemyShip;

	private static ArrayList spawns;

	public Vector3 spawnValues;
	public int SpawnMax;
	public int spawnCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float innersphere;
	public float outersphere;
	public int deletNum;
	public int numEnemies;
	public int maxEnemies;

//	public Hashtable EachSpawnNum = new Hashtable();

	public int[] EachSpawnNum; 

	void Start ()
	{
		spawns = new ArrayList (); //store all the spawn information
		numEnemies = 0;
		maxEnemies = 1;
		EachSpawnNum = new int[12] {0, 0, 0, 0,
									0, 0, 0, 0,
									0, 0, 0, 0};

		//StartCoroutine (SpawnWaves ());

		Asteroid = (GameObject)Resources.Load ("Prefabs/Spawns/Asteroid", typeof(GameObject));
		Aluminum = (GameObject)Resources.Load ("Prefabs/Spawns/Aluminum", typeof(GameObject));
		Copper = (GameObject)Resources.Load ("Prefabs/Spawns/Copper", typeof(GameObject));
		Diamond = (GameObject)Resources.Load ("Prefabs/Spawns/Diamond", typeof(GameObject));
		Gold = (GameObject)Resources.Load ("Prefabs/Spawns/Gold", typeof(GameObject));
		Hydrogen = (GameObject)Resources.Load ("Prefabs/Spawns/HydrogenCanister", typeof(GameObject));
		Iron = (GameObject)Resources.Load ("Prefabs/Spawns/Iron", typeof(GameObject));
		Lead = (GameObject)Resources.Load ("Prefabs/Spawns/Lead", typeof(GameObject));
		Platinum = (GameObject)Resources.Load ("Prefabs/Spawns/Platinum", typeof(GameObject));
		Unobtanium = (GameObject)Resources.Load ("Prefabs/Spawns/Unobtanium", typeof(GameObject));
		Uranium = (GameObject)Resources.Load ("Prefabs/Spawns/Uranium", typeof(GameObject));
		EnemyShip = (GameObject)Resources.Load ("Prefabs/Spawns/EnemyShip", typeof(GameObject));
	}


	void FixedUpdate()
	{
		spawnCount = spawns.Count;
	
		SpawnGenerator ();
		//SpawnWaves ();
	}

	//when initialize always return 4 kinds dont know why
	private GameObject randomRock(){
		int rock = Random.Range (0, 12);
		GameObject prepare;
		
		switch (rock) {
		case 0:
			prepare = Asteroid;
			break;
		case 1:
			prepare = Aluminum;
			break;
		case 2:
			prepare = Copper;
			break;
		case 3:
			prepare = Diamond;
			break;
		case 4:
			prepare = Gold;
			break;
		case 5:
			prepare = Hydrogen;
			break;
		case 6:
			prepare = Iron;
			break;
		case 7:
			prepare = Lead;
			break;
		case 8:
			prepare = Platinum;
			break;
		case 9:
			prepare = Unobtanium;
			break;
		case 10:
			prepare = Uranium;
			break;
		case 11:
			if(numEnemies < maxEnemies)
			{
				prepare = EnemyShip;
				numEnemies++;
			} else
			{
				prepare = Asteroid;
			}
			break;
		default:
			prepare = Asteroid;
			break;
		}

		return prepare;
	}

	public void SpawnGenerator()
	{
		ArrayList deleteSpawns = new ArrayList ();
		
		while (spawns.Count < SpawnMax)
		{
			Vector3 spawnPosition;
			GameObject prepareSpawn = randomRock ();
			
			spawnPosition = Random.onUnitSphere * Random.Range(innersphere, outersphere);
			spawnPosition += transform.position; // Makes the spawn locations always center on this game object (and thus, the player)
			
			Quaternion spawnRotation = Quaternion.identity;
			
//			Collider[] hitColliders = Physics.OverlapSphere(prepareSpawn.renderer.bounds.center, Mathf.Max (new float[] {prepareSpawn.renderer.bounds.extents.x, prepareSpawn.renderer.bounds.extents.y, prepareSpawn.renderer.bounds.extents.z}));
			//Debug.Log(hitColliders.Length);
//			while(hitColliders.Length != 0)
//			{
//				spawnPosition = Random.onUnitSphere * Random.Range(innersphere, outersphere);
//				spawnPosition += transform.position; // Makes the spawn locations always center on this game object (and thus, the player)
//				hitColliders = Physics.OverlapSphere(prepareSpawn.renderer.bounds.center, Mathf.Max (new float[] {prepareSpawn.renderer.bounds.extents.x, prepareSpawn.renderer.bounds.extents.y, prepareSpawn.renderer.bounds.extents.z}));
//			}

			eachSpawnCount(prepareSpawn);
			GameObject spawnCopy = (GameObject)Instantiate (prepareSpawn, spawnPosition, spawnRotation);
			spawns.Add(spawnCopy);
		}

		foreach(GameObject spawn in spawns) {
			//Reese 11/6/2014 if i exit the game via the menu and reload this is always null gameobjects, maybe reintialized them?
			if(spawn != null){
				if(Vector3.Distance(spawn.transform.position, transform.position) > outersphere && (!deleteSpawns.Contains(spawn)))
				{
					deleteSpawns.Add(spawn);
				}
			}
		}

		deletNum = deleteSpawns.Count;

		foreach(GameObject deleteSpawn in deleteSpawns)
		{
			spawns.Remove (deleteSpawn);
			Destroy (deleteSpawn);
		}
	}

	public void eachSpawnCount(GameObject spawn)
	{
		if (spawn.name.Contains ("Aluminum")) {
						EachSpawnNum [0]++;
				} else if (spawn.name.Contains ("Copper")) {
						EachSpawnNum [1]++;
				} else if (spawn.name.Contains ("Diamond")) {
						EachSpawnNum [2]++;
				} else if (spawn.name.Contains ("Gold")) {
						EachSpawnNum [3]++;
				} else if (spawn.name.Contains ("Hydrogen")) {
						EachSpawnNum [4]++;
				} else if (spawn.name.Contains ("Iron")) {
						EachSpawnNum [5]++;
				} else if (spawn.name.Contains ("Lead")) {
						EachSpawnNum [6]++;
				} else if (spawn.name.Contains ("Platinum")) {
						EachSpawnNum [7]++;
				} else if (spawn.name.Contains ("Unobtanium")) {
						EachSpawnNum [8]++;
				} else if (spawn.name.Contains ("Uranium")) {
						EachSpawnNum [9]++;
				} else if (spawn.name.Contains ("EnemyShip")) {
						EachSpawnNum [10]++;
				} else {
						EachSpawnNum[11]++;
				}
	}

	//This funtion should be called to tell this script that such spawn has been destroyed
	public void SpawnRemoved(GameObject spawn)
	{
		string type = spawn.name;
		GameObject package;


		if(type.Contains("Aluminum"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/AluminumPackage", typeof(GameObject));
		}
		else if(type.Contains("Copper"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/CopperPackage", typeof(GameObject));
		}
		else if(type.Contains("Diamond"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/DiamondPackage", typeof(GameObject));
		}
		else if(type.Contains("Gold"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/GoldPackage", typeof(GameObject));
		}
		else if(type.Contains("Hydrogen"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/HydrongenPackage", typeof(GameObject));
		}
		else if(type.Contains("Iron"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/IronPackage", typeof(GameObject));
		}
		else if(type.Contains("Lead"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/LeadPackage", typeof(GameObject));
		}
		else if(type.Contains("Platinum"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/PlatinumPackage", typeof(GameObject));
		}
		else if(type.Contains("Unobtanium"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/UnobtaniumPackage", typeof(GameObject));
		}
		else if(type.Contains("Uranium"))
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/UraniumPackage", typeof(GameObject));
		}
		else if(type.Contains("EnemyShip"))
		{
			package = (GameObject)Resources.Load ("Prefags/packages/UnobtaniumPackage", typeof(GameObject));
			numEnemies--;
		}
		else
		{
			package = (GameObject)Resources.Load ("Prefabs/packages/package", typeof(GameObject));
		}

		int resourceNum = spawn.GetComponent<rockAttri> ().getResource ();
		spawns.Remove (spawn);
		Destroy (spawn);

		GameObject newPackage = (GameObject)Instantiate (package, spawn.transform.position, Quaternion.identity);
		newPackage.transform.SendMessage("setResourceNum", resourceNum,SendMessageOptions.DontRequireReceiver);
	}

	public int[] getEachSpawnNum()
	{
		return EachSpawnNum;
	}
}