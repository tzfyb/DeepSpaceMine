#pragma strict
var explosion:Transform;
static var health:int;

static var currHealth:int;
static var healthRate:int;
var healthTime = 0;

//sets up the initial armor stats
function Start () {
	health = 60;
	currHealth = 60;
	healthRate = 7;
}

//over time, the armor of the base regenerates
function Update () {
	if(currHealth < health && Time.time > healthTime)
	{
		currHealth++;
		healthTime = Time.time + healthRate;
	}
}

function OnTriggerEnter (other : Collider) {
	//doesn't trigger if the ammo moves through it or the boundary
	if (other.tag == "boundary" || other.tag == "nuclearshot" || other.tag == "TurretShot" || other.tag == "missile")
		{
			return;
		}
		currHealth--;
		currHealth--;
		
		//destroys enemies as they touch the armor
		var exp = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		
		//if the armor becomes 0, the home base is destroyed
		if (currHealth > 0) {
			return;
		}
		else
		{
			Application.LoadLevel (0);
		}
}