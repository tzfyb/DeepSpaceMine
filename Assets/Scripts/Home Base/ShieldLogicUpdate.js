#pragma strict
var explosion:Transform;
static var shieldStrength : int;

static var currshieldStrength:int;
static var shieldRate:int;
var shieldTime = 0;

function Start () {
	shieldStrength = 80;
	shieldRate = 5.5;
	currshieldStrength = 80;
}

//shields health regains over time to the max
function Update () {
	if(currshieldStrength < shieldStrength && Time.time > shieldTime)
	{
		currshieldStrength++;
		shieldTime = Time.time + shieldRate;
	}
}

function OnTriggerEnter (other : Collider) {
		//won't triger the boundary, or the ammo shots
		if (other.tag == "boundary" || other.tag == "TurretShot" || other.tag == "missile" || other.tag == "nuclearshot")
		{
			return;
		}
		currshieldStrength--;
		currshieldStrength--;
		
		//destroys enemies that come into contact with the shield
		var exp = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		
		//destroys the shield if it reaches 0 health
		if (currshieldStrength > 0) {
			return;
		}
		else
		{
			Destroy(gameObject);
		}
}