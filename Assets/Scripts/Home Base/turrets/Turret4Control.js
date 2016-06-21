var bulletPreFab:Transform;
var misslePreFab:Transform;
var bombPreFab:Transform;
var gos : GameObject[];
var numEnemys;
var attEnemy;
static var fireRate = 0.2;
static var fireRateTur = 1;
static var fireRateBom = 10;
private var nextFire = 0.0;

static var type4:int;
static var level4:int;

function Start () {
	type4 = 2;
	attEnemy = 0;
	
	//gets all the enemys
	gos = GameObject.FindGameObjectsWithTag("enemy"); 
	
	numEnemys = gos.Length;
}


function Update () {

	//will only work if enemys are left
	if(GameObject.FindGameObjectsWithTag("enemy").Length > 0) {
		gos = GameObject.FindGameObjectsWithTag("enemy"); 
		attEnemy = -1;
		//finds the first enemy within range to attack
		for(i = 0; i < numEnemys; i++){
			try{
				if(gos[i].transform.position.x <= 0){
					attEnemy = i;
					break;
				}
			} catch(err) {
			
			}
		}
	
		//will only look at enemy in line of sight
		if(attEnemy != -1){
			transform.LookAt(gos[attEnemy].transform);
			shoot();
		 }
	 }
}


function shoot(){

	if(type4 == 1 && Time.time > nextFire)
	{
			
		//depending on the level, it will fire quick or slow
		nextFire = Time.time + fireRateTur;
		var bullet = Instantiate(bulletPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
		
		bullet.rigidbody.AddForce(transform.forward*1000);

	}
	else if(type4 == 2 && Time.time > nextFire)
	{
		nextFire = Time.time + fireRate;
		var missle = Instantiate(misslePreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
			
		missle.rigidbody.AddForce(transform.forward*500);
	}
	else if(type4 == 3 && Time.time > nextFire)
	{
		//depending on the level, it will fire faster or slower then normal
		nextFire = Time.time + fireRateBom;
		var bomb = Instantiate(bombPreFab, transform.Find("spawnpoint").transform.position, Quaternion.identity);
		
		bomb.rigidbody.AddForce(transform.forward*1000);
	}
}